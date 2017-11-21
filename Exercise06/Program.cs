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

            var streamReader = new StreamReader(filePath);
            var serializer = new XmlSerializer(typeof(Catalog));
            var obj = (Catalog)serializer.Deserialize(streamReader);

            var jsonString = JsonConvert.SerializeObject(obj);

            var streamwriter = new StreamWriter("../../../JsonFile/booksExercise06.json");
            streamwriter.Write(jsonString);

            Console.WriteLine(jsonString);

            Console.ReadKey();
        }
    }
}
