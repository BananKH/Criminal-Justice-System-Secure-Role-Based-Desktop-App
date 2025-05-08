// Import necessary namespaces
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace Police_station
{
    public partial class cases : Form
    {
        // API URL for fetching current timestamp
        private string apiUrl = "https://worldtimeapi.org/api/ip";
        // Connection string retrieved from application configuration
        private string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        // Variable to store the last activity time
        private DateTime lastActivityTime;
        // Timer for checking user inactivity
        private Timer inactivityTimer;
        // Username retrieved from login
        private string usernameBD;

        // Constructor for the form
        public cases(string usernameBD)
        {
            InitializeComponent();
            this.usernameBD = usernameBD; // Initialize the usernameBD variable
            Showcases(); // Display cases in DataGridView
            GetCriminals(); // Populate criminal names in ComboBox
            InitializeAsync(); // Fetch the last activity time from the database asynchronously
        }

        // Async method to initialize the form
        private async void InitializeAsync()
        {
            try
            {
                // Open a connection to the database
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "SELECT attemptTime FROM loginattempts WHERE username = @Username";

                    // Prepare SQL command to retrieve login time
                    MySqlCommand command = new MySqlCommand(query, con);
                    command.Parameters.AddWithValue("@Username", usernameBD);

                    await con.OpenAsync(); // Open the database connection asynchronously
                    var loginTime = await command.ExecuteScalarAsync(); // Execute the SQL command asynchronously

                    // Check if login time is available
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

        // Method to start the inactivity timer
        private void StartInactivityTimer()
        {
            inactivityTimer = new Timer();
            inactivityTimer.Interval = 60000; // Check every minute
            // Event handler for timer tick
            inactivityTimer.Tick += async (s, ev) => { await CheckInactivity(); };
            inactivityTimer.Start();
        }

        // Async method to check user inactivity
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

        // Async method to fetch current timestamp from API
        private async Task<DateTime> GetCurrentTimestampAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl); // Send GET request to API

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync(); // Read response as string
                        dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json); // Deserialize JSON response
                        DateTime timestamp = Convert.ToDateTime(result.datetime); // Extract datetime from response
                        return timestamp; // Return timestamp
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

        // Async method to update last activity time from the database
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

        // Method to handle logout
        private void Logout()
        {
            // Perform logout action here
            Login loginForm = new Login(); // Initialize login form
            loginForm.Show(); // Show login form
            RestartTimer(); // Restart the inactivity timer
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

        // Method to display cases in DataGridView
        private void Showcases()
        {
            string query = "SELECT * FROM case_table";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open(); // Open the connection
                    MySqlCommand command = new MySqlCommand(query, con); // Create SQL command
                    MySqlDataAdapter sda = new MySqlDataAdapter(command); // Create a MySqlDataAdapter
                    DataSet ds = new DataSet(); // Create a DataSet
                    sda.Fill(ds); // Fill the DataSet with data from the adapter
                    CasesDGV.DataSource = ds.Tables[0]; // Bind the DataGridView to the DataSet
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            } // Connection will be automatically closed here
        }

        // Method to populate criminal names in ComboBox
        private void GetCriminals()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open(); // Open the database connection
                MySqlCommand command = new MySqlCommand("SELECT * FROM criminal_table", con); // SQL command to select all criminals
                MySqlDataReader Rdr;
                Rdr = command.ExecuteReader(); // Execute the command and get a data reader
                DataTable dt = new DataTable(); // Create a new DataTable
                dt.Columns.Add("CrCode", typeof(int)); // Add columns to the DataTable
                dt.Load(Rdr); // Load data from the data reader into the DataTable
                CriminalCb.ValueMember = "CrCode"; // Set the value member of the ComboBox
                CriminalCb.DataSource = dt; // Set the data source of the ComboBox to the DataTable
                con.Close(); // Close the database connection
            }
        }
        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        int Key = 0;

        // Method to reset form fields
        private void Reset()
        {
            // Reset form fields
            caseheadTb.Text = "";
            CaseDetailsTb.Text = "";
            TypeCb.SelectedIndex = -1;
            PlaceTb.Text = "";
            CriminalNameTb.Text = "";
            Key = 0;
        }

        // Method to get criminal name based on selected value in ComboBox
        private void GetCriminalName()
        {
            if (CriminalCb.SelectedValue != null)
            {
                string Query = "SELECT * FROM criminal_table WHERE CrCode=" + CriminalCb.SelectedValue.ToString() + "";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    MySqlCommand command = new MySqlCommand(Query, con);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter sda = new MySqlDataAdapter(command);
                    dt.Columns.Add("CrCode", typeof(int));
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        CriminalNameTb.Text = dr["CrName"].ToString();
                    }
                    con.Close();
                }
            }
        }

        // Event handler for DataGridView cell content click
        private void CasesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Populate form fields with selected case details
            TypeCb.SelectedItem = CasesDGV.SelectedRows[0].Cells[1].Value.ToString();
            caseheadTb.Text = CasesDGV.SelectedRows[0].Cells[2].Value.ToString();
            CaseDetailsTb.Text = CasesDGV.SelectedRows[0].Cells[3].Value.ToString();
            PlaceTb.Text = CasesDGV.SelectedRows[0].Cells[4].Value.ToString();
            Date.Text = CasesDGV.SelectedRows[0].Cells[5].Value.ToString();
            CriminalCb.SelectedValue = CasesDGV.SelectedRows[0].Cells[6].Value.ToString();
            CriminalNameTb.Text = CasesDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (caseheadTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CasesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
            AnyButton_Click(sender, e); // Call AnyButton_Click to update last activity time
        }

        // Event handler for ComboBox selection change
        private void CriminalCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCriminalName(); // Get criminal name based on selected value
        }

        // Event handler for Edit button click
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (caseheadTb.Text == "" || CaseDetailsTb.Text == "" || TypeCb.SelectedIndex == -1 || PlaceTb.Text == "" || CriminalNameTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();
                        MySqlCommand command = new MySqlCommand("UPDATE case_table SET Ctype=@CT, CHeading=@CH, CDetails=@CD, Cplace=@CP, CDate=@CDa, Cperson=@Cper, CpersonName=@CPerN, polname= @poln WHERE CNum=@CKey", con);
                        command.Parameters.AddWithValue("@CT", TypeCb.Text);
                        command.Parameters.AddWithValue("@CH", caseheadTb.Text);
                        command.Parameters.AddWithValue("@CD", CaseDetailsTb.Text);
                        command.Parameters.AddWithValue("@CP", PlaceTb.Text);
                        command.Parameters.AddWithValue("@CDa", Date.Value.Date);
                        command.Parameters.AddWithValue("@Cper", CriminalCb.SelectedValue.ToString());
                        command.Parameters.AddWithValue("@CPerN", CriminalNameTb.Text);
                        command.Parameters.AddWithValue("@CKey", Key);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Case Updated!");
                        con.Close();
                        Showcases();
                        Reset();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            AnyButton_Click(sender, e); // Update last activity time
        }

        // Event handler for Cancel button click
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Case!!!");
            }
            else
            {
                try
                {
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();
                        MySqlCommand command = new MySqlCommand("DELETE FROM case_table WHERE CNum=@CKey", con); // Pass the connection object
                        command.Parameters.AddWithValue("@CKey", Key);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Case Deleted!");
                        con.Close();
                        Showcases();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            AnyButton_Click(sender, e); // Update last activity time
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (caseheadTb.Text == "" || CaseDetailsTb.Text == "" || TypeCb.SelectedIndex == -1 || PlaceTb.Text == "" || CriminalNameTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {
                try
                {
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();
                        MySqlCommand command = new MySqlCommand("INSERT INTO case_table(Ctype, CHeading, CDetails, Cplace, CDate, Cperson, CpersonName, polname) VALUES (@CT, @CH, @CD, @CP, @CDa, @Cper, @CPerN, @poln)", con);
                        command.Parameters.AddWithValue("@CT", TypeCb.Text);
                        command.Parameters.AddWithValue("@CH", caseheadTb.Text);
                        command.Parameters.AddWithValue("@CD", CaseDetailsTb.Text);
                        command.Parameters.AddWithValue("@CP", PlaceTb.Text);
                        command.Parameters.AddWithValue("@CDa", Date.Value.Date);
                        command.Parameters.AddWithValue("@Cper", CriminalCb.SelectedValue.ToString());
                        command.Parameters.AddWithValue("@CPerN", CriminalNameTb.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Case Recorded!");
                        con.Close();
                        Showcases();
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

        private void label2_Click(object sender, EventArgs e){
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

        private void label3_Click(object sender, EventArgs e){
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

        private void caseheadTb_TextChanged(object sender, EventArgs e){}

        private void CriminalNameTb_TextChanged(object sender, EventArgs e){}

        private void polname_Click(object sender, EventArgs e){}
        private void label5_Click(object sender, EventArgs e)
        {
            Logout();
        }


        private void label1_Click(object sender, EventArgs e){}

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e){}

        private void cases_Load(object sender, EventArgs e){
        }

        private void textBox1_TextChanged(object sender, EventArgs e){}

        private void gunaAdvenceButton1_Click(object sender, EventArgs e){}
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e){}

        private void label11_Click(object sender, EventArgs e){}

        private void label12_Click(object sender, EventArgs e){}

        private void textBox5_TextChanged(object sender, EventArgs e){}

        private void cases_Load_1(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Your painting logic goes here
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
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
    }
}
