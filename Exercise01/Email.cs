using Newtonsoft.Json;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01
{
    [DataContract]
    public class Email
    {
        [JsonProperty("email_address")]
        [SerializeAs(Name = "email_address")]
        [DeserializeAs(Name = "email_address")]
        public string EmailAddress { set; get; }

        [JsonProperty("status")]
        [SerializeAs(Name = "status")]
        [DeserializeAs(Name = "status")]
        public string Status { set; get; }
    }
}
