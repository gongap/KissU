/*
 * Licensed to the SkyAPM under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The SkyAPM licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// Struct UniqueId
    /// Implements the <see cref="System.IEquatable{KissU.Core.CPlatform.Diagnostics.UniqueId}" />
    /// </summary>
    /// <seealso cref="System.IEquatable{KissU.Core.CPlatform.Diagnostics.UniqueId}" />
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
        /// Initializes a new instance of the <see cref="UniqueId"/> struct.
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
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() => $"{Part1}.{Part2}.{Part3}";

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(UniqueId other) =>
            Part1 == other.Part1 && Part2 == other.Part2 && Part3 == other.Part3;

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) =>
            obj is UniqueId other && Equals(other);

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
        public static bool operator ==(UniqueId left, UniqueId right) => left.Equals(right);

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(UniqueId left, UniqueId right) => !left.Equals(right);
    }
}
 
