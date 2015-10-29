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
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string studentName = Request.QueryString["StudentName"];
            int courseID = int.Parse(Request.QueryString["CourseID"]);
           
            CourseWF.CourseServiceClient proxy =
                new CourseWF.CourseServiceClient();
        
            try
            {
                proxy.SignInStudent(courseID, studentName);
            }
            catch (Exception ex)
            {
                responseMessage.Text = "Failed to sign in student";
            }  
        }
    }
}
