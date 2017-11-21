﻿using Exercise05.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise05
{
    public class Program
    {
        public static string filePath = "../../../JsonFile/books.json";

        static void Main(string[] args)
        {
            Console.Write("FilePath of JsonFile: ");
            var str = Console.ReadLine();
            if (!str.Equals(""))
            {
                filePath = str;
            }
            var jsonString = ReadFile(filePath);

            var obj = JsonConvert.DeserializeObject<List<Book>>(jsonString);
            var xmlSerializer = new XmlSerializer(obj.GetType());

            var strWriter = new StringWriter();
            var writer = XmlWriter.Create(strWriter);
            xmlSerializer.Serialize(writer, obj);

            var xmlString = strWriter.ToString();
            Console.WriteLine(xmlString);

            var qweqwe = new XmlDocument();
            qweqwe.LoadXml(xmlString);
            qweqwe.Save("../../../XmlFile/books.xml");

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
