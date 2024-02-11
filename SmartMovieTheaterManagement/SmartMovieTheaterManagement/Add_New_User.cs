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
    public partial class Add_New_User : Form
    {
        public Add_New_User()
        {
            InitializeComponent();
        }

        private void Sign_Up_001_Click(object sender, EventArgs e)
        {
            string contactNumber = txtContactNumber.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (!string.IsNullOrEmpty(contactNumber) && !string.IsNullOrEmpty(password))
            {
                SaveContact(contactNumber, password);
                MessageBox.Show("Contact saved successfully.");
            }
            else
            {
                MessageBox.Show("Please enter both contact number and password.");
            }
        }

        private void SaveContact(string contactNumber, string password)
        {
            string folderPath = @"C:\SMTM\Users\"+contactNumber; // Change the folder path as needed
            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, contactNumber + ".txt");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(contactNumber);
                writer.WriteLine(password);
            }
        }
    }
}
