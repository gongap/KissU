using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KissU.Core.System.MongoProvider
{
    /// <summary>
    /// Entity.
    /// Implements the <see cref="KissU.Core.System.MongoProvider.IEntity" />
    /// </summary>
    /// <seealso cref="KissU.Core.System.MongoProvider.IEntity" />
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