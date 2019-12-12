using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KissU.Core.System.MongoProvider
{
    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract class Entity : IEntity
    { 
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
