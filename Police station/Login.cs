using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Police_station
{
    public partial class Login : Form
    {
        private string apiUrl = "https://worldtimeapi.org/api/ip";
        string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        private Task<string> lastActivityTimestamp;

        public Login()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            lastActivityTimestamp = GetCurrentTimestamp();
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void password_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            UserSession.Username = Text;
        }

        private void pictureBox2_Click(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string loggedInUsername;

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameDB.Text) || string.IsNullOrWhiteSpace(passwordDB.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT role, password, salt, firstlogin FROM employees WHERE name=@username";

            string role = string.Empty; // Initialize role variable
            string currentConnectionString; // Initialize connection string variable

            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", usernameDB.Text);

                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve role from the database query result
                            role = reader["role"].ToString();
                            string storedPasswordHash = reader["password"].ToString();
                            string salt = reader["salt"] == DBNull.Value ? string.Empty : reader["salt"].ToString();
                            bool firstlogin = reader["firstlogin"] == DBNull.Value ? true : Convert.ToBoolean(reader["firstlogin"]);

                            loggedInUsername = usernameDB.Text;
                            LogLoginAttempt(usernameDB.Text);
                            LogActivity();

                            // Determine the connection string based on the role
                            if (role == "Admin")
                            {
                                currentConnectionString = ConfigurationManager.ConnectionStrings["ConAdmin"].ConnectionString;
                            }
                            else
                            {
                                currentConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                            }

                            // Verify the entered password against the stored hash with salt
                            if (!BCrypt.Net.BCrypt.EnhancedVerify(passwordDB.Text + salt, storedPasswordHash))
                            {
                                MessageBox.Show("Username or Password is incorrect.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                if (firstlogin)
                                {
                                    MessageBox.Show("This is your first login. Please reset your password.");
                                    resetPas Obj = new resetPas(loggedInUsername);
                                    Obj.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    // Redirect the user based on their role
                                    switch (role)
                                    {
                                        case "Admin":
                                            Polices adminForm = new Polices(loggedInUsername); 
                                            adminForm.Show();
                                            this.Hide();
                                            break;

                                        case "Investigator":
                                            criminal investigatorForm = new criminal(loggedInUsername);
                                            investigatorForm.Show();
                                            this.Hide();
                                            break;

                                        case "Police Officer":
                                           
                                            cases officerForm = new cases(loggedInUsername);
                                            officerForm.Show();
                                            this.Hide();
                                            break;

                                        case "Forensic Expert":
                                            forensics forensicForm = new forensics(loggedInUsername);
                                            forensicForm.Show();
                                            this.Hide();
                                            break;

                                        default:
                                            MessageBox.Show("Role not recognized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username or Password is incorrect.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private async Task<string> GetCurrentTimestamp()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    dynamic responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);
                    return responseObject.datetime;
                }
                else
                {
                    throw new Exception("Failed to fetch current time from API.");
                }
            }
        }

        private async void LogActivity()
        {
            lastActivityTimestamp = GetCurrentTimestamp();
        }

        private async void LogLoginAttempt(string username)
        {
            try
            {
                string currentTime = await GetCurrentTimestamp();
                string logQuery = "INSERT INTO LoginAttempts (Username, AttemptTime) VALUES (@username, @attemptTime) ON DUPLICATE KEY UPDATE attemptTime = @attemptTime";

                using (var connection = new MySqlConnection(connectionString))
                using (var command = new MySqlCommand(logQuery, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@attemptTime", currentTime);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving login attempt: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e) { }

        private void passwordDB_TextChanged(object sender, EventArgs e) { }
    }
}
