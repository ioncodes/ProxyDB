using MongoDB.Driver;
using ProxyDB.Models;
using System.Collections.Generic;

namespace ProxyDB.Database
{
    public class DatabaseManager
    {
        public MongoClient Client { get; }
        public IMongoDatabase Database { get; }
        private IMongoCollection<Proxy> _proxies;

        public DatabaseManager()
        {
            Client = new MongoClient();
            Database = Client.GetDatabase("proxydb");
            _proxies = Database.GetCollection<Proxy>("proxies");
        }

        public IEnumerable<Proxy> GetProxies()
        {
            return _proxies.Find(i => true).ToList();
        }
    }
}
