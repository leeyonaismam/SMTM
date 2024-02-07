using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMARTMOVIETHEATERMANAGEMENT
{
    public partial class Admin_Login : Form
    {
        public Admin_Login()
        {
            InitializeComponent();
        }


        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
