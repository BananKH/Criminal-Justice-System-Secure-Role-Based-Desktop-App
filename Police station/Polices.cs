using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Net.Http;//For API
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using BCrypt.Net;

namespace Police_station
{
    public partial class Polices : Form
    {
        private string apiUrl = "https://worldtimeapi.org/api/ip";
        private string connectionString = ConfigurationManager.ConnectionStrings["ConAdmin"].ConnectionString;
        private DateTime lastActivityTime;
        private Timer inactivityTimer; // Declare the Timer variable
        private string usernameBD;
        public Polices(string usernameBD)
        {
            InitializeComponent();
            this.usernameBD = usernameBD;
            InitializeAsync();
            showPolice();
        }

        //string connectionString = ConfigurationManager.ConnectionStrings["ConAdmin"].ConnectionString;
        private async void InitializeAsync()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "SELECT attemptTime FROM loginattempts WHERE username = @Username";

                    MySqlCommand command = new MySqlCommand(query, con);
                    command.Parameters.AddWithValue("@Username", usernameBD);

                    await con.OpenAsync();
                    var loginTime = await command.ExecuteScalarAsync();

                    if (loginTime != null && loginTime != DBNull.Value)
                    {
                        lastActivityTime = Convert.ToDateTime(loginTime);

                        // Start the timer to periodically check for inactivity
                        StartInactivityTimer();
                    }
                    else
                    {
                        // Handle if login time is not available
                        MessageBox.Show("Login time not found!");
                        // You might want to perform logout or other actions here
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void StartInactivityTimer()
        {

            inactivityTimer = new Timer();
            inactivityTimer.Interval = 60000; // Check every minute
            inactivityTimer.Tick += async (s, ev) => { await CheckInactivity(); };
            inactivityTimer.Start();
        }

        private async Task CheckInactivity()
        {
            try
            {
                // Get the current timestamp from the World Time API
                DateTime currentTimestamp = await GetCurrentTimestampAsync();

                // Define the inactivity timeout duration (e.g., 1 minute)
                TimeSpan inactivityDuration = currentTimestamp - lastActivityTime;
                TimeSpan timeoutDuration = TimeSpan.FromMinutes(1);

                // Check if the duration of inactivity exceeds the timeout duration
                if (inactivityDuration >= timeoutDuration)
                {
                    // Perform logout action
                    MessageBox.Show("Your session has timed out due to inactivity.", "Session Timeout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task<DateTime> GetCurrentTimestampAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                        DateTime timestamp = Convert.ToDateTime(result.datetime);
                        return timestamp;
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve timestamp from API.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Return current time if API request fails
            return DateTime.Now;
        }
        private async Task UpdateLastActivityTime()
        {
            // Fetch the last activity time from the database and update it
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "SELECT attemptTime FROM loginattempts WHERE username = @Username";

                    MySqlCommand command = new MySqlCommand(query, con);
                    command.Parameters.AddWithValue("@Username", usernameBD);

                    await con.OpenAsync();
                    var loginTime = await command.ExecuteScalarAsync();

                    if (loginTime != null && loginTime != DBNull.Value)
                    {
                        lastActivityTime = Convert.ToDateTime(loginTime);
                    }
                    else
                    {
                        // Handle if login time is not available
                        MessageBox.Show("Login time not found!");
                        // You might want to perform logout or other actions here
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Logout()
        {
            Login loginForm = new Login();
            loginForm.Show();
            RestartTimer();
            this.Close(); // Close the current form
        }

        // Event handler for any button click
        private async void AnyButton_Click(object sender, EventArgs e)
        {
            // Call the RestartTimer method whenever any button is clicked
            RestartTimer();

            // Update the last activity time whenever any button is clicked
            await UpdateLastActivityTime();
        }

        // Method to restart the inactivity timer
        private async void RestartTimer()
        {
            // Stop the timer
           inactivityTimer.Stop();

            // Restart the timer
           inactivityTimer.Start();
        }
        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void showPolice()
        {
            string query = "SELECT role, name, address, phone, password FROM employees";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    MySqlCommand command = new MySqlCommand(query, con);
                    MySqlDataAdapter sda = new MySqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    policesView.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        int Key = 1;

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (policesView.SelectedRows.Count > 0)
            {
                var selectedRow = policesView.SelectedRows[0];

                if (selectedRow.Cells.Count >= 5)
                {
                    roleDB.SelectedItem = selectedRow.Cells[0].Value?.ToString();
                    nameDB.Text = selectedRow.Cells[1].Value?.ToString();
                    addressDB.Text = selectedRow.Cells[2].Value?.ToString();
                    phoneDB.Text = selectedRow.Cells[3].Value?.ToString();
                    passwordDB.Text = selectedRow.Cells[4].Value?.ToString();

                    if (int.TryParse(selectedRow.Cells[0].Value?.ToString(), out int key))
                    {
                        Key = key;
                    }
                    else
                    {
                        Key = 0;
                    }

                    AnyButton_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Selected row does not contain the expected number of cells.");
                }
            }
            else
            {
                MessageBox.Show("No row selected.");
            }
        }


        private void Reset()
        {
            addressDB.Text = "";
            nameDB.Text = "";
            roleDB.SelectedIndex = -1;
            phoneDB.Text = "";
            passwordDB.Text = "";
            Key = 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Generate a random salt
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);

            // Hash the password with the salt
            string hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(passwordDB.Text + salt);

            // Your existing code for inserting into the database
            string query = "INSERT INTO employees(role, name, address, phone, password, salt, firstlogin) VALUES(@role, @name, @add, @phone, @pass, @salt, 1)";

            if (string.IsNullOrWhiteSpace(roleDB.Text) || string.IsNullOrWhiteSpace(nameDB.Text) || string.IsNullOrWhiteSpace(addressDB.Text) || string.IsNullOrWhiteSpace(phoneDB.Text) || string.IsNullOrWhiteSpace(passwordDB.Text))
            {
                MessageBox.Show("Missing Information");
                return;
            }

            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand(query, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@role", roleDB.SelectedItem);
                    command.Parameters.AddWithValue("@name", nameDB.Text);
                    command.Parameters.AddWithValue("@add", addressDB.Text);
                    command.Parameters.AddWithValue("@phone", phoneDB.Text);
                    command.Parameters.AddWithValue("@pass", hashedPassword); // Use the hashed password
                    command.Parameters.AddWithValue("@salt", salt); // Store the salt in the database
                    MessageBox.Show(salt);
                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Information recorded successfully");
                        showPolice();
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert data into the database");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            AnyButton_Click(sender, e); // Call AnyButton_Click to update last activity time
        }


        int key = 0;
     


        private void nameDB_TextChanged(object sender, EventArgs e)
        {
        }

        private void deleteDB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameDB.Text))
            {
                MessageBox.Show("Select a Police officer!");
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("DELETE FROM employees WHERE name=@Name", connection);
                    command.Parameters.AddWithValue("@Name", nameDB.Text);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Police Deleted!");
                        showPolice();
                    }
                    else
                    {
                        MessageBox.Show("Police not found with the provided name.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            AnyButton_Click(sender, e);
        }


        private void editDB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(roleDB.Text) || string.IsNullOrWhiteSpace(nameDB.Text) || string.IsNullOrWhiteSpace(addressDB.Text) || string.IsNullOrWhiteSpace(phoneDB.Text) || string.IsNullOrWhiteSpace(passwordDB.Text))
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();
                        MySqlCommand command = new MySqlCommand("UPDATE employees SET role=@role, address=@add, phone=@phone, password=@pass WHERE name=@name", con);
                        command.Parameters.AddWithValue("@role", roleDB.Text);
                        command.Parameters.AddWithValue("@add", addressDB.Text);
                        command.Parameters.AddWithValue("@phone", phoneDB.Text);
                        command.Parameters.AddWithValue("@pass", passwordDB.Text);
                        command.Parameters.AddWithValue("@name", nameDB.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Police Updated!");
                        showPolice();
                        Reset();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            AnyButton_Click(sender, e);
        }


        private void roleDB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        { 
                criminal investigatorForm = new criminal(usernameBD);
                investigatorForm.Show();
                this.Hide();
           
        }

        private void label5_Click(object sender, EventArgs e)
        {
            cases casesForm = new cases(usernameBD);
            casesForm.Show();
            this.Hide();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            forensics forensicsForm = new forensics(usernameBD);
            forensicsForm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Polices PolicesForm = new Polices(usernameBD);
            PolicesForm.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Polices_Load(object sender, EventArgs e)
        {

        }
    }
}
