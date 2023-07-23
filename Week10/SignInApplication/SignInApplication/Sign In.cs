using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignInApplication
{
    public partial class Sign_In : Form
    {
        public Sign_In()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form moreform = new SignApplication();
            moreform.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form moreform = new SignApplication();
            moreform.Show();
            this.Hide();
        }

        private void Sign_In_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Sign_In_Load(object sender, EventArgs e)
        {

        }
    }
}
