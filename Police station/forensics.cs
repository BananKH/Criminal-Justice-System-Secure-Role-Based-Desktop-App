using System.IO;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Net.Http;//For API
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;


namespace Police_station
{
    public partial class forensics : Form
    {

        // Initialize the connection string from App.config
        private string apiUrl = "https://worldtimeapi.org/api/ip";
        private string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        private DateTime lastActivityTime;
        private Timer inactivityTimer; // Declare the Timer variable
        private string usernameBD;
        private string loggedInUsername = UserSession.Username;

        private bool dataFetched = false; // Track whether data is fetched

        public forensics(string usernameBD)
        {
            InitializeComponent();
            this.usernameBD = usernameBD;
            InitializeAsync();

        }
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
            // Perform logout action here
            Login loginForm = new Login();
            loginForm.Show();
            RestartTimer();
            this.Close(); // Close the current form
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

        private void button2_Click(object sender, EventArgs e)
        {
            // Fetch case information based on the selected case ID
            FetchCaseInformation();

            // Show other objects related to case information
            ShowCaseInformationObjects();

            // Optionally, hide the "Fetch Data" button
            buttonRetrieve.Hide();

            // Set dataFetched flag to true
            dataFetched = true;
            AnyButton_Click(sender, e); // Call AnyButton_Click to update last activity time
        }
        private void ShowCaseInformationObjects()
        {
            // Show other objects related to case information
            if (dataFetched)
            {
                label2.Show();
                label4.Show();
                label5.Show();

            }
        }
        private void FetchCaseInformation()
        {
            // Get the selected case ID from the comboBoxCaseIDs
            string caseID = caseID_list.SelectedItem.ToString();

            // Query to fetch case information from the cases table based on caseID
            string query = "SELECT * FROM cases WHERE CaseID = @caseID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@caseID", caseID);

                    // Execute the query
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve and display case information
                            string caseType = reader["CType"].ToString();
                            string caseTitle = reader["CHeading"].ToString();

                            // Display case information
                            labelCaseInfo.Text = $"Case ID: {caseID}, Type: {caseType}, Date: {caseTitle}";
                        }
                        else
                        {
                            // Case not found
                            MessageBox.Show("Case information not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            if (dataFetched)
            {
                label4.Show();
            }
            AnyButton_Click(sender, e); // Call AnyButton_Click to update last activity time
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataFetched)
            {
                textBox1.Show();
            }

        }

        private string selectedEntityType;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataFetched)
            {
                entity_list.Show();
            }
            // Get the selected entity type from the comboBox1
            string entityType = entity_list.SelectedItem.ToString();

            // Store the selected entity type in a variable accessible to the save_file_Click event handler
            selectedEntityType = entityType;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataFetched)
            {
                open_file.Show();
            }
            openFileDialog1.Filter = "Word Documents (*.docx)|*.docx|Excel Documents (*.xlsx)|*.xlsx|PDF Files (*.pdf)|*.pdf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                string fileName = Path.GetFileName(filePath);
                Logger.LogAction($"{loggedInUsername} uploaded a file");
            }
            AnyButton_Click(sender, e); // Call AnyButton_Click to update last activity time
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        private void save_file_Click(object sender, EventArgs e)
        {
            if (dataFetched)
            {
                save_file.Show();
            }
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand("INSERT INTO forensics (Fname, FPath, FExtension, FSave, FDate, entity) VALUES (@file_name, @file_path, @file_extension, @file_save, CURRENT_TIMESTAMP, @entity)", connection);
                    cmd.Parameters.AddWithValue("@file_name", Path.GetFileNameWithoutExtension(openFileDialog1.FileName));
                    cmd.Parameters.AddWithValue("@file_path", Path.GetFullPath(openFileDialog1.FileName));
                    cmd.Parameters.AddWithValue("@file_extension", Path.GetExtension(openFileDialog1.FileName));

                    byte[] file;
                    using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            file = br.ReadBytes((int)fs.Length);
                        }
                    }
                    cmd.Parameters.AddWithValue("@file_save", file);
                    cmd.Parameters.AddWithValue("@entity", selectedEntityType);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Logger.LogAction($"{loggedInUsername} saved a file");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            AnyButton_Click(sender, e); // Call AnyButton_Click to update last activity time
        }


        private void caseID_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
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
                            criminal criminalForm = new criminal(usernameBD);
                            criminalForm.Show();
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

        private void DownloadOrDisplayFile(string fileName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to fetch the file from the database based on the file name
                    MySqlCommand cmd = new MySqlCommand("SELECT Fname, FSave, FExtension FROM forensics WHERE Fname = @file_name", connection);
                    cmd.Parameters.AddWithValue("@file_name", fileName);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string fileExtension = reader["FExtension"].ToString();
                            byte[] fileData = (byte[])reader["FSave"];

                            // Create a temporary file path
                            string tempFilePath = Path.Combine(Path.GetTempPath(), fileName + fileExtension);

                            // Write the file data to the temporary file
                            File.WriteAllBytes(tempFilePath, fileData);

                            // Open the file with the default associated application
                            System.Diagnostics.Process.Start(tempFilePath);
                        }
                        else
                        {
                            MessageBox.Show("File not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void label6_Click_1(object sender, EventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
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

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
}