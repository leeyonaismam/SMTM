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
    public partial class Admin_Login : Form
    {
        public static string adminID;
        public Admin_Login()
        {
            InitializeComponent();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

                            adminID = storedContactNumber;

                            Admin_Panel Admin_Panel = new Admin_Panel();
                            Admin_Panel.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid contact number or password. Login failed.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Admin Doesn't Exist");
                }
            }
            else
            {
                MessageBox.Show("Please Enter A Contact Number");
            }
        }

        private string SearchFile(string fileName)
        {
            string folderPath = @"C:\SMTM\Admin";
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
