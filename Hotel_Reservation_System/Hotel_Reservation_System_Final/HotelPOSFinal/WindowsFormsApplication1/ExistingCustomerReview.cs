using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ExistingCustomerReview : Form
    {
        public ExistingCustomerReview()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string roomID = textBox1.Text;
            string SQL = "UPDATE Room SET CheckedIn = '"+true+"' WHERE RoomID='" + roomID + "'";
            Main.databaseCon(SQL);
            Main.updateRooms();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string roomID = textBox1.Text;
            string SQL = "UPDATE Room SET CheckedIn = '" + false + "' WHERE RoomID='" + roomID + "'";
            Main.databaseCon(SQL);
            Main.updateRooms();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
