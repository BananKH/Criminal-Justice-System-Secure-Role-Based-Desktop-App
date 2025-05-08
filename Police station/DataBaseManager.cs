using MySql.Data.MySqlClient;
using System.Configuration;

namespace Police_station
{
    public static class DatabaseManager
    {
        // Define a static property to hold the connection string
        public static string ConnectionString { get; } = ConfigurationManager.ConnectionStrings["ConAdmin"].ConnectionString;

        // Method to get a MySqlConnection object
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}