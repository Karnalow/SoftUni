using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace P03.MinionNames
{
    public class Program
    {
        const string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";

        public static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string villainNameQuery = @$"SELECT [Name] FROM Villains WHERE Id = {villainId}";

            var villainName = VillainInfo(sqlConnection, villainNameQuery);

            string minionsNamesQuery = @$"SELECT 
                                          	ROW_NUMBER() OVER (ORDER BY m.[Name]) AS [RowNum],
                                          	m.[Name],
                                          	m.Age
                                          FROM MinionsVillains mv
                                          	JOIN Minions m ON mv.MinionId = m.Id
                                          WHERE mv.VillainId = {villainId}
                                          ORDER BY m.[Name]";

            var minionsInfo = MinionsInfo(sqlConnection, minionsNamesQuery);
            var result = Result(minionsInfo, villainName, villainId);

            Console.WriteLine(result);
        }

        private static string Result(string minionsInfo, string villainInfo, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            if (villainInfo.Length == 0)
            {
                sb.AppendLine($"No villain with ID {villainId} exists in the database.");
            }
            else
            {
                sb.AppendLine($"Villain: {villainInfo}");

                if (minionsInfo.Length == 0)
                {
                    sb.AppendLine("(no minions)");
                }

                sb.AppendLine(minionsInfo);
            }

            return sb.ToString().TrimEnd();
        }

        private static string MinionsInfo(SqlConnection sqlConnection, string query)
        {
            StringBuilder sb = new StringBuilder();

            using var command = new SqlCommand(query, sqlConnection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var rowNum = reader["RowNum"];
                string name = (string)reader["Name"];
                int age = (int)reader["Age"];
            
                sb.AppendLine($"{rowNum}. {name} {age}");
            }

            return sb.ToString().TrimEnd();
        }

        private static string VillainInfo(SqlConnection sqlConnection, string query)
        {
            StringBuilder sb = new StringBuilder();

            using var command = new SqlCommand(query, sqlConnection);
            sb.AppendLine((string)command.ExecuteScalar());

            return sb.ToString().TrimEnd();
        }
    }
}
