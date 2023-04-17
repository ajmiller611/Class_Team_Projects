using System;
using System.Collections;
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
   
    public partial class newTransaction : Form
    {
        List<String> NTRoomList = new List<String>();
        ArrayList NTRoomArrayList = new ArrayList();
        Double price = 0.0;
        Double totalPrice = 0.0;
        public void updateVacantRooms()
        {
            int[] indexForRoomArrayList = new int[2];
            indexForRoomArrayList[0] = 0;
            indexForRoomArrayList[1] = 3;
            String sql = "SELECT * FROM ROOM";
            NTRoomArrayList = Main.databaseCon(sql, indexForRoomArrayList);
            NTRoomList = NTRoomArrayList.Cast<String>().ToList();
            this.listBox1.DataSource = NTRoomList;
        }

        public void updateVacantRooms(int index)
        {
            int[] indexForRoomArrayList = new int[2];
            indexForRoomArrayList[0] = 0;
            indexForRoomArrayList[1] = 3;
            String sql = "SELECT * FROM ROOM";
            NTRoomArrayList = Main.databaseCon(sql, indexForRoomArrayList);
            NTRoomList = NTRoomArrayList.Cast<String>().ToList();
            this.listBox1.DataSource = NTRoomList;
            listBox1.SelectedIndex = index;
        }

        String[] customerInfo = new String[17];
        
        public newTransaction()
        {
            InitializeComponent();

            updateVacantRooms();
            for(int i = 0;i < 16;i++)
        {
        customerInfo[i] = "";
        }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewTransactionReview transactionReview = new NewTransactionReview();
            transactionReview.setCustomerInfo(customerInfo);
            transactionReview.Show();
            string SQL = "INSERT INTO AspNetUsers (UserName, ID, Email, EmailConfirmed, PhoneNumber, FirstName, LastName, Address, City, State, Zip, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES ('" + customerInfo[0] + customerInfo[1] + "','" + customerInfo[0] + customerInfo[1] + customerInfo[5] + "','" + customerInfo[7] + "','" + false + "','" + customerInfo[6] + "','" + customerInfo[0] + "','" + customerInfo[1] + "','" + customerInfo[2] + "','" + customerInfo[3] + "','" + customerInfo[4] + "','" + customerInfo[5] + "','" + false + "','" + false + "','" + false + "','" + 0 + "');";
            string SQL2 = "UPDATE Room SET Availability='Occupied',  StartDate='"+ customerInfo[8] +"', EndDate='"+customerInfo[9]+"', ID='"+customerInfo[0]+customerInfo[1]+customerInfo[5]+"' WHERE RoomID='" + customerInfo[16] + "'";
            string SQL3 = "INSERT INTO Transaction (Id, Amount) VALUES ('"+customerInfo[0]+customerInfo[1]+customerInfo[5]+"','"+ maskedTextBox8.Text +"');";
            string SQL4 = "INSERT INTO Account (id,PaymentType, CreditCardNumber) VALUES ('" + customerInfo[0] + customerInfo[1]+customerInfo[5]+ "','" + customerInfo[10] + "','" + maskedTextBox7.Text + "');";
            Console.WriteLine(SQL2);
            Console.WriteLine(SQL3);
            Console.WriteLine(SQL4);
            Main.databaseCon(SQL);
            Main.databaseCon(SQL2);
            //Main.databaseCon(SQL4);
            Main.databaseCon(SQL3);
            Main.updateRooms();
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            customerInfo[4] = this.comboBox1.GetItemText(this.comboBox1.Items[this.comboBox1.SelectedIndex]);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            customerInfo[10] = this.comboBox2.GetItemText(this.comboBox2.Items[this.comboBox2.SelectedIndex]);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            customerInfo[14] = this.comboBox3.GetItemText(this.comboBox3.Items[this.comboBox3.SelectedIndex]);
            if (customerInfo[14].Equals("Weather Discount (10%)"))
            {
                refreshPrice();
                maskedTextBox8.Text = (totalPrice * .9).ToString();
            }
            if (customerInfo[14].Equals("Extending Stay (5%)"))
            {
                refreshPrice();
                maskedTextBox8.Text = (double.Parse(maskedTextBox8.Text) * .95).ToString();
            }
                

        }

        public void refreshPrice()
        {
            string sql = "SELECT Price FROM ROOM WHERE RoomID = '" + customerInfo[16] + "';";
            int[] priceIndex = new int[1];
            priceIndex[0] = 0;
            ArrayList priceArrayList = new ArrayList();
            priceArrayList = Main.databaseCon(sql, priceIndex);
            price = double.Parse((string)priceArrayList[0]);
            totalPrice = price * (dateTimePicker2.Value - dateTimePicker1.Value).Days;
            totalPrice += price;
            maskedTextBox8.Text = totalPrice.ToString();
        }

        private void newTransaction_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            
            String temp = (string)listBox1.SelectedItem;
                customerInfo[16] = temp.Substring(0, 3);
                if (dateTimePicker2.Value > dateTimePicker1.Value)
                {
                    refreshPrice();
                }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value >= DateTime.Today)
                customerInfo[8] = dateTimePicker1.Value.ToShortDateString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value > dateTimePicker1.Value)
            {
                refreshPrice();

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox6_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox7_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox8_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox9_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox10_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox11_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox11_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBox11.SelectionStart = 0;
        }

        private void maskedTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBox1.SelectionStart = 0;
        }

        private void maskedTextBox2_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBox2.SelectionStart = 0;
        }

        private void maskedTextBox3_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBox3.SelectionStart = 0;
        }

        private void maskedTextBox4_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBox4.SelectionStart = 0;
        }

        private void maskedTextBox6_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBox6.SelectionStart = 0;
        }

        private void maskedTextBox7_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBox7.SelectionStart = 0;
        }

        private void maskedTextBox9_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBox9.SelectionStart = 0;
        }

        private void maskedTextBox10_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBox10.SelectionStart = 0;
        }

        private void maskedTextBox11_Validated(object sender, EventArgs e)
        {
            customerInfo[0] = maskedTextBox11.Text;
        }

        private void maskedTextBox1_Validated(object sender, EventArgs e)
        {
            customerInfo[1] = maskedTextBox1.Text;
        }

        private void maskedTextBox2_Validated(object sender, EventArgs e)
        {
            customerInfo[2] = maskedTextBox2.Text;
        }

        private void maskedTextBox3_Validated(object sender, EventArgs e)
        {
            customerInfo[3] = maskedTextBox3.Text;
        }

        private void maskedTextBox4_Validated(object sender, EventArgs e)
        {
            customerInfo[5] = maskedTextBox4.Text;
        }

        private void maskedTextBox5_Validated(object sender, EventArgs e)
        {
            customerInfo[6] = maskedTextBox5.Text;
        }


        private void maskedTextBox6_Validated(object sender, EventArgs e)
        {
            customerInfo[7] = maskedTextBox6.Text;
        }

        private void maskedTextBox7_Validated(object sender, EventArgs e)
        {
            customerInfo[11] = maskedTextBox7.Text;
        }

        private void maskedTextBox9_Validated(object sender, EventArgs e)
        {
            customerInfo[13] = maskedTextBox9.Text;
        }

        private void maskedTextBox10_Validated(object sender, EventArgs e)
        {
            customerInfo[15] = maskedTextBox10.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateVacantRooms(listBox1.SelectedIndex);
        }

        
        
    }
}
