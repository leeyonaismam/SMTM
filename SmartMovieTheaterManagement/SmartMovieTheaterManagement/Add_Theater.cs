using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMARTMOVIETHEATERMANAGEMENT
{
    public partial class Add_Theater : Form
    {

        public Admin_Login admin_login = new Admin_Login();

        string adminIDFinal = Admin_Login.adminID;
        public Add_Theater()
        {
            InitializeComponent();
        }

        private void Add_Theater_Button_Click(object sender, EventArgs e)
        {
            string theaterName = txtTheaterName.Text.Trim();
            string contact = txtContact.Text.Trim();
            string location = txtLocation.Text.Trim();

            if (!string.IsNullOrEmpty(theaterName) && !string.IsNullOrEmpty(contact) && !string.IsNullOrEmpty(location))
            {
                SaveTheater(adminIDFinal, theaterName, contact, location, "---", "0");
                MessageBox.Show("Theater saved successfully.");
            }
            else
            {
                MessageBox.Show("Please enter all the information.");
            }
        }

        private void Admin_Panel_Click(object sender, EventArgs e)
        {
            Admin_Panel Admin_Panel = new Admin_Panel();
            Admin_Panel.Show();
            this.Hide();
        }

        private void SaveTheater(string adminID, string theaterName, string contact, string location, string movieName, string numberOfBookings)
        {
            string folderPath = @"C:\SMTM\Theater"; // Change the folder path as needed
            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, theaterName + ".txt");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(adminID);
                writer.WriteLine(theaterName);
                writer.WriteLine(contact);
                writer.WriteLine(location);
                writer.WriteLine(movieName);
                writer.WriteLine(numberOfBookings);
            }
        }

        private void Login_Back_Click(object sender, EventArgs e)
        {
            User_Login User = new User_Login();
            User.Show();
            this.Hide();
        }
    }
}
