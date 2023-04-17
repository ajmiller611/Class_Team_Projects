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
    public partial class UpdatePricing : Form
    {
        Boolean goodPrice = false;
        Boolean CB1 = false;
        Boolean CB2 = false;
        String QorK = null;
        double newPrice = 0;
        Boolean OVorNOV; 
        public UpdatePricing()
        {
            InitializeComponent();
        }

        private void UpdatePricing_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            QorK = this.comboBox1.GetItemText(this.comboBox1.Items[this.comboBox1.SelectedIndex]);
            CB1 = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox2.GetItemText(this.comboBox2.Items[this.comboBox2.SelectedIndex]) == "Oceanview")
            { OVorNOV = true; CB2 = true; }
            else
            { OVorNOV = false; CB2 = true; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String temp = this.textBox1.Text;
            
            double.TryParse(temp, out newPrice);
            if (newPrice > 50.0 && newPrice < 200.0)
                goodPrice = true;
            else
                goodPrice = false;

        }

        private void TextBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.SelectionStart = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(goodPrice && CB1 && CB2)
            {
                string SQL = "UPDATE Room SET Price='"+newPrice+"' WHERE OceanView='" +OVorNOV+ "' AND Beds ='1 " +QorK+ "'";
                Main.databaseCon(SQL);
                Main.updateRooms();
            }
        }

    }
}
