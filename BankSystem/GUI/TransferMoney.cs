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
    public partial class TransferMoney : Form
    {
        int Transfer;
        public TransferMoney(int n)
        {
            InitializeComponent();
            Transfer = n;
        }

        private void Transfer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AccInfo.Transfer(InTransfer.Text, Transfer))
            {
                AccInfo.Current.Am -= Transfer;
                MessageBox.Show("Your transfer money has been processed!", "Confirm");
                this.Close();
            }
            else
            {
                MessageBox.Show("Sorry, we cannot find the email to our system!", "Error");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
