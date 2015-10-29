using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract(Namespace="http://pluralsight.com/courses/")]
    [Serializable]
    public class Course
    {
        [DataMember]
        public string Topic { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public List<Person> Instructors { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public int CourseID { get; set; }
    }
}
