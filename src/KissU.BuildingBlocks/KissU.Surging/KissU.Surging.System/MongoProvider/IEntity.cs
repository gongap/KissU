using MongoDB.Bson.Serialization.Attributes;

namespace KissU.Surging.System.MongoProvider
{
    /// <summary>
    /// Interface IEntity
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [BsonId]
        string Id { get; set; }
    }
}