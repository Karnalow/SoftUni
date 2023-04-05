using MongoDB.Bson;
using MongoDB.Driver;

namespace NoSql
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MongoClient client = new MongoClient("mongodb://127.0.0.1:27017");

            IMongoDatabase database = client.GetDatabase("NoSQL");

            var collection = database.GetCollection<BsonDocument>("softuniArticles");

            var allArticles = collection.Find(new Article { }).ToList();

            foreach (var article in allArticles) 
            {
                string name = article.GetElement("name").Value.AsString;

                Console.WriteLine(name);
            }
        }
    }
}