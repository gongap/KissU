using System;
using System.Collections.Generic;

namespace KissU.Modules.Application.Configurations.ObjectExtending
{
    [Serializable]
    public class ObjectExtensionsDto
    {
        public Dictionary<string, ModuleExtensionDto> Modules { get; set; }
        
        public Dictionary<string, ExtensionEnumDto> Enums { get; set; }
    }
}