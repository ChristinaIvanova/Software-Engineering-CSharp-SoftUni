using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05ChangeTown
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            string connectionString = @"Server=localhost\SQLEXPRESS08;" +
                                      "Database=MinionsDB;" +
                                      "Integrated Security=true";

            SqlConnection dbCon = new SqlConnection(connectionString);
            dbCon.Open();

            using (dbCon)
            {
                int? countryId = (int?) new SqlCommand($"SELECT Id FROM Countries WHERE Name = '{countryName}'", dbCon)
                    .ExecuteScalar();

                if (countryId == null)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    SqlDataReader reader = new SqlCommand($"SELECT * FROM Towns WHERE CountryCode = {countryId}", dbCon)
                        .ExecuteReader();

                    var townNamesAffected = new List<String>();

                    using (reader)
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No town names were affected.");
                            reader.Close();
                            dbCon.Close();
                            return;
                        }

                        while (reader.Read())
                        {

                            string townName = (string) reader["Name"];

                            townNamesAffected.Add(townName.ToUpper());
                        }
                    }

                    var queryText = @"UPDATE Towns
                                        SET Name = UPPER(Name)
                                      WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                    var updateCmnd = new SqlCommand(queryText, dbCon);
                    updateCmnd.Parameters.AddWithValue("@countryName", countryName);
                    updateCmnd.ExecuteNonQuery();

                    Console.WriteLine($"{townNamesAffected.Count} town names were affected.");
                    Console.WriteLine($"[{String.Join(", ", townNamesAffected)}]");
                }
            }
        }
    }
}
