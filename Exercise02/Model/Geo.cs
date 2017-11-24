using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02.Model
{
    [DataContract]
    public class Geo
    {
        [DataMember(Name = "lat")]
        public string Lat { get; set; }
        [DataMember(Name = "lng")]
        public string Lng { get; set; }

        public override string ToString()
        {
            return $"Lat: {Lat} Lng: {Lng}";
        }
    }
}
