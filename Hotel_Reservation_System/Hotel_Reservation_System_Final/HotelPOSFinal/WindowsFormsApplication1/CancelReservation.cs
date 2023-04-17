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
    public partial class CancelReservation : Form
    {
        public CancelReservation()
        {
            InitializeComponent();
        }

        private void CancelReservation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string roomID = textBox1.Text;
            string SQL = "UPDATE Room SET Availability='Vacant',  StartDate=NULL, EndDate=NULL, ID=NULL WHERE RoomID='" + roomID + "'";
            Main.databaseCon(SQL);
            Main.updateRooms();
        }

       
    }
}
