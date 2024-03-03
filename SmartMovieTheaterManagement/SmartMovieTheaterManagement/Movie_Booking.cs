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
    public partial class Movie_Booking : Form
    {

        List<string> matchingFiles = new List<string>();
        public Movie_Booking()
        {
            InitializeComponent();

            string directoryPath = @"C:\SMTM\Theater";

            try
            {
                string[] files = Directory.GetFiles(directoryPath);

                foreach (string file in files)
                {
                    matchingFiles.Add(file);
                    Choose_Theater_Booking.Items.Add(Path.GetFileName(file));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void User_Panel_Button_Click(object sender, EventArgs e)
        {
            User_Panel User = new User_Panel();
            User.Show();
            this.Hide();
        }

        private void Choose_Theater_Booking_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Load the content of the selected file
                string selectedFileName = matchingFiles[Choose_Theater_Booking.SelectedIndex];
                string[] lines = File.ReadAllLines(selectedFileName);

                // Ensure that there are at least 5 lines in the file
                if (lines.Length >= 5)
                {
                    // Display the 5th line in the TextBox
                    Movie_Name.Text = lines[4];
                }
                else
                {
                    Movie_Name.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Book_Movie_Button_Click(object sender, EventArgs e)
        {
            try
            {
                // Modify the 5th line of the file content
                string selectedFileName = matchingFiles[Choose_Theater_Booking.SelectedIndex];
                string[] lines = File.ReadAllLines(selectedFileName);
                int result;
                if (lines.Length >= 5)
                {
                    if (int.TryParse(lines[5], out result))
                    {
                        lines[5] = (result + 1).ToString();
                        int newValue = result + 1;
                        File.WriteAllLines(selectedFileName, lines);
                        MessageBox.Show($"Integer value: {newValue}");
                    }
                    else
                    {
                        MessageBox.Show("Invalid input string. Please enter a valid integer.");
                    }

                    // Write the modified content back to the file
                    

                    MessageBox.Show("Movie Booked successfully.");
                }
                else
                {
                    MessageBox.Show("Movie Can't Be Booked");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
