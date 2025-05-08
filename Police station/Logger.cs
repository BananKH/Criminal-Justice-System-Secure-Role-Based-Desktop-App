using MySql.Data.MySqlClient;
using Police_station;
using System;
using System.Configuration;

public static class Logger
{
    public static void LogAction(string action)
    {
        string username = UserSession.Username;

        string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        try
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO app_logs (username, `Date/Time`, action) VALUES (@username, CURRENT_TIMESTAMP, @action)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@action", action);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Log successfully inserted into the database.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while logging the action: " + ex.Message);
        }
    }
}
