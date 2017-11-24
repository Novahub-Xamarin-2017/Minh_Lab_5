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
    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        [JsonProperty("pressure")]
        public int Pressure { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        [JsonProperty("temp_min")]
        public double TemperatureMin { get; set; }
        [JsonProperty("temp_max")]
        public double TemperatureMax { get; set; }
    }
}
