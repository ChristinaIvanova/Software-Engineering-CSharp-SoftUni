using System;
using System.Data.SqlClient;

namespace _03MinionNames
{
    class StartUp
    {
        private static string connectionString = @"Server=localhost\SQLEXPRESS08;" +
                                                 "Database=MinionsDB;" +
                                                 "Integrated Security=true";

        private static SqlConnection connection = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
            Console.Write("Enter a Villain ID: ");
            var villainId = int.Parse(Console.ReadLine());

            using (connection)
            {
                connection.Open();

                var queryText = @"SELECT v.Name AS VillainName,
                                         m.Name AS MinionName,
                                         m.Age AS MinionAge
                                  FROM Villains AS v
                                       LEFT JOIN MinionsVillains AS vm ON vm.VillainId = v.Id
                                       LEFT JOIN Minions AS m ON m.Id = vm.MinionId
                                  WHERE v.Id = @Id;";

                var cmnd = new SqlCommand(queryText, connection);

                using (cmnd)
                {
                    cmnd.Parameters.AddWithValue("@Id", villainId);

                    var reader = cmnd.ExecuteReader();

                    using (reader)
                    {
                        ProcessSelection(reader, villainId);
                    }
                }
            }

        }

        private static void ProcessSelection(SqlDataReader reader, int villainId)
        {
            if (reader.HasRows)
            {
                reader.Read();
                Console.WriteLine($"Villain: {reader["VillainName"]}");

                if (reader.IsDBNull(1))
                {
                    Console.WriteLine("(no minions)");
                }
                else
                {
                    int minionNumber = 1;
                    while (true)
                    {
                        Console.WriteLine($"{minionNumber++}. {reader["MinionName"]} {reader["MinionAge"]}");

                        if (!reader.Read())
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            }
        }
    }
}
