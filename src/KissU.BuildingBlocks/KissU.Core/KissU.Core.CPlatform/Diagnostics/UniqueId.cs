using System;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// Struct UniqueId
    /// Implements the <see cref="IEquatable{T}" />
    /// </summary>
    /// <seealso cref="IEquatable{UniqueId}" />
    public struct UniqueId : IEquatable<UniqueId>
    {
        /// <summary>
        /// Gets the part1.
        /// </summary>
        public long Part1 { get; }

        /// <summary>
        /// Gets the part2.
        /// </summary>
        public long Part2 { get; }

        /// <summary>
        /// Gets the part3.
        /// </summary>
        public long Part3 { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueId" /> struct.
        /// </summary>
        /// <param name="part1">The part1.</param>
        /// <param name="part2">The part2.</param>
        /// <param name="part3">The part3.</param>
        public UniqueId(long part1, long part2, long part3)
        {
            Part1 = part1;
            Part2 = part2;
            Part3 = part3;
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{Part1}.{Part2}.{Part3}";
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(UniqueId other)
        {
            return Part1 == other.Part1 && Part2 == other.Part2 && Part3 == other.Part3;
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns><c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return obj is UniqueId other && Equals(other);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Part1.GetHashCode();
                hashCode = (hashCode * 397) ^ Part2.GetHashCode();
                hashCode = (hashCode * 397) ^ Part3.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(UniqueId left, UniqueId right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(UniqueId left, UniqueId right)
        {
            return !left.Equals(right);
        }
    }
}