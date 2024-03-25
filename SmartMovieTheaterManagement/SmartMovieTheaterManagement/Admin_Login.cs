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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            string enteredContactNumber = txtContactNumber.Text.Trim();
            string enteredPassword = txtPassword.Text.Trim();

            ReadCredentials(enteredContactNumber, enteredPassword);
        }

        private void ReadCredentials(string username, string password)
        {
            string filePath = @"C:\SMTM\Admin\AdminLogin.txt";
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts[0].Trim() == username && parts[1].Trim() == password)
                    {
                        MessageBox.Show(username + password);
                        MessageBox.Show("Login successful!");

                        Admin_Panel Admin_Panel = new Admin_Panel();
                        Admin_Panel.Show();
                        this.Hide();
                        adminID = username;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error reading file.");
                return;
            }
        }

        private void Back_User_Login_Button_Click(object sender, EventArgs e)
        {
            User_Login User_Login = new User_Login();
            User_Login.Show();
            this.Hide();
        }

        private void Main_Logo_Click(object sender, EventArgs e)
        {

        }

        private void Welcome_Text_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
