using System;
using System.Data.SqlClient;

namespace _04AddMinion
{
    class StartUp
    {
        private static string connectionString = @"Server=localhost\SQLEXPRESS08;" +
                                                 "Database=MinionsDB;" +
                                                 "Integrated Security=true";

        private static SqlConnection connection = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split();
            var minionName = tokens[1];
            var minionAge = int.Parse(tokens[2]);
            var minionTown = tokens[3];

            tokens = Console.ReadLine().Split();
            var villainName = tokens[1];

            connection.Open();

            using (connection)
            {
                var command = new SqlCommand($"SELECT COUNT(*) FROM Towns WHERE Name = '{minionTown}'", connection);

                if ((int)command.ExecuteScalar() == 0)
                {
                    command = new SqlCommand($"INSERT INTO Towns(Name) VALUES ('{minionTown}')", connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

                command = new SqlCommand($"SELECT COUNT(*) FROM Villains WHERE Name = '{villainName}'", connection);

                if ((int)command.ExecuteScalar() == 0)
                {
                    command = new SqlCommand($"INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('{villainName}', 4)", connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                command = new SqlCommand($"SELECT Id FROM Towns WHERE Name = '{minionTown}'", connection);
                var townId = (int)command.ExecuteScalar();

                command = new SqlCommand($"INSERT INTO Minions(Name, Age, TownId) VALUES ('{minionName}', {minionAge}, {townId})", connection);
                command.ExecuteNonQuery();

                var villainId = (int)new SqlCommand($"SELECT Id FROM Villains WHERE Name = '{villainName}'", connection).ExecuteScalar();
                var minionId = (int)new SqlCommand($"SELECT Id FROM Minions WHERE Name = '{minionName}'", connection).ExecuteScalar();

                command = new SqlCommand($"INSERT INTO MinionsVillains VALUES ({minionId}, {villainId})", connection);
                command.ExecuteNonQuery();
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }
    }
}
