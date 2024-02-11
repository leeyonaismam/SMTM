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
    public partial class User_Login : Form
    {
        public User_Login()
        {
            InitializeComponent();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Admin_Login_Button_Click(object sender, EventArgs e)
        {
            Admin_Login Admin = new Admin_Login();
            Admin.Show();
            this.Hide();
        }

        private void User_Sign_Up_Click(object sender, EventArgs e)
        {
            Add_New_User Add_New_User = new Add_New_User();
            Add_New_User.Show();
            this.Hide();
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            string fileName = txtContactNumber.Text.Trim();

            if (!string.IsNullOrEmpty(fileName))
            {
                string filePath = SearchFile(fileName + ".txt");

                if (!string.IsNullOrEmpty(filePath))
                {
                    string[] credentials = ReadCredentials(filePath);

                    if (credentials != null)
                    {
                        string storedContactNumber = credentials[0];
                        string storedPassword = credentials[1];

                        string enteredContactNumber = txtContactNumber.Text.Trim();
                        string enteredPassword = txtPassword.Text.Trim();

                        if (enteredContactNumber == storedContactNumber && enteredPassword == storedPassword)
                        {
                            MessageBox.Show("Login successful!");
                        }
                        else
                        {
                            MessageBox.Show("Invalid contact number or password. Login failed.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("User Doesn't Exist");
                }
            }
            else
            {
                MessageBox.Show("Please Enter A Contact Number");
            }
        }

            private string SearchFile(string fileName)
            {
                string folderPath = @"C:\SMTM\Users";
                string[] files = Directory.GetFiles(folderPath, fileName, SearchOption.AllDirectories);
                Console.WriteLine(files);
                if (files.Length > 0)
                {
                    return files[0]; // Assuming only one file with the given name exists
                }
                else
                {
                    return null;
                }
            }

            private string[] ReadCredentials(string filePath)
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    return lines;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error reading file.");
                    return null;
                }
            }
        }
}
