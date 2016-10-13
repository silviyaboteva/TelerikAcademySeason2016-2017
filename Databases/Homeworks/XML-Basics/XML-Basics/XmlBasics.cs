using System.Xml.Xsl;

namespace XML_Basics
{
    public class XmlBasics
    {
        static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("E:/University/Telerik/Databases/Homeworks/XML-Basics/XML-Basics/files/students.xslt");
            xslt.Transform("E:/University/Telerik/Databases/Homeworks/XML-Basics/XML-Basics/files/students.xml", "E:/University/Telerik/Databases/Homeworks/XML-Basics/XML-Basics/files/students.html");
        }
    }
}