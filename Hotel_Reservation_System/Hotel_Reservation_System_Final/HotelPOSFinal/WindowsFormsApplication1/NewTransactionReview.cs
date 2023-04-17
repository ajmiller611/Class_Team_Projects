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
    public partial class NewTransactionReview : Form
    {
        String[] customer = new String[16];
        String customerReview = "";
        public NewTransactionReview()
        {
            
            InitializeComponent();
        }
        private void NewTransactionReview_Load(object sender, EventArgs e)
        {
            
        }
        public void setCustomerInfo(String[] input)
        {
            customer = input;
            customerReview += "Please review the follow trasnsaction details:";
            customerReview += "\nName: " + customer[0] + " " + customer[1];
            customerReview += "\nAddress: " + customer[2];
            customerReview += "\n" + customer[3] + " " + customer[4] + " " + customer[5];
            customerReview += "\nPhone number: " + customer[6];
            customerReview += "\nEmail Address: " + customer[7];
            customerReview += "\nFrom " + customer[8] + " until " + customer[9];
            customerReview += "\nPayment Type: " + customer[10];
            customerReview += "\nRoom number: " + customer[16];
            richTextBox1.Text = customerReview;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        
    }
}
