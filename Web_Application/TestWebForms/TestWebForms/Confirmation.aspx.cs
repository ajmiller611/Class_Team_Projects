using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace TestWebForms
{
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int SelectedRoomID = (int)(Session["RoomID"]);
            string StartDate = (string)(Session["StartDatePaymentPage"]);
            string EndDate = (string)(Session["EndDatePaymentPage"]);

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());

            manager.SendEmail(User.Identity.GetUserId(), "Hotel California Reservation Confirmed", "Your Reservation has been confirmed. You will be staying in Room " + SelectedRoomID + " from " + StartDate + " to " + EndDate + ". Thank you for choosing Hotel California");

            confirm.InnerHtml = "Your room has been booked for your stay with us. We have sent you a confirmation email to " + user.Email;
        }
    }
}