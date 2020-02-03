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


using System.Collections;
using System.Collections.Generic;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// SegmentReference.
    /// </summary>
    public class SegmentReference
    {
        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        public Reference Reference { get; set; }

        /// <summary>
        /// Gets or sets the parent segment identifier.
        /// </summary>
        public UniqueId ParentSegmentId { get; set; }

        /// <summary>
        /// Gets or sets the parent span identifier.
        /// </summary>
        public int ParentSpanId { get; set; }

        /// <summary>
        /// Gets or sets the parent service instance identifier.
        /// </summary>
        public int ParentServiceInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the entry service instance identifier.
        /// </summary>
        public int EntryServiceInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the network address.
        /// </summary>
        public StringOrIntValue NetworkAddress { get; set; }

        /// <summary>
        /// Gets or sets the entry endpoint.
        /// </summary>
        public StringOrIntValue EntryEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the parent endpoint.
        /// </summary>
        public StringOrIntValue ParentEndpoint { get; set; }
    }

    /// <summary>
    /// Enum Reference
    /// </summary>
    public enum Reference
    {
        /// <summary>
        /// The cross process
        /// </summary>
        CrossProcess = 0,
        /// <summary>
        /// The cross thread
        /// </summary>
        CrossThread = 1,
    }

    /// <summary>
    /// SegmentReferenceCollection.
    /// Implements the <see cref="System.Collections.Generic.IEnumerable{KissU.Core.CPlatform.Diagnostics.SegmentReference}" />
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IEnumerable{KissU.Core.CPlatform.Diagnostics.SegmentReference}" />
    public class SegmentReferenceCollection : IEnumerable<SegmentReference>
    {
        private readonly HashSet<SegmentReference> _references = new HashSet<SegmentReference>();

        /// <summary>
        /// Adds the specified reference.
        /// </summary>
        /// <param name="reference">The reference.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Add(SegmentReference reference)
        {
            return _references.Add(reference);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<SegmentReference> GetEnumerator()
        {
            return _references.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _references.GetEnumerator();
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count => _references.Count;
    }
}
