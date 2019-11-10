using System;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace _02VillainNames
{
    class StartUp
    {
        private static string connectionString = @"Server=localhost\SQLEXPRESS08;" +
                                                 "Database=MinionsDB;" +
                                                 "Integrated Security=true";

        private static SqlConnection connection = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
            connection.Open();

            using (connection)
            {
                var queryText = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount
                                 FROM Villains AS v
                                 JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                 GROUP BY v.Id, v.Name
                                     HAVING COUNT(mv.VillainId) > 20
                                 ORDER BY COUNT(mv.VillainId)";

                var selectionCommand = new SqlCommand(queryText, connection);

                var reader = selectionCommand.ExecuteReader();

                using (reader)
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("There are no such villains!");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                        }
                    }
                }
            }
        }
    }
}
