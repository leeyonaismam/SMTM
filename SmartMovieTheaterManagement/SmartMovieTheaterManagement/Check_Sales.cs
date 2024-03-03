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
    public partial class Check_Sales : Form
    {
        public Admin_Login admin_login = new Admin_Login();

        string adminIDFinal = Admin_Login.adminID;

        List<string> matchingFiles = new List<string>();
        public Check_Sales()
        {
            InitializeComponent();

            string directoryPath = @"C:\SMTM\Theater";
            string variableToMatch = adminIDFinal;

            try
            {
                string[] files = Directory.GetFiles(directoryPath);

                foreach (string file in files)
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        string firstLine = reader.ReadLine();
                        if (firstLine != null && firstLine.Trim() == variableToMatch)
                        {
                            matchingFiles.Add(file);
                            Choose_Theater.Items.Add(Path.GetFileName(file));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Admin_Panel_Button_Click(object sender, EventArgs e)
        {
            Admin_Panel Admin_Panel = new Admin_Panel();
            Admin_Panel.Show();
            this.Hide();
        }

        private void Choose_Theater_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Load the content of the selected file
                string selectedFileName = matchingFiles[Choose_Theater.SelectedIndex];
                string[] lines = File.ReadAllLines(selectedFileName);

                // Ensure that there are at least 5 lines in the file
                if (lines.Length >= 5)
                {
                    // Display the 5th line in the TextBox
                    Booking_Sold_Text.Text = lines[5];
                }
                else
                {
                    Booking_Sold_Text.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
