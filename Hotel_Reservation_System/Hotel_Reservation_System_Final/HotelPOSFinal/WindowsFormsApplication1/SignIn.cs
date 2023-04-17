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

namespace WindowsFormsApplication1
{
    public partial class SignIn : Form
    {
        String[,] users = new String[3, 3]
            {
            {"KGilbert", "Feanaro0", "staff"},
            {"AMiller", "Feanaro1", "staff"},
            {"HVomend", "Feanaro2", "manager"}
            };
        String[] input = new String[2];
        public SignIn()
        {
            

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < 3;a++ )
            {
                if(input[0].CompareTo(users[a,0])==0)
                    if (input[1].CompareTo(users[a,1])==0)
                    {
                        if (users[a, 2].CompareTo("manager") == 0)
                            Main.manager = true;
                        Main.validUser = true;
                        int[] tempIndex = {0,1};
                        Main.updateRooms();
                        this.Close();
                        break;
                    }
            }
        }
        
        public void databaseCon()
        {
           /* string sql;
             SqlCommand command;

             string connetionString = null;
             SqlConnection conn;
             connetionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=C:\Users\cmestudent.CME\Desktop\CIS487kgilbe\TestWebForms\TestWebForms\TestWebForms\App_Data\aspnet-TestWebForms-20150302012141_log.ldf;Initial Catalog=aspnet-TestWebForms-20150302012141;Integrated Security=True";
             conn = new SqlConnection(connetionString);
             sql = "";
                  try
                  {
                      conn.Open();
                      //test.Text = "Connection Open ! ";
                      command = new SqlCommand(sql, conn);
                      SqlDataReader data = command.ExecuteReader();
                      while (data.Read())
                      {
                          //test.Text += data.GetValue(0);
                      }
                      conn.Close();
                  }
                  catch (Exception ex)
                  {
                     // test.Text = "Can not open connection ! ";
                  }
              
            */
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            input[1] = this.textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            input[0] = this.textBox2.Text;
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
        }
    }
}
