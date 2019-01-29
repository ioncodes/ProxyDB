using MongoDB.Driver;
using ProxyDB.Models;

namespace ProxyDB.Database
{
    public class DatabaseManager
    {
        public MongoClient Client { get; }
        public IMongoDatabase Database { get; }
        public IMongoCollection<Proxy> ProxyCollection { get; }

        public DatabaseManager()
        {
            Client = new MongoClient();
            Database = Client.GetDatabase("proxydb");
            ProxyCollection = Database.GetCollection<Proxy>("proxies");
        }
    }
}
