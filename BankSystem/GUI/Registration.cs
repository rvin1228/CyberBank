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
    public partial class Registration : Form
    {
        Random random = new Random();
        public Registration()
        {
            InitializeComponent();
            InPass.PasswordChar = '*'; //Converts the input password to asterisk
            dateTimePicker1.MinDate = new DateTime(1920, 01, 01);
            dateTimePicker1.MaxDate = new DateTime(2004, 12, 31);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        //Registration Verification Function
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (CharsChecker(InFName.Text) && CharsChecker(InLName.Text) && NumsChecker(InVisaNum.Text) && NumsChecker(InMobile.Text) && InEmail.Text.Length > 0 && InPass.Text.Length > 0 && InCountry.SelectedIndex != -1)
                {
                    if (AccInfo.Registered(InEmail.Text.ToLower()))
                    {
                        string AccNumber = Convert.ToString(random.Next(100000, Int32.MaxValue));
                        string BirthDate = dateTimePicker1.Value.ToString("MMMM dd, yyyy");
                        Account newClient = new Account(InEmail.Text, InPass.Text, AccNumber, InFName.Text, InLName.Text, InCountry.Text, BirthDate, InGender.Text, InVisaNum.Text, InMobile.Text, VIP.Checked);
                        AccInfo.AddUser(newClient);
                        MessageBox.Show("You have been registered successfully. You may now login!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("There is already an account registered to this email.");
                    }
                }
                else
                {
                    MessageBox.Show("Please correct the information provided and try again.");
                }
            }
            else
            {
                MessageBox.Show("It is required to agree to the Terms and Conditions.");
            }
        }

        //Checks if the First and Last Name are valid characters
        private bool CharsChecker(string x)
        {
            if (x.Length < 1) return false;
            for (int i = 0; i < x.Length; ++i)
            {
                if (!(x[i] >= 'A' && x[i] <= 'Z') && !(x[i] >= 'a' && x[i] <= 'z')) return false;
            }
            return true;
        }
        
        //Checks if the Visa and Mobile number are valid numbers
        private bool NumsChecker(string x)
        {
            if (x.Length < 1) return false;
            for (int i = 0; i < x.Length; ++i)
            {
                if (x[i] < '0' || x[i] > '9') return false;
            }
            return true;
        }

        //Closes the form
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Links the user for a sample look of terms and conditions
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "https://www.securitybank.com/terms-and-conditions/");
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
