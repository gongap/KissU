using System;
using System.Collections.Generic;

namespace KissU.Modules.Application.Configurations.ObjectExtending
{
    [Serializable]
    public class ModuleExtensionDto
    {
        public Dictionary<string, EntityExtensionDto> Entities { get; set; }

        public Dictionary<string, object> Configuration { get; set; }
    }
}