using Newtonsoft.Json;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exercise07.Model
{
    [DataContract]
    [XmlRoot(ElementName = "busServiceId")]
    public class BusServiceId
    {
        [JsonProperty("1")]
        [XmlElement(ElementName = "1")]
        public The The1 { get; set; }

        [JsonProperty("2")]
        [XmlElement(ElementName = "2")]
        public The The2 { get; set; }
    }
}
