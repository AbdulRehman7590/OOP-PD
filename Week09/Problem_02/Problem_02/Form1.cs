using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Problem_02.BL;
using Problem_02.DL;

namespace Problem_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataBind();
        }

        private void DataBind()
        {
            User l1 = new User( "a", "b", "c" );
            User l2 = new User( "a", "b", "c" );
            User l3 = new User( "a", "b", "c");
            User l4 = new User( "a", "b", "c");

            UserDL.AddUserToList(l1);
            UserDL.AddUserToList(l2);
            UserDL.AddUserToList(l3);
            UserDL.AddUserToList(l4);

            gv1.DataSource = null;
            gv1.DataSource = UserDL.Users;
            gv1.Refresh();

        }

        private void Del_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
