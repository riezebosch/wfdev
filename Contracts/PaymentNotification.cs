using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts
{
    [Serializable]
    public class PaymentNotification
    {
        public string StudentName { get; set; }
        public int CourseID { get; set; }

    }
}
