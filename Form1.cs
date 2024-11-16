using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Text.Json;
using System.Data.SQLite;


namespace encrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string crypt(string value)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter a password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string username = txtUsername.Text;
                string encryptedPassword = crypt(txtPassword.Text);
                label3.Text = encryptedPassword;
                string filePath = "C:\\Users\\spham\\OneDrive - UNIVERSITATEA ROMANO-AMERICANA\\Apps\\App CSE - Currency conversion\\encrypt\\encrypt.txt";
                string connectionString = "Data Source=\"C:\\Users\\spham\\OneDrive - UNIVERSITATEA ROMANO-AMERICANA\\Apps\\App CSE - Currency conversion\\encrypt\\sql for encrypt.db\";Version=3;";
                try
                {
                    // Write the encrypted password to the file
                    File.WriteAllLinesAsync(filePath, new string[] { "Username:", username, "Password", encryptedPassword });
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";

                        using (SQLiteCommand command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@Password", encryptedPassword);

                            command.ExecuteNonQuery();
                        }
                    }

                
                    MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                catch (Exception ex)
                {
                    MessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }   
        
}


