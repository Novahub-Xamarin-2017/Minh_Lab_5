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
        public static string filePath = "../../../employees.json";

        static void Main(string[] args)
        {
            Console.Write("FilePath of JsonFile: ");
            var str = Console.ReadLine();
            if (!str.Equals(""))
            {
                filePath = str;
            }
            var jsonString = ReadFile(filePath);

            var obj = JsonConvert.DeserializeObject<Employess>(jsonString);
            var xmlSerializer = new XmlSerializer(obj.GetType());

            var strWriter = new StringWriter();
            var writer = XmlWriter.Create(strWriter);
            xmlSerializer.Serialize(writer, obj);

            var xmlString = strWriter.ToString();
            Console.WriteLine(xmlString);

            var qweqwe = new XmlDocument();
            qweqwe.LoadXml(xmlString);
            qweqwe.Save("../../../employees.xml");

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
