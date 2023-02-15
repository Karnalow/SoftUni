using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace P05.ChangeTownNamesCasing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true;MultipleActiveResultSets=true";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                string query = $@"SELECT [Name] FROM Countries WHERE [Name] = '{countryName}'";

                var command = new SqlCommand(query, sqlConnection);
                string queryResult = (string)command.ExecuteScalar();

                if (queryResult is not null)
                {
                    string updateQuery = $@"UPDATE Towns
                                            SET
                                              [Name] = UPPER([Name])
                                            WHERE (SELECT Id FROM Countries WHERE [Name] = '{countryName}') = CountryCode";

                    var updateCommand = new SqlCommand(updateQuery, sqlConnection);
                    int numberOfRowsAffected = updateCommand.ExecuteNonQuery();

                    Console.WriteLine($"{numberOfRowsAffected} town names were affected.");

                    string selectTownsQuery = $@"SELECT 
                                                 	t.[Name] 
                                                 FROM Towns t
                                                 	JOIN Countries c ON c.Id = t.CountryCode
                                                 WHERE c.Id = t.CountryCode AND c.[Name] = '{countryName}'";

                    var selectTownsCommand = new SqlCommand(selectTownsQuery, sqlConnection);

                    List<string> towns = new List<string>();

                    var reader = selectTownsCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        string townName =(string)reader["Name"];

                        towns.Add(townName);
                    }

                    Console.WriteLine("[" + string.Join(", ", towns) + "]");
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }
            }
        }
    }
}
