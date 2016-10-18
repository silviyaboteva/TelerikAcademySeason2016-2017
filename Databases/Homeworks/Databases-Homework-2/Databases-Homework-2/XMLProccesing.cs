using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Xsl;

namespace Databases_Homework_2
{
    class XMLProccesing
    {
        public static void Main()
        {
            var url = "../../Catalogue.xml";

            //task 2
            ExtractArtistsFromCatalogue(url);
            PrintNewLine();

            //task 3
            ExtractArtistsFromCatalogueXPath(url);
            PrintNewLine();

            //task 4
            DeleteAlbumsWithPriceMoreThan20(url);

            //task 5
            ExtractAllSongsFromCatalogueWithXReader(url);
            PrintNewLine();

            //task 6
            ExtractAllSongsFromCatalogueWithXDocumentAndLinqQuery(url);
            PrintNewLine();

            //task 7 
            CreateNewXMLDocumentFromFile(url);

            //task 8
            CreateAlbumsWithXWriter(url);

            //task 9
            TraverseDirAndWriteInXmlUsingXmlWritter();
            PrintNewLine();

            //task 10
            TraverseUsingXDocument();
            PrintNewLine();

            //task 11
            GetPriceForAlbums(url);
            PrintNewLine();

            //task 12
            GetPriceForAlbumsWithLINQ(url);
            PrintNewLine();

            //task 14
           //ApplyXslt(url);

            //task 16
            //ValiateXml(url);
        }

        private static void PrintNewLine()
        {
            Console.WriteLine("--------------------------------------");
        }

        //task 2
        private static void ExtractArtistsFromCatalogue(string url)
        {
            var doc = new XmlDocument();
            doc.Load(url);

            XmlNode root = doc.DocumentElement;

            var artists = new HashSet<string>();

            foreach (XmlNode catalogue in root.ChildNodes)
            {
                foreach (XmlNode album in catalogue.ChildNodes)
                {
                    if (album.Name == "artist")
                    {
                        artists.Add(album.InnerText);
                    }
                }
            }

            foreach (var item in artists)
            {
                Console.WriteLine(item);
            }
        }

        //task 3
        private static void ExtractArtistsFromCatalogueXPath(string url)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);
            string xPathQuery = "/catalogue/album/artist";

            XmlNodeList artistsList = xmlDoc.SelectNodes(xPathQuery);
            var artists = new HashSet<string>();

            foreach (XmlNode artistNode in artistsList)
            {
                string artist = artistNode.InnerText;
                if (!artists.Contains(artist))
                {
                    artists.Add(artist);
                }
            }

