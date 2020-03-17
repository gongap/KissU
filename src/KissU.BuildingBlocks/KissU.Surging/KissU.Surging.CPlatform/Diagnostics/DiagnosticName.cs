using System;

namespace KissU.Surging.CPlatform.Diagnostics
{
    /// <summary>
    /// 诊断名称.
    /// Implements the <see cref="Attribute" />
    /// </summary>
    /// <seealso cref="Attribute" />
    public class DiagnosticName : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticName" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public DiagnosticName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticName" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        public DiagnosticName(string name, TransportType type)
        {
            Name = string.Format(name, type);
        }

        /// <summary>
        /// 名称.
        /// </summary>
        public string Name { get; }
    }
}