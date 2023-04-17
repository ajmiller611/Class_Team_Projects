using System;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace HotelWebApp
{
    public partial class Payment : System.Web.UI.Page
    {
        string connectionString;
        SqlCommand command;
        SqlConnection conn;
        int AccountNumber;
        static int SelectedRoomID, LengthOfStay;
        static decimal SelectedRoomPrice;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (PreviousPage != null && PreviousPage.IsCrossPagePostBack == true)
                {
                    ContentPlaceHolder cp = ((ContentPlaceHolder)PreviousPage.Master.FindControl("MainContent"));

                    RadioButtonList RoomList = (RadioButtonList)cp.FindControl("RoomResults");

                    string SelectedRoomString = RoomList.SelectedValue;
                    int StartIndexOfRoomID = SelectedRoomString.IndexOf("Room Number: ");
                    SelectedRoomID = Convert.ToInt32(SelectedRoomString.Substring(StartIndexOfRoomID + 13, 3));
                    DateTime StartDate = Convert.ToDateTime(Session["StartDateResultsPage"]);
                    DateTime EndDate = Convert.ToDateTime(Session["EndDateResultsPage"]);
                    TimeSpan difference = EndDate - StartDate;
                    LengthOfStay = difference.Days;

                    connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
                    
                    //create database connection
                    conn = new SqlConnection(connectionString);
                    string updateRoomSql = "UPDATE Room SET Availability = 'In Progress' WHERE RoomID = " + SelectedRoomID;
                    string getRoomPriceSql = "Select Price FROM Room WHERE RoomID = " + SelectedRoomID;

                    try
                    {
                        conn.Open();
                        //create command to run sql statement
                        command = new SqlCommand(updateRoomSql, conn);
                        command.ExecuteNonQuery();

                        command = new SqlCommand(getRoomPriceSql, conn);
                        SqlDataReader data = command.ExecuteReader();

                        while (data.Read())
                        {
                            SelectedRoomPrice = (decimal)data.GetValue(0);
                        }


                        command.Dispose();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //test.Text = "Can not open connection ! ";
                    }

                    total.Text = "Your total amount is: " + (SelectedRoomPrice * LengthOfStay);

                    Session["RoomID"] = SelectedRoomID;
                    Session["Price"] = SelectedRoomPrice;
                    Session["StartDatePaymentPage"] = (Session["StartDateResultsPage"]);
                    Session["EndDatePaymentPage"] = (Session["EndDateResultsPage"]);
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            DateTime ExpirationDate = Convert.ToDateTime(Expiration.Text);
            DateTime Today = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            if (ExpirationDate.ToShortDateString().CompareTo(Today.ToShortDateString()) < 0)
            {
                ExpirationValidation.IsValid = false;
                return;
            }

            string user = User.Identity.GetUserId();

            connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
            
            //create database connection
            conn = new SqlConnection(connectionString);


            createTransaction(user, conn);
            updateAccountBalance(conn);

            conn.Close();

            Server.Transfer("~/Confirmation.aspx");

        }

        protected void Clear_Click(object sender, EventArgs e)
        {

        }

        private int getAccountNumber(string user, SqlConnection conn)
        {
            int userAccountNumber = -1;

            string findAccountSql = "Select AccountNumber FROM Account WHERE Id = '" + user + "'";
            string createAccountSql = "INSERT INTO Account (Id, PaymentType, CreditCardNumber, CreditCardCvv) Values ('" + user + "', '" + CardType.SelectedValue + "', '" + CardNumber.Text + "', '" + Cvv.Text + "')";

            try
            {
                conn.Open();
                command = new SqlCommand(findAccountSql, conn);
                SqlDataReader data = command.ExecuteReader();

                if (!data.HasRows)
                {
                    data.Close();
                    command = new SqlCommand(createAccountSql, conn);
                    command.ExecuteNonQuery();
                    command = new SqlCommand(findAccountSql, conn);
                    data = command.ExecuteReader();
                }

                while (data.Read())
                {
                    userAccountNumber = (int)data.GetValue(0);
                }
                data.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return userAccountNumber;
        }

        private void createTransaction(string user, SqlConnection conn)
        {
            AccountNumber = getAccountNumber(user, conn);
            string insertTransactionInfoSql = "INSERT INTO [Transaction] (Id, AccountNumber, StaffID, Amount) VALUES ('" + user + "', '" + AccountNumber + "', '1', '" + SelectedRoomPrice + "')";

            try
            {
                conn.Open();
                command = new SqlCommand(insertTransactionInfoSql, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void updateAccountBalance(SqlConnection conn)
        {
            string updateAccountBalanceSql = "UPDATE Account SET AccountBalance = AccountBalance + " + (SelectedRoomPrice * LengthOfStay) + " WHERE AccountNumber = " + AccountNumber;

            try
            {
                conn.Open();
                command = new SqlCommand(updateAccountBalanceSql, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}