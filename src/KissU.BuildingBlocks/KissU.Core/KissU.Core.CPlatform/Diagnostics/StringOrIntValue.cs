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


namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// Struct StringOrIntValue
    /// </summary>
    public struct StringOrIntValue
    {
        private readonly int _intValue;
        private readonly string _stringValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringOrIntValue"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        public StringOrIntValue(int value)
        {
            _intValue = value;
            _stringValue = null;
        }

        /// <summary>
        /// Gets a value indicating whether this instance has value.
        /// </summary>
        public bool HasValue => HasIntValue || HasStringValue;

        /// <summary>
        /// Gets a value indicating whether this instance has int value.
        /// </summary>
        public bool HasIntValue => _intValue != 0;

        /// <summary>
        /// Gets a value indicating whether this instance has string value.
        /// </summary>
        public bool HasStringValue => _stringValue != null;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringOrIntValue"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        public StringOrIntValue(string value)
        {
            _intValue = 0;
            _stringValue = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringOrIntValue"/> struct.
        /// </summary>
        /// <param name="intValue">The int value.</param>
        /// <param name="stringValue">The string value.</param>
        public StringOrIntValue(int intValue, string stringValue)
        {
            _intValue = intValue;
            _stringValue = stringValue;
        }

        /// <summary>
        /// Gets the int value.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetIntValue() => _intValue;

        /// <summary>
        /// Gets the string value.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetStringValue() => _stringValue;

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>System.ValueTuple&lt;System.String, System.Int32&gt;.</returns>
        public (string, int) GetValue()
        {
            return (_stringValue, _intValue);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            if (HasIntValue)
            {
                return _intValue.ToString();
            }

            return _stringValue;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="StringOrIntValue"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator StringOrIntValue(string value) => new StringOrIntValue(value);
        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="StringOrIntValue"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator StringOrIntValue(int value) => new StringOrIntValue(value);
    }
}
