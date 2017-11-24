using Exercise04.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04
{
    [DataContract]
    public class Employess
    {
        [DataMember(Name = "Employees")]
        public List<Employee> Employees { get; set; }
    }
}
