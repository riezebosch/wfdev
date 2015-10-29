using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;

namespace CourseWeb
{
    public partial class Registrations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DbDataRecord record = e.Row.DataItem as DbDataRecord;
                e.Row.Controls[2].Visible = !((bool)record[3]);
            }
        }
    }
}
