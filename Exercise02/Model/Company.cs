using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02.Model
{
    [DataContract]
    public class Company
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "catchPhrase")]
        public string CatchPhrase { get; set; }
        [DataMember(Name = "bs")]
        public string Bs { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Catchphrase: {CatchPhrase} Bs: {Bs}";
        }
    }
}
