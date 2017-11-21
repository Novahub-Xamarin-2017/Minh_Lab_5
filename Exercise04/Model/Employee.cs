using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04.Model
{
    [DataContract]
    public class Employee
    {
        [DataMember(Name = "userId")]
        public string UserId { get; set; }

        [DataMember(Name = "jobTitleName")]
        public string JobTitleName { get; set; }

        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "preferredFullName")]
        public string PreferredFullName { get; set; }

        [DataMember(Name = "employeeCode")]
        public string EmployeeCode { get; set; }

        [DataMember(Name = "region")]
        public string Region { get; set; }

        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }

        [DataMember(Name = "emailAddress")]
        public string EmailAddress { get; set; }
    }
}
