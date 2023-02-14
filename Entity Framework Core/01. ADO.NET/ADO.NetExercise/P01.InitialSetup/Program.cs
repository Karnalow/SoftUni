using Microsoft.Data.SqlClient;

namespace P01.InitialSetup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                string query =
                @"CREATE TABLE Countries(
                    Id INT PRIMARY KEY IDENTITY,
                    [Name] VARCHAR(50)
                )
                
                CREATE TABLE Towns(
                	Id INT PRIMARY KEY IDENTITY,
                	[Name] VARCHAR(50),
                	CountryCode INT REFERENCES Countries(Id)
                )
                
                CREATE TABLE Minions(
                	Id INT PRIMARY KEY IDENTITY,
                	[Name] VARCHAR(50),
                	Age INT,
                	TownId INT REFERENCES Towns(Id)
                )
                
                CREATE TABLE EvilnessFactors(
                	Id INT PRIMARY KEY IDENTITY,
                	[Name] VARCHAR(50)
                )
                
                CREATE TABLE Villains(
                	Id INT PRIMARY KEY IDENTITY,
                	[Name] VARCHAR(50),
                	EvilnessFactorId INT REFERENCES EvilnessFactors(Id)
                )
                
                CREATE TABLE MinionsVillains(
                	MinionId INT REFERENCES Minions(Id),
                	VillainId INT REFERENCES Villains(Id),
                
                	CONSTRAINT PK_MinionsVillains PRIMARY KEY(MinionId, VillainId)
                )
                
                INSERT INTO Countries([Name]) VALUES
                ('Afghanistan'),
                ('Albania'),
                ('Algeria'),
                ('Andorra'),
                ('Angola')
                
                INSERT INTO Towns([Name], CountryCode) VALUES
                ('Alexander City', 1),
                ('Andalusia', 2),
                ('Seward', 3),
                ('Ajo', 4),
                ('Bisbee', 5)
                
                INSERT INTO Minions([Name], Age, TownId) VALUES
                ('Bob', 21, 1),
                ('Kevin', 42, 2),
                ('Seward', 35, 3),
                ('Ivan', 40, 4),
                ('Hristo', 18, 5)
                
                INSERT INTO EvilnessFactors([Name]) VALUES
                ('super good'),
                ('good'),
                ('bad'),
                ('evil'),
                ('super evil')
                
                INSERT INTO Villains([Name], EvilnessFactorId) VALUES
                ('Gru', 1),
                ('Victor', 2),
                ('Jilly', 3),
                ('Angata', 4),
                ('Checheneca', 5)
                
                INSERT INTO MinionsVillains(MinionId, VillainId) VALUES
                (1,1),(2,2),(3,3),(4,4),(5,5)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
