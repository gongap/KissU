using System;

namespace KissU.Surging.System.Ioc
{
    /// <summary>
    /// ModuleNameAttribute.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ModuleNameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleNameAttribute" /> class.
        /// </summary>
        public ModuleNameAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleNameAttribute" /> class.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        public ModuleNameAttribute(string moduleName)
        {
            ModuleName = moduleName;
        }

        /// <summary>
        /// Gets or sets the name of the module.
        /// </summary>
        public string ModuleName { get; set; }
    }
}