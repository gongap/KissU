using System;
using System.Collections.Generic;

namespace KissU.Modules.Application.Configurations.ObjectExtending
{
    [Serializable]
    public class ExtensionEnumDto
    {
        public List<ExtensionEnumFieldDto> Fields { get; set; }

        public string LocalizationResource { get; set; }
    }
}