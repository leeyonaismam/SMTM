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

                User_Login User_Login = new User_Login();
                User_Login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please enter both contact number and password.");
            }
        }

        private void SaveContact(string contactNumber, string password)
        {
            string folderPath = @"C:\SMTM\Users"; // Change the folder path as needed
            Directory.CreateDirectory(folderPath);

            string userInfo = $"{contactNumber}:{password}\n";
            string filePath = Path.Combine(folderPath, "UserRegistration" + ".txt");

            File.AppendAllText(filePath, userInfo);

            /*using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(contactNumber);
                writer.WriteLine(password);
            }*/
        }
    }
}
