using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProxyDB.Enums;

namespace ProxyDB.Models
{
    public class Proxy
    {
        [BsonId]
        public ObjectId ID { get; set; }

        [BsonElement("ip")]
        public string IP { get; set; }

        [BsonElement("port")]
        public int Port { get; set; }

        [BsonElement("protocol")]
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public Protocol Protocol { get; set; }

        [BsonElement("anonymity")]
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public Anonymity Anonymity { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        public string GetProxy()
        {
            return $"{IP}:{Port}";
        }
    }
}
