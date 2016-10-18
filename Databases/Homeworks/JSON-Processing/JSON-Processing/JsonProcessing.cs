using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace JSON_Processing
{
    public class JsonProcessing
    {
        public static object JsonConvert { get; private set; }

        static void Main(string[] args)
        {
            var rssUrl = @"https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            var client = new WebClient();
            var url = @"../../data.xml";

            // task 2
            client.DownloadFile(rssUrl, url);

            // task 3
            var urlForParsedJson = @"../../data.json";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            string jsonText = Newtonsoft.Json.JsonConvert.SerializeXmlNode(xmlDoc);
            File.WriteAllText(urlForParsedJson, jsonText);

            // task 4 and 5
            var JSONObj = JObject.Parse(jsonText);

            var videos = JSONObj["feed"]["entry"]
                .Select(entry => Newtonsoft.Json.JsonConvert.DeserializeObject<Video>(entry.ToString()));

            foreach (var video in videos)
            {
                Console.WriteLine(video.Title);
            }

        }
    }
}
