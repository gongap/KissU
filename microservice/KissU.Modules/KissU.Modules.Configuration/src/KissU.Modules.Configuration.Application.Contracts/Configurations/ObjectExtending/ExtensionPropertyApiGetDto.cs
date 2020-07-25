using System;

namespace KissU.Modules.Application.Configurations.ObjectExtending
{
    [Serializable]
    public class ExtensionPropertyApiGetDto
    {
        /// <summary>
        /// Default: true.
        /// </summary>
        public bool IsAvailable { get; set; } = true;
    }
}