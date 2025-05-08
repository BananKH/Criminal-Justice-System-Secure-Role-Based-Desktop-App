using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Net.Http;//For API
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Police_station
{

    public partial class criminal : Form
    {
        private string apiUrl = "https://worldtimeapi.org/api/ip";
        private string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        private DateTime lastActivityTime;
        private Timer inactivityTimer; // Declare the Timer variable
        private string usernameBD;
        public criminal(string usernameBD)
        {
            InitializeComponent();
            this.usernameBD = usernameBD;
            ShowCriminals();
            InitializeAsync();
        }

        // Fetch the connection string from the configuration file
        //  string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

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

                // Define the inactivity timeout duration (e.g., 5 minutes)
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
            // Close the current form (criminal form)
            this.Close();

            // Show the login form
            Login loginForm = new Login();
            loginForm.Show();

            // Restart the timer
            RestartTimer(); 
        }
        private async void AnyButton_Click(object sender, EventArgs e)
        {
            // Call the RestartTimer method whenever any button is clicked
            RestartTimer();

            // Update the last activity time whenever any button is clicked
            await UpdateLastActivityTime();
        }

        private async void RestartTimer()
        {
            // Stop the timer
            inactivityTimer.Stop();

            // Restart the timer
            inactivityTimer.Start();
        }

        private void criminal_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e) // add a new criminal record 
        {
            if (string.IsNullOrWhiteSpace(NameTB.Text) || string.IsNullOrWhiteSpace(AddressTB.Text) || string.IsNullOrWhiteSpace(ActivitiesTB.Text))
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    using (var Con = new MySqlConnection(connectionString))
                    {
                        Con.Open();

                        MySqlCommand cmd = new MySqlCommand("INSERT INTO `criminal_table` (`CrName`, `CrAdd`, `CrActivities`) VALUES (@CN, @CA, AES_ENCRYPT(@CrA, (SELECT `KeyValue` FROM `sch-windows`.`encryptionkeys` WHERE `KeyID` = 1)))", Con);
                        cmd.Parameters.AddWithValue("@CN", NameTB.Text);
                        cmd.Parameters.AddWithValue("@CA", AddressTB.Text);
                        cmd.Parameters.AddWithValue("@CrA", ActivitiesTB.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Criminal Recorded!");
                        ShowCriminals();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                }
            }
            AnyButton_Click(sender, e); // Call AnyButton_Click to update last activity time
        }

        private void ShowCriminals()
        {
            try
            {
                using (var Con = new MySqlConnection(connectionString))
                {
                    Con.Open();
                    string Query = "SELECT `CrName`, `CrAdd`, CAST(AES_DECRYPT(`CrActivities`, (SELECT `KeyValue` FROM `sch-windows`.`encryptionkeys` WHERE `KeyID` = 1)) AS CHAR) AS `CrActivities` FROM `criminal_table`";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(Query, Con);
                    MySqlCommandBuilder Builder = new MySqlCommandBuilder(adapter);
                    var ds = new DataSet();
                    adapter.Fill(ds);
                    CriminalsTB.DataSource = ds.Tables[0];
                    Con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CriminalsTB.SelectedRows.Count > 0)
            {
                NameTB.Text = CriminalsTB.SelectedRows[0].Cells[0].Value.ToString();
                AddressTB.Text = CriminalsTB.SelectedRows[0].Cells[1].Value.ToString();
                // ActivitiesTB.Text = CriminalsTB.SelectedRows[0].Cells[2].Value.ToString(); // Assuming this is needed

                if (string.IsNullOrWhiteSpace(NameTB.Text))
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(CriminalsTB.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
            AnyButton_Click(sender, e); // Call AnyButton_Click to update last activity time
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            AnyButton_Click(sender, e); // Call AnyButton_Click to update last activity time
        }

        private void CriminalsTB_TextChanged(object sender, EventArgs e) { }

        private void NameTB_TextChanged(object sender, EventArgs e) { }

        private void criminal_Load_1(object sender, EventArgs e) { }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e) { }

        private void AddressTB_TextChanged(object sender, EventArgs e) { }

        private void label6_Click(object sender, EventArgs e) { }

        private void label8_Click(object sender, EventArgs e) {
            
        }

        private void label7_Click(object sender, EventArgs e) {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "SELECT role FROM employees WHERE name = @Username";

                    MySqlCommand command = new MySqlCommand(query, con);
                    command.Parameters.AddWithValue("@Username", usernameBD);

                    con.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string role = result.ToString();
                        if (role == "Admin")
                        {
                            Polices PolicesForm = new Polices(usernameBD);
                            PolicesForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            // User is not an admin
                            MessageBox.Show("You are not an admin.");
                        }
                    }
                    else
                    {
                        // User not found
                        MessageBox.Show("User not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ActivitiesTB_TextChanged(object sender, EventArgs e) { }

        private void EditBTN_Click(object sender, EventArgs e) { }

        private void EditBTN_Click_1(object sender, EventArgs e)
        {
            AnyButton_Click(sender, e); // Call AnyButton_Click to update last activity time
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "SELECT role FROM employees WHERE name = @Username";

                    MySqlCommand command = new MySqlCommand(query, con);
                    command.Parameters.AddWithValue("@Username", usernameBD);

                    con.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string role = result.ToString();
                        if (role == "Admin")
                        {
                            cases casesForm = new cases(usernameBD);
                            casesForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            // User is not an admin
                            MessageBox.Show("You are not an admin.");
                        }
                    }
                    else
                    {
                        // User not found
                        MessageBox.Show("User not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "SELECT role FROM employees WHERE name = @Username";

                    MySqlCommand command = new MySqlCommand(query, con);
                    command.Parameters.AddWithValue("@Username", usernameBD);

                    con.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string role = result.ToString();
                        if (role == "Admin")
                        {
                            forensics forensicsForm = new forensics(usernameBD);
                            forensicsForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            // User is not an admin
                            MessageBox.Show("You are not an admin.");
                        }
                    }
                    else
                    {
                        // User not found
                        MessageBox.Show("User not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

