/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

public class DB
{
    DataSet ds;
    public DB()
    {
        ds = new DataSet();
    }
    public string QueryScalar(string query)
    {
        MySqlConnection mySqlConnection = null;
        MySqlCommand mySqlCommand = null;
        try
        {
            mySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            var result = mySqlCommand.ExecuteScalar();
            return result?.ToString() ?? "0"; // Return "0" if result is null
        }
        catch (Exception ex)
        {
            // Log exception details here
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "0"; // Consider the appropriate default value in case of an error
        }
        finally
        {
            mySqlCommand?.Dispose();
            mySqlConnection?.Close();
            mySqlConnection?.Dispose();
        }
    }

    public bool IsValidUser(string username, string password)
    {
        MySqlConnection mySqlConnection = null;
        MySqlCommand mySqlCommand = null;
        try
        {
            mySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            mySqlCommand = new MySqlCommand("SELECT COUNT(*) FROM users WHERE username = @username AND password = @password", mySqlConnection);
            mySqlCommand.Parameters.AddWithValue("@username", username);
            mySqlCommand.Parameters.AddWithValue("@password", password); // Consider hashing the password
            mySqlConnection.Open();
            int result = Convert.ToInt32(mySqlCommand.ExecuteScalar());
            return result > 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        finally
        {
            mySqlCommand?.Dispose();
            mySqlConnection?.Close();
            mySqlConnection?.Dispose();
        }
    }



}

*/