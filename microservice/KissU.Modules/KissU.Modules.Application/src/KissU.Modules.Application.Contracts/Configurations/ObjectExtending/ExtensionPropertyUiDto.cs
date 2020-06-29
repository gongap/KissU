using System;

namespace KissU.Modules.Application.Configurations.ObjectExtending
{
    [Serializable]
    public class ExtensionPropertyUiDto
    {
        public ExtensionPropertyUiTableDto OnTable { get; set; }
        public ExtensionPropertyUiFormDto OnCreateForm { get; set; }
        public ExtensionPropertyUiFormDto OnEditForm { get; set; }
    }
}