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
    public partial class Add_Theater : Form
    {
        public Add_Theater()
        {
            InitializeComponent();
        }

        private void Admin_Panel_Click(object sender, EventArgs e)
        {
            Admin_Panel Admin_Panel = new Admin_Panel();
            Admin_Panel.Show();
            this.Hide();
        }
    }
}
