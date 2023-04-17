using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data.SqlClient;

namespace HotelWebApp
{
    public partial class Confirmation : System.Web.UI.Page
    {
        string connectionString, StartDate, EndDate;
        SqlCommand command;
        SqlConnection conn;
        int SelectedRoomID;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_DefaultConnection");
            //create database connection
            conn = new SqlConnection(connectionString);

            SelectedRoomID = (int)(Session["RoomID"]);
            StartDate = (string)(Session["StartDatePaymentPage"]);
            EndDate = (string)(Session["EndDatePaymentPage"]);


            updateSelectedRoomAvailability(conn);
            addUserIdToRoom(conn);
            updateStartAndEndDateForRoom(conn);

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());

            manager.SendEmail(User.Identity.GetUserId(), "Hotel California Reservation Confirmed", "Your Reservation has been confirmed. You will be staying in Room " + SelectedRoomID + " from " + StartDate + " to " + EndDate + ". Thank you for choosing Hotel California");

            confirm.InnerHtml = "Your room has been booked for your stay with us. We have sent you a confirmation email to " + user.Email;
        }

        private void updateSelectedRoomAvailability(SqlConnection conn)
        {
            string updateRoomAvailabilitySql = "UPDATE Room SET Availability = 'Occupied' WHERE RoomID = " + SelectedRoomID;

            try
            {
                conn.Open();
                command = new SqlCommand(updateRoomAvailabilitySql, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void addUserIdToRoom(SqlConnection conn)
        {
            string addUserIdToRoomSql = "UPDATE Room SET Id = '" + User.Identity.GetUserId() + "' WHERE RoomID = " + SelectedRoomID;

            try
            {
                conn.Open();
                command = new SqlCommand(addUserIdToRoomSql, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void updateStartAndEndDateForRoom(SqlConnection conn)
        {
            string updateDatesForRoomSql = "UPDATE Room SET StartDate = '" + StartDate + "', EndDate = '" + EndDate + "' WHERE RoomID = " + SelectedRoomID;

            try
            {
                conn.Open();
                command = new SqlCommand(updateDatesForRoomSql, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}