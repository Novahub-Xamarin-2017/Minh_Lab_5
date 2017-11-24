using Newtonsoft.Json;
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
    public class The
    {
        [DataMember(Name = "route")]
        [XmlElement(ElementName = "route")]
        public List<string> Route { get; set; }

        [DataMember(Name = "stops")]
        [XmlElement(ElementName = "stops")]
        public List<string> Stops { get; set; }
    }
}
