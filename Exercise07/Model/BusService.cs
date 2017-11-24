using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise07.Model
{
    public class BusService
    {
        [JsonProperty("services")]
        public List<Service> Services { get; set; }

        [JsonProperty("types")]
        public Types Types { get; set; }
    }
}
