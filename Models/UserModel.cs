using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace systemLogin.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement]
        public string username { get; set; }

        [BsonElement]
        public string password { get; set; }
    }

    public class UserDatabase : IUserdatabase
    {
        public string UserColetionName { get; set; }
        public string Connection { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IUserdatabase
    {
        public string UserColetionName { get; set; }
        public string Connection { get; set; }
        public string DatabaseName { get; set; }
    }
}