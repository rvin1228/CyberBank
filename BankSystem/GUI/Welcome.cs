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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = 1500;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
            this.progressBar1.Increment(1500);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
