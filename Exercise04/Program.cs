using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise04
{
    public class Program
    {
        public static string filePath = "../../../JsonFile/employees.json";

        static void Main(string[] args)
        {
            Console.Write("FilePath of JsonFile: ");
            var str = Console.ReadLine();
            if (!string.IsNullOrEmpty(str))
            {
                filePath = str;
            }
            var jsonString = File.ReadAllText(filePath);

            var obj = JsonConvert.DeserializeObject<Employess>(jsonString);
            var xmlString = ObjectToXmlString(obj);
            Console.WriteLine(xmlString);

            var folder = "../../../XmlFile/";
            SaveAsXml(xmlString, folder);

            Console.ReadKey();
        }

        static void SaveAsXml(string xmlString, string folder)
        {
            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlString);
            xmldoc.Save($"{folder}employees.xml");
        }

        static string ObjectToXmlString(object obj)
        {
            var xmlSerializer = new XmlSerializer(obj.GetType());
            using (var strWriter = new StringWriter())
            {
                var writer = XmlWriter.Create(strWriter);
                xmlSerializer.Serialize(writer, obj);
                return strWriter.ToString();
            }
        }
    }
}
