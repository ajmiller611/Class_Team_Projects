using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TestWebForms
{
    public partial class Reservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            DateTime x = StartDate.SelectedDate;
            DateTime y = EndDate.SelectedDate;
            DateTime z = new DateTime();
            if (x == z)
            {
                StartDateValidation.IsValid = false;
                return;
            }
            if (y == z)
            {
                EndDateValidation.IsValid = false;
                return;
            }
            if (x > y)
            {
                EndDateAfterStartDateValidation.IsValid = false;
                return;
            }

            Server.Transfer("~/Results.aspx", true);
        }

        protected void Clear_Click(object sender, EventArgs e)
        {

        }
    }
}