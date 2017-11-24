using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03.Model
{
    [DataContract]
    public class Rain
    {
        [JsonProperty("__invalid_name__3h")]
        public int invalidName3h { get; set; }
    }
}
