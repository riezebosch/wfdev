using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract(Namespace = "http://pluralsight.com/courses/")]
    [Serializable]
    public class CourseRegistration
    {
        [DataMember]
        public int CourseID { get; set; }
        [DataMember]
        public string CourseName { get; set; }
        [DataMember]
        public Person Attendee { get; set; }
        [DataMember]
        public bool PaymentReceived { get; set; }
    }
}
