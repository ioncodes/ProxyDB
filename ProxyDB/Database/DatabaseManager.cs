using MongoDB.Driver;
using ProxyDB.Models;
using System.Collections.Generic;
using MongoDB.Bson;
using ProxyDB.Enums;
using System;

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

        public IEnumerable<Proxy> GetProxies(int? port, string protocol, string anonymity, string country)
        {
            Protocol _protocol = Protocol.HTTP;
            Anonymity _anonymity = Anonymity.Anonymous;
            if (protocol != null && !Enum.TryParse(protocol, true, out _protocol))
            {
                return null;
            }

            if (anonymity != null && !Enum.TryParse(anonymity, true, out _anonymity))
            {
                return null;
            }

            return _proxies.Find(
                i => (port == null || i.Port == port) &&
                     (protocol == null || i.Protocol == _protocol) &&
                     (anonymity == null || i.Anonymity == _anonymity) &&
                     (country == null || i.Country == country)
            ).ToList();
        }

        public Proxy GetProxy(string id)
        {
            try
            {
                return _proxies.Find(document => document.ID == ObjectId.Parse(id)).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public void AddProxy(Proxy proxy)
        {
            _proxies.InsertOne(proxy);
        }
    }
}

