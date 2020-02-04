using System;

namespace KissU.Core.System.MongoProvider.Attributes
{
    /// <summary>
    /// CollectionNameAttribute.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class)]
    public class CollectionNameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionNameAttribute" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">参数不能为空 - value</exception>
        public CollectionNameAttribute(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("参数不能为空", "value");
            }

            Name = value;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }
    }
}