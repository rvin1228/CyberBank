using BankSystem.Data;
using BankSystem.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            //Checks if Data.txt and Logs.txt are accessible
            string Replay = AccInfo.OpenStreams();
            if(Replay != "Opened")
            {
                MessageBox.Show(Replay, "Can't Open Data File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
            Replay = AccountLogs.OpenStreams();
            if(Replay != "Opened")
            {
                MessageBox.Show(Replay, "Can't Open Data File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
        }

        //Exit Prompt
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                if (!AccInfo.CloseStreams() || !AccInfo.CloseStreams())
                {
                    MessageBox.Show("Data File Can't Be Closed Correctly!", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Registration()).ShowDialog();
            this.Show();
        }

        //Login Verification
        private void button1_Click(object sender, EventArgs e)
        {
            if(EmLog.Text.Length < 1 || PassLog.Text.Length < 1)
            {
                MessageBox.Show("Please enter your email and password.", "Login Error");
            }
            else
            {
                if(AccInfo.LogInChecker(EmLog.Text.ToLower(), PassLog.Text))
                {
                    this.Hide();
                    (new Main()).ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Invalid email and password. Please try again.", "Login Error");
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //To load Registration Form
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            (new Registration()).ShowDialog();
            this.Show();
        }

        //Closes Program
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
