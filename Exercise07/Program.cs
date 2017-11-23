using Exercise07.Model;
using Newtonsoft.Json;
using RestSharp;
using Retrofit.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise07
{
    class Program
    {
        static void Main(string[] args)
        {
            var restClient = new RestClient("http://danabus.vn/data/2/");
            var adapter = new RestAdapter(restClient);
            var service = adapter.Create<IBusService>();

            var respone = service.GetBusService();
            Console.WriteLine(respone.ResponseStatus);

            var obj = respone.Data;
            var xmlString = ObjectToXmlString(obj);
            Console.WriteLine(xmlString);

            var folder = "../../../XmlFile/";
            SaveAsXml(xmlString, folder, "");

            var id = "12";
            var responeId = service.GetBusServiceId(id);
            Console.WriteLine(responeId.ResponseStatus);

            var objId = JsonConvert.DeserializeObject<BusServiceId>(responeId.Content);
            SaveBusServiceIdtoXml(id, objId, folder);

            Console.ReadKey();
        }

        static void SaveAsXml(string xmlString, string folder, string id)
        {
            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlString);

            if (string.IsNullOrEmpty(id))
            {
                xmldoc.Save($"{folder}Service.xml");
            } else
            {
                xmldoc.Save($"{folder}BusService{id}.xml");
            }
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

        static void SaveBusServiceIdtoXml(string id, BusServiceId busServiceId, string folder)
        {
            var xmlString = ObjectToXmlString(busServiceId);
            Console.WriteLine(xmlString);

            SaveAsXml(xmlString, folder, id);
        }
    }
}
