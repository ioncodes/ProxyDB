using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProxyDB.Enums;

namespace ProxyDB.Models
{
    public class Proxy
    {
        public int ID { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Protocol Protocol { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Anonymity Anonymity { get; set; }
        public string Country { get; set; }

        public string GetProxy()
        {
            return $"{IP}:{Port}";
        }
    }
}
