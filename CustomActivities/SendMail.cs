using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Net.Mail;

namespace CustomActivities
{
	public class SendMail : CodeActivity
    {
        public InArgument<string> FromAddress { get; set; }
        public InArgument<string> ToAddress { get; set; }
        public InArgument<string> Subject { get; set; }
        public InArgument<string> MailBody { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            SmtpClient client = new SmtpClient();
            client.Send(
                FromAddress.Get(context), ToAddress.Get(context),
                Subject.Get(context), MailBody.Get(context));
        }
    }
}
