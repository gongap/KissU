using JetBrains.Annotations;

namespace KissU.Modules.Application.Configurations.ObjectExtending
{
    public class ExtensionPropertyApiDto
    {
        [NotNull]
        public ExtensionPropertyApiGetDto OnGet { get; set; }

        [NotNull]
        public ExtensionPropertyApiCreateDto OnCreate { get; set; }

        [NotNull]
        public ExtensionPropertyApiUpdateDto OnUpdate { get; set; }

        public ExtensionPropertyApiDto()
        {
            OnGet = new ExtensionPropertyApiGetDto();
            OnCreate = new ExtensionPropertyApiCreateDto();
            OnUpdate = new ExtensionPropertyApiUpdateDto();
        }
    }
}