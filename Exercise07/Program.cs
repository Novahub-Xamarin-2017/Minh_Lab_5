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
            var xmlSerializer = new XmlSerializer(obj.GetType());

            var xmlString = "";

            using (var strWriter = new StringWriter())
            {
                var writer = XmlWriter.Create(strWriter);
                xmlSerializer.Serialize(writer, obj);
                xmlString = strWriter.ToString();
            }

            Console.WriteLine(xmlString);

            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlString);
            xmldoc.Save("../../../XmlFile/Service.xml");

            var id = "5";
            var responeId = service.GetBusServiceId(id);
            Console.WriteLine(responeId.ResponseStatus);

            var objId = JsonConvert.DeserializeObject<BusServiceId>(responeId.Content);
            SaveBusServiceIdtoXml(id, objId);

            Console.ReadKey();
        }

        static void SaveBusServiceIdtoXml(string id, BusServiceId busServiceId)
        {
            var xmlString = "";

            using (var strWriter = new StringWriter())
            {
                var xmlSerializer = new XmlSerializer(busServiceId.GetType());
                var writer = XmlWriter.Create(strWriter);
                xmlSerializer.Serialize(writer, busServiceId);
                xmlString = strWriter.ToString();
            }

            Console.WriteLine(xmlString);

            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlString);
            xmldoc.Save($"../../../XmlFile/BusService{id}.xml");
        }
    }
}
