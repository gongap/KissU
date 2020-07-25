using System;

namespace KissU.Modules.Application.Configurations.ObjectExtending
{
    [Serializable]
    public class ExtensionEnumFieldDto
    {
        public string Name { get; set; }

        public object Value { get; set; }
    }
}