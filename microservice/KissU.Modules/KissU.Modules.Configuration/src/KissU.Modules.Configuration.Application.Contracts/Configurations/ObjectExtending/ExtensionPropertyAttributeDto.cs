using System;
using System.Collections.Generic;

namespace KissU.Modules.Application.Configurations.ObjectExtending
{
    [Serializable]
    public class ExtensionPropertyAttributeDto
    {
        public string TypeSimple { get; set; }

        public Dictionary<string, object> Config { get; set; }
    }
}