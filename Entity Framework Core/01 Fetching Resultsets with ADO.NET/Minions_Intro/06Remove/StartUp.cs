using System;
using System.Data.SqlClient;

namespace _06Remove
{
    class StartUp
    {
        private static string connectionString = @"Server=localhost\SQLEXPRESS08;" +
                                                 "Database=MinionsDB;" +
                                                 "Integrated Security=true";

        private static SqlConnection connection = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
            var villainId = int.Parse(Console.ReadLine());

            connection.Open();

            using (connection)
            {
                var command = new SqlCommand("SELECT Id FROM Villains WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", villainId);

                int? result = (int?) command.ExecuteScalar();

                if (result == null)
                {
                    Console.WriteLine("No such villain was found.");
                    connection.Close();
                    return;
                }

                command = new SqlCommand("SELECT COUNT(*) FROM MinionsVillains WHERE VillainId = @Id", connection);
                command.Parameters.AddWithValue("@Id", villainId);
                var minionsCount = (int) command.ExecuteScalar();

                command = new SqlCommand("DELETE FROM MinionsVillains WHERE VillainId = @Id", connection);
                command.Parameters.AddWithValue("@Id", villainId);
                command.ExecuteNonQuery();

                command = new SqlCommand("SELECT Name FROM Villains WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", villainId);
                var villainName = (string) command.ExecuteScalar();

                command = new SqlCommand("DELETE FROM Villains WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", villainId);
                command.ExecuteNonQuery();

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{minionsCount} minions were released.");
            }
        }
    }
}
