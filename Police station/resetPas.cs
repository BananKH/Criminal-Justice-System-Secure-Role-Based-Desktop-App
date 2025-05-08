using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BCrypt.Net;

namespace Police_station
{
    public partial class resetPas : Form
    {
        private string username;

        public resetPas(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        string connectionString = ConfigurationManager.ConnectionStrings["ConAdmin"].ConnectionString;

        private void label1_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void reset_Load(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(oldPas.Text) ||
                string.IsNullOrWhiteSpace(newPas.Text) ||
                string.IsNullOrWhiteSpace(confirmPas.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (newPas.Text != confirmPas.Text)
            {
                MessageBox.Show("New passwords do not match.");
                return;
            }

            var complexPasswordRegex = new Regex("^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[#?!@$%^&*-]).{8,}$");
            if (!complexPasswordRegex.IsMatch(newPas.Text))
            {
                MessageBox.Show("Password must be at least 8 characters long and include uppercase, lowercase, number, and special character.");
                return;
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Check old password
                string checkPasswordQuery = "SELECT password, salt FROM employees WHERE name = @username";
                using (var checkCommand = new MySqlCommand(checkPasswordQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@username", username);

                    using (var reader = checkCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPasswordHash = reader["password"].ToString();
                            string salt = reader["salt"].ToString();

                            if (!BCrypt.Net.BCrypt.EnhancedVerify(oldPas.Text + salt, storedPasswordHash))
                            {
                                MessageBox.Show("Old password is incorrect.");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("User not found.");
                            return;
                        }
                    }
                }

                // Generate new salt and hash the new password
                string newSalt = BCrypt.Net.BCrypt.GenerateSalt(12);
                string newHashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(newPas.Text + newSalt);

                // Update to new password
                string updatePasswordQuery = "UPDATE employees SET password = @newPas, salt = @newSalt, firstlogin = 0 WHERE name = @username";

                using (var updateCommand = new MySqlCommand(updatePasswordQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@newPas", newHashedPassword);
                    updateCommand.Parameters.AddWithValue("@newSalt", newSalt);
                    updateCommand.Parameters.AddWithValue("@username", username);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password reset successfully.");
                        // Redirect to login or main form
                        Login loginForm = new Login();
                        loginForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to reset password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e) { }
    }
}
