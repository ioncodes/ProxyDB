using MongoDB.Driver;
using ProxyDB.Models;
using System.Collections.Generic;
using MongoDB.Bson;

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

        public Proxy GetProxy(string id)
        {
            return _proxies.Find(document => document.ID == ObjectId.Parse(id)).FirstOrDefault();
        }
    }
}
