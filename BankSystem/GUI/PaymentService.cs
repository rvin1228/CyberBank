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
    public partial class PaymentService : Form
    {
        public PaymentService()
        {
            InitializeComponent();
            pictureBox1.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();
            pictureBox6.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1 || textBox1.Text == "")
            {
                MessageBox.Show("Please select a service and enter an account number.", "Error");
            }
            else
            {
                (new PayMents(listBox1.Text)).ShowDialog();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaymentService_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex == 0)
            {
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox4.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();

                pictureBox1.Show();
            }
            else if(listBox1.SelectedIndex == 1)
            {
                pictureBox1.Hide();
                pictureBox3.Hide();
                pictureBox4.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();

                pictureBox2.Show();
            }
            else if(listBox1.SelectedIndex == 2)
            {
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox4.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();

                pictureBox3.Show();
            }
            else if(listBox1.SelectedIndex == 3)
            {
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();

                pictureBox4.Show();
            }
            else if(listBox1.SelectedIndex == 4)
            {
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox4.Hide();
                pictureBox6.Hide();

                pictureBox5.Show();
            }
            else if(listBox1.SelectedIndex == 5)
            {
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox4.Hide();
                pictureBox5.Hide();

                pictureBox6.Show();
            }
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
