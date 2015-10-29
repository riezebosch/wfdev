using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace CourseWeb
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerButton_Click(object sender, EventArgs e)
        {

            CourseWF.CourseServiceClient proxy =
                new CourseWF.CourseServiceClient();
            
           
            proxy.SubmitRegistration(
                new Contracts.CourseRegistration
                {
                    Attendee = new Contracts.Person
                    {
                        Name =studentName.Text,
                        Email = studentEmail.Text
                    },
                    CourseID = int.Parse(Request.QueryString["courseID"]),
                    PaymentReceived = true
                });

            proxy.Close();

            responseMessage.Text = "User successfully registered.";

        }
    }
}
