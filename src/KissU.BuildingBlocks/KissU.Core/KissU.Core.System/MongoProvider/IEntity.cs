using MongoDB.Bson.Serialization.Attributes;

namespace KissU.Core.System.MongoProvider
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