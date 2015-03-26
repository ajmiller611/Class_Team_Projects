using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace TestWebForms
{
    public partial class Results : System.Web.UI.Page
    {
        string sql;
        string connetionString;
        SqlCommand command;
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (PreviousPage != null)
                {
                    ContentPlaceHolder cp = ((ContentPlaceHolder)PreviousPage.Master.FindControl("MainContent"));

                    Calendar StartDate = (Calendar)cp.FindControl("StartDate");
                    Calendar EndDate = (Calendar)cp.FindControl("EndDate");
                    CheckBox Smoking = (CheckBox)cp.FindControl("Smoking");
                    CheckBox OceanView = (CheckBox)cp.FindControl("OceanView");

                    if (Smoking.Checked && !OceanView.Checked)
                    {
                        sql = "SELECT RoomID, Description, Price FROM Room WHERE Availability = 'Vacant' AND Smoking = 'True' AND (EndDate <= '" + StartDate.SelectedDate.ToShortDateString() + "' OR EndDate IS NULL)";
                    }
                    else if (OceanView.Checked && !Smoking.Checked)
                    {
                        sql = "SELECT RoomID, Description, Price FROM Room WHERE OceanView = 'True' AND Availability = 'Vacant' AND Smoking = 'False' AND (EndDate <= '" + StartDate.SelectedDate.ToShortDateString() + "' OR EndDate IS NULL)";
                    }
                    else if (Smoking.Checked && OceanView.Checked)
                    {
                        sql = "SELECT RoomID, Description, Price FROM Room WHERE OceanView = 'True' AND Smoking = 'True' AND Availability = 'Vacant' AND (EndDate <= '" + StartDate.SelectedDate.ToShortDateString() + "' OR EndDate IS NULL)";
                    }
                    else
                    {
                        sql = "SELECT RoomID, Description, Price FROM Room WHERE Smoking = 'False' AND Availability = 'Vacant' AND (EndDate <= '" + StartDate.SelectedDate.ToShortDateString() + "' OR EndDate IS NULL)";
                    }


                    connetionString = ConfigurationManager.AppSettings["ConnectionString"];
                    //create database connection
                    conn = new SqlConnection(connetionString);

                    try
                    {
                        conn.Open();
                        //create command to run sql statement
                        command = new SqlCommand(sql, conn);

                        //data reader to get the query result from
                        SqlDataReader data = command.ExecuteReader();

                        while (data.Read())
                        {
                            RoomResults.Items.Add(data.GetValue(1) + " Room Number: " + data.GetValue(0) + " Price: " + data.GetValue(2));
                        }
                        command.Dispose();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //test.Text = "Can not open connection ! ";
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