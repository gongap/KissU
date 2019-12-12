using MongoDB.Bson.Serialization.Attributes;

namespace KissU.Core.System.MongoProvider
{
    public interface IEntity
    {
        [BsonId]
        string Id { get; set; }
    }
}
