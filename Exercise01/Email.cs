using Newtonsoft.Json;
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
        public string EmailAddress { set; get; }
        [JsonProperty("status")]
        public string Status { set; get; }
    }
}
