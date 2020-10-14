using BankSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.GUI
{
    public partial class Main : Form
    {
        Random random = new System.Random();
        public Main()
        {
            InitializeComponent();

            //Loads the user account details of user
            Email.Text = AccInfo.Current.EM;
            ANum.Text = AccInfo.Current.AccNumber;
            FName.Text = AccInfo.Current.FName + " " + AccInfo.Current.LName;
            DOB.Text = AccInfo.Current.DOB;
            Country.Text = AccInfo.Current.Ctry;
            Mobile.Text = AccInfo.Current.Phone;
            CardNum.Text = AccInfo.Current.Visa;
            Gender.Text = AccInfo.Current.Sex;
            Balance.Text = "₱" + (AccInfo.Current.Am).ToString();
            Welcome.Text = "Welcome, " + AccInfo.Current.FName + " " + AccInfo.Current.LName + "!";
            ExchangeRate.Text = "₱ " + (AccInfo.Current.Am).ToString();
            TableIntial();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Consolas", 8, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Consolas", 8, FontStyle.Bold);
        }

        //Makes the form movable
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        //Loads the logs of the user
        public void TableIntial()
        {
            AccountLogs.GetLogs(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Deposit Function
        private void Deposit_Click(object sender, EventArgs e)
        {
            (new PayMents("Deposit")).ShowDialog();
            string Temp = "₱" + (AccInfo.Current.Am).ToString();
            if(Temp != Balance.Text)
            {
                string transac = Convert.ToString(random.Next());
                dataGridView1.Rows.Add("Deposit to the account: ", "₱" + PayMents.Value.ToString(), transac);
                AccountLogs.AddLog("Deposit to the account: ", "₱" + PayMents.Value.ToString(), transac);
                Balance.Text = Temp;
                ExchangeRate.Text = Temp;
                AccInfo.UpdateAccount();
            }
        }

        //Withdrawal Function
        private void Withdraw_Click(object sender, EventArgs e)
        {
            (new PayMents("Withdrawal")).ShowDialog();
            string Temp = "₱" + (AccInfo.Current.Am).ToString();
            if(Temp != Balance.Text)
            {
                string transac = Convert.ToString(random.Next());
                dataGridView1.Rows.Add("Withdrawal from the account: ", "₱" + PayMents.Value.ToString(), transac);
                AccountLogs.AddLog("Withdrawal from the account: ", "₱" + PayMents.Value.ToString(), transac);
                Balance.Text = Temp;
                ExchangeRate.Text = Temp;
                AccInfo.UpdateAccount();
            }
        }

        //Transfer Money Function
        private void Transfer_Click(object sender, EventArgs e)
        {
            (new PayMents("Transfer")).ShowDialog();
            string Temp = "₱" + (AccInfo.Current.Am).ToString();
            if (Temp != Balance.Text)
            {
                string transac = Convert.ToString(random.Next());
                dataGridView1.Rows.Add("Transfer money to another account: ", "₱" + PayMents.Value.ToString(), transac);
                AccountLogs.AddLog("Transfer money to another account: ", "₱" + PayMents.Value.ToString(), transac);
                Balance.Text = Temp;
                ExchangeRate.Text = Temp;
                AccInfo.UpdateAccount();
            }
        }

        //Payment Service Function
        private void Service_Click(object sender, EventArgs e)
        {
            (new PaymentService()).ShowDialog();
            string Temp = "₱" + (AccInfo.Current.Am).ToString();
            if (Temp != Balance.Text)
            {
                string transac = Convert.ToString(random.Next());
                dataGridView1.Rows.Add("Payment For " + PayMents.Pay + " : ", "₱" + PayMents.Value.ToString(), transac);
                AccountLogs.AddLog("Payment For " + PayMents.Pay + " : ", "₱" + PayMents.Value.ToString(), transac);
                Balance.Text = Temp;
                ExchangeRate.Text = Temp;
                AccInfo.UpdateAccount();

            }
        }

        //Delete the account from the system
        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete your Bank account?", "Confirmation",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AccInfo.DeleteAccount();
                this.Close();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FName_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        //Log-out Function
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirm",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        //Loads the site for Exchange Rate Website
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "http://www.bsp.gov.ph/statistics/statistics_exchrate.asp");
        }

        //Currency Conversion
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double converted;
            if (comboBox1.SelectedIndex == 0)
            {
                converted = AccInfo.Current.Am * 0.021;
                Result.Text = "$ " + Convert.ToString(converted);
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                converted = AccInfo.Current.Am * 0.017;
                Result.Text = "€ " + Convert.ToString(converted);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                converted = AccInfo.Current.Am * 1.51;
                Result.Text = "₹ " + Convert.ToString(converted);
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                converted = AccInfo.Current.Am * 0.028;
                Result.Text = "S$ " + Convert.ToString(converted);
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                converted = AccInfo.Current.Am * 0.029;
                Result.Text = "A$ " + Convert.ToString(converted);
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                converted = AccInfo.Current.Am * 0.027;
                Result.Text = "C$ " + Convert.ToString(converted);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.Time.Text = datetime.ToString();
        }
    }
}
