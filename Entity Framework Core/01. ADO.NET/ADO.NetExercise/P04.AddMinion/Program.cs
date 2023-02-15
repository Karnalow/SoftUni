using Microsoft.Data.SqlClient;
using System;

namespace P04.AddMinion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Minion: ");

            string[] minionInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string minionTownName = minionInfo[2];

            Console.Write("Villain: ");

            string[] villainInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string villainName = villainInfo[0];

            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true;MultipleActiveResultSets=true";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                string selectMinionNameQuery = @$"SELECT
                                 	[Name]
                                 FROM Towns
                                 WHERE [Name] = '{minionTownName}'";

                using SqlCommand minionSelectCommandQuery = new SqlCommand(selectMinionNameQuery, sqlConnection);
                
                var minionReader = minionSelectCommandQuery.ExecuteReader();
                bool isTownExist = minionReader.Read();


                if (isTownExist == false)
                {
                    string insertQuery = $@"INSERT INTO Towns([Name]) VALUES('{minionTownName}')";

                    using SqlCommand minionInsertCommnadQuery = new SqlCommand(insertQuery, sqlConnection);
                    minionInsertCommnadQuery.ExecuteNonQuery();

                    Console.WriteLine($"Town {minionTownName} was added to the database.");
                }

                string selectVillainNameQuery = $@"SELECT
                                                   	[Name]
                                                   FROM Villains
                                                   WHERE [Name] = '{villainName}'";

                using SqlCommand villainSelectCommandQuery = new SqlCommand(selectVillainNameQuery, sqlConnection);

                var villainReader = villainSelectCommandQuery.ExecuteReader();
                bool isVillianExist = villainReader.Read();

                if (isVillianExist == false)
                {
                    string insertQuery = @$"INSERT INTO Villains([Name], EvilnessFactorId) VALUES('{villainName}', 4)";

                    using SqlCommand vallianInsertCommnadQuery = new SqlCommand(insertQuery, sqlConnection);
                    vallianInsertCommnadQuery.ExecuteNonQuery();

                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                string insertMinionQuery = @$"INSERT INTO Minions([Name], Age) VALUES('{minionName}', {minionAge})";

                using SqlCommand insertMinion = new SqlCommand(insertMinionQuery, sqlConnection);
                insertMinion.ExecuteNonQuery();

                string addMinionToVillainQuery = @$"INSERT INTO MinionsVillains(MinionId, VillainId) VALUES(
                                             (SELECT Id FROM Minions WHERE [Name] = '{minionName}'), 
                                             (SELECT Id FROM Villains WHERE [Name] = '{villainName}'))";

                using SqlCommand insertMinnionToVillianCommand = new SqlCommand(addMinionToVillainQuery, sqlConnection);

                insertMinnionToVillianCommand.ExecuteNonQuery();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }
    }
}
