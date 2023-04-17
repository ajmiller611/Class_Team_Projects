using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace WindowsFormsApplication1
{

    public partial class Main : Form
    {

        public static bool validUser = false;
        public static bool manager = false;
        public static List<String> roomList = new List<String>();
        public static ArrayList roomArrayList = new ArrayList();
        public Main()
        {

            SignIn newSignIn = new SignIn();
            newSignIn.Show();
            InitializeComponent();
        }

        public static void updateRooms()
        {
            int[] indexForRoomList = new int[4];
            indexForRoomList[0] = 0;
            indexForRoomList[1] = 4;
            indexForRoomList[2] = 5;
            indexForRoomList[3] = 3;
            String command = "SELECT * FROM ROOM";
            roomArrayList = Main.databaseCon(command, indexForRoomList);
            roomList = roomArrayList.Cast<string>().ToList();
            
            Main.listBox1.DataSource = roomList;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (validUser)
            {
                newTransaction transaction = new newTransaction();
                transaction.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (validUser)
            {
                CancelReservation cancel = new CancelReservation();
                cancel.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (validUser && manager)
            {
                UpdatePricing update = new UpdatePricing();
                update.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (validUser)
            {
                ViewReports view = new ViewReports();
                view.Show();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (validUser)
            {
                ExistingCustomerReview ExistingCustomer = new ExistingCustomerReview();
                ExistingCustomer.Show();
            }
        }

        public static ArrayList databaseCon(string sql, int[] index)
        { 
        
        SqlCommand command;
        ArrayList result = new ArrayList();
            string connectionString = null;
            SqlConnection conn;
            connectionString = @"Data Source=tcp:k2n4n2hcwr.database.windows.net,1433;Initial Catalog=hotelstudentproject_db;User Id=hotelstudentproject@k2n4n2hcwr;Password=studentproject1!";
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                command = new SqlCommand(sql, conn);
                SqlDataReader data = command.ExecuteReader();
                while (data.Read())
                {
                    string tempData = "";
                    for(int a = 0;a < index.Length; a++)
                    {
                       tempData += data.GetValue(index[a]) + "  ";
                    }
                    result.Add(tempData);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }

            return result;
        
    }

        public static void databaseCon(string sql)
        {

            SqlCommand command;
            ArrayList result = new ArrayList();
            string connectionString = null;
            SqlConnection conn;
            connectionString = @"Data Source=tcp:k2n4n2hcwr.database.windows.net,1433;Initial Catalog=hotelstudentproject_db;User Id=hotelstudentproject@k2n4n2hcwr;Password=studentproject1!";
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                
                conn.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }


        }




        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        
        }
    }
}
