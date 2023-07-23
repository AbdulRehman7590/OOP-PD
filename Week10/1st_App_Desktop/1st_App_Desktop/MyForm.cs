using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1st_App_Desktop
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddValues()
        {
            if (value.Text.Length == 0 || value2.Text.Length == 0) return;
            string one = v1.Text;
            string two = v2.Text;

            double result = double.Parse(one) + double.Parse(two);
            resultLabel.Text = result.ToString();
        }

        private void SubtractValues()
        {
            if (value.Text.Length == 0 || value2.Text.Length == 0) return;
            string one = v1.Text;
            string two = v2.Text;

            double result = double.Parse(one) - double.Parse(two);
            resultLabel.Text = result.ToString();
        }

        private void MultiplyValues()
        {
            if (value.Text.Length == 0 || value2.Text.Length == 0) return;
            string one = v1.Text;
            string two = v2.Text;

            double result = double.Parse(one) * double.Parse(two);
            resultLabel.Text = result.ToString();
        }

        private void DivideValues()
        {
            if (value.Text.Length == 0 || value2.Text.Length == 0) return;
            string one = v1.Text;
            string two = v2.Text;

            double result = double.Parse(one) / double.Parse(two);
            resultLabel.Text = result.ToString();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddValues();
        }

        private void Subtract_Click(object sender, EventArgs e)
        {
            SubtractValues();
        }

        private void Multiply_Click(object sender, EventArgs e)
        {
            MultiplyValues();
        }

        private void Division_Click(object sender, EventArgs e)
        {
            DivideValues();
        }
    }
}
