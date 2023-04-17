using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace HotelWebApp
{
    public partial class Results : System.Web.UI.Page
    {
        string sql;
        string connectionString;
        SqlCommand command;
        SqlConnection conn;
        int radioButtonListSize = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (PreviousPage != null)
                {
                    ContentPlaceHolder cp = ((ContentPlaceHolder)PreviousPage.Master.FindControl("MainContent"));

                    Calendar StartDate = (Calendar)cp.FindControl("StartDate");
                    Calendar EndDate = (Calendar)cp.FindControl("EndDate");
                    DropDownList Smoking = (DropDownList)cp.FindControl("Smoking");
                    DropDownList OceanView = (DropDownList)cp.FindControl("OceanView");

                    if (Smoking.SelectedValue == "Smoking" && OceanView.SelectedValue == "No Preference")
                    {
                        sql = "SELECT RoomID, Description, Price FROM Room WHERE Availability = 'Vacant' AND Smoking = 'True' AND (EndDate <= '" + StartDate.SelectedDate.ToShortDateString() + "' OR EndDate IS NULL)";
                    }
                    else if (Smoking.SelectedValue == "Smoking" && OceanView.SelectedValue == "No Ocean View")
                    {
                        sql = "SELECT RoomID, Description, Price FROM Room WHERE Smoking = 'True' AND OceanView = 'False' AND Availability = 'Vacant' AND (EndDate <= '" + StartDate.SelectedDate.ToShortDateString() + "' OR EndDate IS NULL)";
                    }
                    else if (Smoking.SelectedValue == "Smoking" && OceanView.SelectedValue == "Ocean View")
                    {
                        sql = "SELECT RoomID, Description, Price FROM Room WHERE OceanView = 'True' AND Smoking = 'True' AND Availability = 'Vacant' AND (EndDate <= '" + StartDate.SelectedDate.ToShortDateString() + "' OR EndDate IS NULL)";
                    }
                    else if (Smoking.SelectedValue == "No Preference" && OceanView.SelectedValue == "Ocean View")
                    {
                        sql = "SELECT RoomID, Description, Price FROM Room WHERE OceanView = 'True' AND Availability = 'Vacant' AND (EndDate <= '" + StartDate.SelectedDate.ToShortDateString() + "' OR EndDate IS NULL)";
                    }
                    else if (Smoking.SelectedValue == "No Preference" && OceanView.SelectedValue == "No Ocean View")
                    {
                        sql = "SELECT RoomID, Description, Price FROM Room WHERE OceanView = 'False' AND Availability = 'Vacant' AND (EndDate <= '" + StartDate.SelectedDate.ToShortDateString() + "' OR EndDate IS NULL)";
                    }
                    else if (Smoking.SelectedValue == "Non-Smoking" && OceanView.SelectedValue == "No Ocean View") 
                    {
                        sql = "SELECT RoomID, Description, Price FROM Room WHERE OceanView = 'False' AND Smoking = 'False' AND Availability = 'Vacant' AND (EndDate <= '" + StartDate.SelectedDate.ToShortDateString() + "' OR EndDate IS NULL)";
                    }
                    else if (Smoking.SelectedValue == "Non-Smoking" && OceanView.SelectedValue == "No Preference")
                    {
                        sql = "SELECT RoomID, Description, Price FROM Room WHERE Smoking = 'False' AND Availability = 'Vacant' AND (EndDate <= '" + StartDate.SelectedDate.ToShortDateString() + "' OR EndDate IS NULL)";
                    }
                    else if (Smoking.SelectedValue == "Non-Smoking" && OceanView.SelectedValue == "Ocean View")
                    {
                        sql = "SELECT RoomID, Description, Price FROM Room WHERE OceanView = 'True' AND Smoking = 'False' AND Availability = 'Vacant' AND (EndDate <= '" + StartDate.SelectedDate.ToShortDateString() + "' OR EndDate IS NULL)";
                    }
                    else
                    {
                        sql = "SELECT RoomID, Description, Price FROM Room WHERE Availability = 'Vacant' AND (EndDate <= '" + StartDate.SelectedDate.ToShortDateString() + "' OR EndDate IS NULL)";
                    }

                    connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
                    //connectionString = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_DefaultConnection");
                    //create database connection
                    conn = new SqlConnection(connectionString);

                    try
                    {
                        conn.Open();
                        //create command to run sql statement
                        command = new SqlCommand(sql, conn);

                        //data reader to get the query result from
                        SqlDataReader data = command.ExecuteReader();

                        while (data.Read())
                        {
                            RoomResults.Items.Add(data.GetValue(1) + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Room Number: " + data.GetValue(0) + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Price: " + data.GetValue(2));
                            radioButtonListSize++;
                        }
                        command.Dispose();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //test.Text = "Can not open connection ! ";
                    }

                    if (radioButtonListSize == 0)
                    {
                        NonemptyListValidation.IsValid = false;
                        Submit.Enabled = false;
                        return;
                    }


                    Session["StartDateResultsPage"] = StartDate.SelectedDate.ToShortDateString();
                    Session["EndDateResultsPage"] = EndDate.SelectedDate.ToShortDateString();
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Server.Transfer("~/Payment.aspx");
        }

        protected void Clear_Click(object sender, EventArgs e)
        {

        }
    }
}