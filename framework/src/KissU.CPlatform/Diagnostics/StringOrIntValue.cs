namespace KissU.CPlatform.Diagnostics
{
    /// <summary>
    /// 字符串或整数值
    /// </summary>
    public struct StringOrIntValue
    {
        private readonly int _intValue;
        private readonly string _stringValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringOrIntValue" /> struct.
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
        /// Initializes a new instance of the <see cref="StringOrIntValue" /> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        public StringOrIntValue(string value)
        {
            _intValue = 0;
            _stringValue = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringOrIntValue" /> struct.
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
        public int GetIntValue()
        {
            return _intValue;
        }

        /// <summary>
        /// Gets the string value.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetStringValue()
        {
            return _stringValue;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>System.ValueTuple&lt;System.String, System.Int32&gt;.</returns>
        public (string, int) GetValue()
        {
            return (_stringValue, _intValue);
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            if (HasIntValue)
            {
                return _intValue.ToString();
            }

            return _stringValue;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="string" /> to <see cref="StringOrIntValue" />.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator StringOrIntValue(string value)
        {
            return new StringOrIntValue(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="int" /> to <see cref="StringOrIntValue" />.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator StringOrIntValue(int value)
        {
            return new StringOrIntValue(value);
        }
    }
}