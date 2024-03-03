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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SMARTMOVIETHEATERMANAGEMENT
{
    public partial class Add_Movie : Form
    {
        public Admin_Login admin_login = new Admin_Login();

        string adminIDFinal = Admin_Login.adminID;

        List<string> matchingFiles = new List<string>();
        public Add_Movie()
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

        private void Manage_Theater_Panel_Click(object sender, EventArgs e)
        {
            Admin_Panel Admin_Panel = new Admin_Panel();
            Admin_Panel.Show();
            this.Hide();
        }

        private void Add_Movie_Button_Click(object sender, EventArgs e)
        {
            try
            {
                // Modify the 5th line of the file content
                string selectedFileName = matchingFiles[Choose_Theater.SelectedIndex];
                string[] lines = File.ReadAllLines(selectedFileName);

                if (lines.Length >= 5)
                {
                    lines[4] = Movie_Name.Text;

                    // Write the modified content back to the file
                    File.WriteAllLines(selectedFileName, lines);

                    MessageBox.Show("Movie updated successfully.");
                }
                else
                {
                    MessageBox.Show("Movie Can't Be Added");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}