            foreach (var item in artists)
            {
                Console.WriteLine(item);
            }
        }

        //task 4
        private static void DeleteAlbumsWithPriceMoreThan20(string url)
        {
            var doc = new XmlDocument();
            doc.Load(url);

            XmlNode root = doc.DocumentElement;

            foreach (XmlNode catalogue in root.ChildNodes)
            {
                bool isHigher = false;
                foreach (XmlNode album in catalogue.ChildNodes)
                {
                    if (album.Name == "price")
                    {
                        var price = double.Parse(album.InnerText);
                        if (price > 20)
                        {
                            isHigher = true;
                            break;
                        }
                    }
                }

                if (isHigher)
                {
                    root.RemoveChild(catalogue);
                }
            }
            doc.Save(url);
        }

        //task 5
        private static void ExtractAllSongsFromCatalogueWithXReader(string url)
        {
            using (XmlReader reader = XmlReader.Create(url))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "song"))
                    {
                        XmlReader subtree = reader.ReadSubtree();
                        while (subtree.Read())
                        {
                            if (subtree.NodeType == XmlNodeType.Element && subtree.Name == "title")
                            {
                                Console.WriteLine(subtree.ReadInnerXml());
                            }
                        }
                    }
                }
            }
        }

        //task 6
        private static void ExtractAllSongsFromCatalogueWithXDocumentAndLinqQuery(string url)
        {
            XDocument xmlDoc = XDocument.Load(url);
            var allSongs = from album in xmlDoc.Descendants("album")
                           from songs in album.Descendants("songs")
                           from song in songs.Descendants("song")
                           from title in song.Descendants("title")
                           select new
                           {
                               Title = title.Value
                           };

            foreach (var item in allSongs)
            {
                Console.WriteLine(item);
            }
        }

        //task 7
        private static void CreateNewXMLDocumentFromFile(string url)
        {
            string[] data = File.ReadAllLines("../../PersonInfo.txt");
            string[] currentLine = new[] { "name", "address", "phone" };

            XElement root = new XElement("personInfo");
            XElement person = new XElement("person");
            for (int i = 0; i < data.Length; i++)
            {
                person.Add(new XElement(currentLine[i % 3], data[i]));

                if (i % 3 == 0)
                {
                    root.Add(person);
                }

            }

            root.Save("../../Person.Xml");
        }

        //task 8
        private static void CreateAlbumsWithXWriter(string url)
        {
            using (XmlReader reader = XmlReader.Create(url))
            {
                using (var writer = new XmlTextWriter("../../albums.xml", Encoding.Default))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("albums");
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "album")
                        {
                            XmlReader subtree = reader.ReadSubtree();
                            while (subtree.Read())
                            {
                                if (subtree.NodeType == XmlNodeType.Element && subtree.Name == "name")
                                {
                                    writer.WriteElementString("name", subtree.ReadInnerXml());
                                }
                                else if (subtree.NodeType == XmlNodeType.Element && subtree.Name == "artist")
                                {
                                    writer.WriteElementString("artist", subtree.ReadInnerXml());
                                    writer.WriteStartElement("album");
                                }
                            }
                        }
                    }

                    writer.WriteEndDocument();
                }
            }
        }

        //task 9
        private static void TraverseDirAndWriteInXmlUsingXmlWritter()
        {
            string dirPath = @"../../";

            using (XmlTextWriter writer = new XmlTextWriter("../../dir.xml", Encoding.Default))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = ' ';
                writer.Indentation = 4;

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                writer.WriteStartDocument();
                writer.WriteStartElement("root");

                foreach (var directory in Directory.GetDirectories(dirPath))
                {
                    writer.WriteStartElement("dir");
                    writer.WriteAttributeString("path", directory);
                    writer.WriteEndElement();
                }

                foreach (var file in Directory.GetFiles(dirPath))
                {
                    writer.WriteStartElement("file");
                    writer.WriteAttributeString("name", Path.GetFileNameWithoutExtension(file));
                    writer.WriteAttributeString("ext", Path.GetExtension(file));
                    writer.WriteEndElement();
                }

                writer.WriteEndDocument();
            }

            var currentDir = Directory.GetCurrentDirectory();
            var savedDir = currentDir.Substring(0, currentDir.IndexOf("bin\\Debug"));
            Console.WriteLine("result saved as " + savedDir + "dir.xml");
        }

        //task 10
        private static void TraverseUsingXDocument()
        {
            string path = @"../../";

            var root = Traverse(path);
            root.Save("../../dirXDocument.xml");

            var currentDir = Directory.GetCurrentDirectory();
            var savedDir = currentDir.Substring(0, currentDir.IndexOf("bin\\Debug"));
            Console.WriteLine("result saved as " + savedDir + "dir.xml");
        }

        private static XElement Traverse(string dir)
        {
            var element = new XElement("dir", new XAttribute("path", dir));

            foreach (var directory in Directory.GetDirectories(dir))
            {
                element.Add(Traverse(directory));
            }

            foreach (var file in Directory.GetFiles(dir))
            {
                element.Add(new XElement("file",
                    new XAttribute("name", Path.GetFileNameWithoutExtension(file)),
                    new XAttribute("ext", Path.GetExtension(file))));
            }

            return element;
        }

        //task 11
        private static void GetPriceForAlbums(string url)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            string xPathQuery = "/catalogue/album[year<=2011]/price";

            var albums = doc.SelectNodes(xPathQuery);

            foreach (XmlNode album in albums)
            {
                var albumName = album.InnerText;
                Console.WriteLine(albumName);
            }
        }

        //task 12
        private static void GetPriceForAlbumsWithLINQ(string url)
        {
            var document = XDocument.Load(url);

            var filtered = from album in document.Descendants("album")
                           where int.Parse(album.Element("year").Value) < 2011
                           select album.Element("price").Value;

            foreach (var item in filtered)
            {
                Console.WriteLine(item);
            }
        }

        //task 14
        private static void ValiateXml(string url)
        {
            var xdoc = XDocument.Load(url);
            var schemas = new XmlSchemaSet();
            schemas.Add("catalogue-academy-com:music", @"../../../Catalogue.xsd");

            xdoc.Validate(schemas, null);
        }

        //task 16
        private static void ApplyXslt(string url)
        {
            var xsltUrl = @"../../style.xslt";
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltUrl);
            xslt.Transform(url, "../../catalog.html");
        }
    }
}
