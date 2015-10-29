using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract(Namespace = "http://pluralsight.com/courses/")]
    [Serializable]
    public class Person
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Name { get; set; }

        public Person()
        {}

        public Person(string personName)
        {
            this.Name = personName;
        }

        public Person(string personName,string personEmail)
        {
            this.Name = personName;
            this.Email = personEmail;
        }
    }
}
