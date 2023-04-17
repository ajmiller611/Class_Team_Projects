using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;

namespace HotelWebApp
{
    public partial class Reservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (User.Identity.GetUserId() == null)
            {
                UserLoggedInCheck.IsValid = false;
            }
            else
            {
                DateTime Today = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
                DateTime Start = StartDate.SelectedDate;
                DateTime End = EndDate.SelectedDate;
                DateTime z = new DateTime();
                if (Start == z)
                {
                    StartDateValidation.IsValid = false;
                    return;
                }
                if (End == z)
                {
                    EndDateValidation.IsValid = false;
                    return;
                }
                if (Start > End)
                {
                    EndDateAfterStartDateValidation.IsValid = false;
                    return;
                }
                if (Start.ToShortDateString().CompareTo(Today.ToShortDateString()) < 0)
                {
                    StartDateNotBeforeTodayValidation.IsValid = false;
                    return;
                }

                Server.Transfer("~/Results.aspx", true);
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {

        }
    }
}