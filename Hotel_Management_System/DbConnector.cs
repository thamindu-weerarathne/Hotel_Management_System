using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    public class DbConnector
    {
        private string connectionString;

        public DbConnector()
        {
            // Set your connection string here
            connectionString = "Server=localhost;Database=hotel_db;User Id=root;Password=;";
        }

        public bool IsValidNamePass(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM Users WHERE Username=@Username AND Password=@Password";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 1;
                }
                catch (Exception ex)
                {
                    // Log or handle the exception as needed
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }
    }
}