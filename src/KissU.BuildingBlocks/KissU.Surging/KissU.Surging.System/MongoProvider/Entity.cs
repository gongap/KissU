using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KissU.Surging.System.MongoProvider
{
    /// <summary>
    /// Entity.
    /// Implements the <see cref="KissU.Surging.System.MongoProvider.IEntity" />
    /// </summary>
    /// <seealso cref="KissU.Surging.System.MongoProvider.IEntity" />
    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract class Entity : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}