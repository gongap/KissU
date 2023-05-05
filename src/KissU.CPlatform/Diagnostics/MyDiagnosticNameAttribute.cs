using System;

namespace KissU.CPlatform.Diagnostics
{
    /// <summary>
    /// 诊断名称.
    /// Implements the <see cref="Attribute" />
    /// </summary>
    /// <seealso cref="Attribute" />
    public class MyDiagnosticNameAttribute  : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyDiagnosticNameAttribute" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        public MyDiagnosticNameAttribute(string name, TransportType type)
        {
            Name = string.Format(name, type);
        }
        
        public  string Name { get; }
    }
}