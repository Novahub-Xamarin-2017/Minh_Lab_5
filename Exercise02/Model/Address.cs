using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02.Model
{
    [DataContract]
    public class Address
    {
        [DataMember(Name = "street")]
        public string Street { get; set; }
        [DataMember(Name = "suite")]
        public string Suite { get; set; }
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "zipcode")]
        public string Zipcode { get; set; }
        [DataMember(Name = "geo")]
        public Geo Geo { get; set; }

        public override string ToString()
        {
            return $"Street: {Street} Suite: {Suite} City: {City} Zipcode: {Zipcode} Geo: {Geo}";
        }
    }
}
