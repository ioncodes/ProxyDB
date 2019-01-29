using MongoDB.Driver;

namespace ProxyDB.Database
{
    public class DatabaseManager
    {
        public MongoClient Client { get; }
        public IMongoDatabase Database { get; }

        public DatabaseManager()
        {
            Client = new MongoClient();
            Database = Client.GetDatabase("proxydb");
        }
    }
}
