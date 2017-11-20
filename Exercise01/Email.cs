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
        [DataMember(Name = "email_address")]
        public string EmailAddress { set; get; }
        [DataMember(Name = "status")]
        public string Status { set; get; }
    }
}
