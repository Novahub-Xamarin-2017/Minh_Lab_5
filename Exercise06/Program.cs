using Exercise06.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise06
{
    public class Program
    {
        public static string filePath = "../../../XmlFile/booksExercise06.xml";

        static void Main(string[] args)
        {
            Console.Write("FilePath of XmlFile: ");
            var str = Console.ReadLine();
            if (!str.Equals(""))
            {
                filePath = str;
            }
            var xmlString = ReadFile(filePath);

            var xml = new XmlDocument();
            xml.LoadXml(xmlString);

            var jsonString = JsonConvert.SerializeXmlNode(xml);
            var streamwriter = new StreamWriter("../../../JsonFile/booksExercise06.json");

            Console.WriteLine(jsonString);
            streamwriter.Write(jsonString);

            /*var obj = JsonConvert.DeserializeObject<Catalog>(xmlString);
            JsonConvert.d
            var xmlSerializer = new XmlSerializer(obj.GetType());

            var strWriter = new StringWriter();
            var writer = XmlWriter.Create(strWriter);
            xmlSerializer.Serialize(writer, obj);

            var xmlString = strWriter.ToString();
            Console.WriteLine(xmlString);

            var qweqwe = new XmlDocument();
            qweqwe.LoadXml(xmlString);
            qweqwe.Save("../../../JsonFile/booksExercise06.json");*/

            Console.ReadKey();
        }

        static string ReadFile(string filePath)
        {
            var sr = new StreamReader(filePath);
            var str = "";
            var line = "";

            while ((line = sr.ReadLine()) != null)
            {
                str = str + line + "\n";
            }

            return str;
        }
    }
}
