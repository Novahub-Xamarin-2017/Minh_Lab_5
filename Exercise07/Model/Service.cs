using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise07.Model
{
    public class Service
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("no")]
        public string No { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("routes")]
        public long Routes { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
