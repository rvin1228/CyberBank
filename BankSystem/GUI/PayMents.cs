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
    public partial class PayMents : Form
    {
        static public long Value;
        static public string Pay;
        public PayMents(string Title)
        {
            InitializeComponent();
            this.Text = Title;
            this.label1.Text = Title;
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckInput(string x) //Checks if balance is valid
        {
            if (x.Length < 1) return false;
            for (int i = 0; i < x.Length; ++i)
            {
                if (!(x[i] >= '0' && x[i] <= '9')) return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckInput(Amount.Text) && Amount.Text != "0")
            {
                Value = Int64.Parse(Amount.Text);
                if(this.Text == "Deposit")
                {
                    AccInfo.Current.Am += Int32.Parse(Amount.Text); //Adds the input amount to current balance
                    MessageBox.Show("Your deposit request has been procesed!", "Confirm");
                    this.Close();
                }
                else
                {
                    if(AccInfo.Current.Am < Int32.Parse(Amount.Text))
                    {
                        MessageBox.Show("Sorry, your deposit request cannot be processed. Please try again.", "Error");
                    }
                    else
                    {
                        if(this.Text == "Withdrawal")
                        {
                            AccInfo.Current.Am -= Int32.Parse(Amount.Text);
                            MessageBox.Show("Your withdrawal request has been processed!", "Confirm");
                            this.Close();
                        }
                        else if(this.Text == "Transfer")
                        {
                            (new TransferMoney(Int32.Parse(Amount.Text))).ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            Pay = this.Text;
                            AccInfo.Current.Am -= Int32.Parse(Amount.Text);
                            MessageBox.Show("Your payment request has been processed!", "Confirm");
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid value!", "Error");
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {

        }

        protected override void WndProc(ref Message m) //Function to make form movable
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
    }
}
