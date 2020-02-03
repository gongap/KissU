using System;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// 诊断名称.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public class DiagnosticName : Attribute
    {
        /// <summary>
        /// 名称.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticName"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public DiagnosticName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticName"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        public DiagnosticName(string name,TransportType type)
        {
            Name = string.Format(name,type);
        }
    }
}