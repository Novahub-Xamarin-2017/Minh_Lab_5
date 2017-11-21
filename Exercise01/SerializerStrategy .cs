using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01
{
    public class SerializerStrategy : PocoJsonSerializerStrategy
    {
        protected override string MapClrMemberNameToJsonFieldName(string clrPropertyName)
        {
            if (clrPropertyName.Equals("EmailAddress"))
            {
                Console.WriteLine(1);
                return "email_address";
            }

            if (clrPropertyName.Equals("Status"))
            {
                Console.WriteLine(2);
                return "status";
            }

            return clrPropertyName;
        }
    }
}
