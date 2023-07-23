using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem_01
{
    public partial class Form1 : Form
    {
        private List<string> DataList = new List<string>() { "--Please Select--", "Text1", "Text2", "Text3", "Text4", "Text5"};

        public Form1()
        {
            InitializeComponent();
            DataBind();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt1.Text = comboBox1.SelectedItem.ToString();
            if (comboBox1.SelectedIndex == 0)
            {
                txt1.Text = null;
            }
        }

        private void DataBind()
        {
            comboBox1.DataSource = null;
            comboBox1.DataSource = DataList;
            comboBox1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt1.Text = null;
        }
    }
}
