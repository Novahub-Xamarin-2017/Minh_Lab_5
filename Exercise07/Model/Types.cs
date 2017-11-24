using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise07.Model
{
    public class Types
    {
        [JsonProperty("0")]
        public string The0 { get; set; }

        [JsonProperty("1")]
        public string The1 { get; set; }

        [JsonProperty("2")]
        public string The2 { get; set; }
    }
}
