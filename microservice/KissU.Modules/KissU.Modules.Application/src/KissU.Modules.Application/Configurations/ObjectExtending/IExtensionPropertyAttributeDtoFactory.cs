using System;

namespace KissU.Modules.Application.Configurations.ObjectExtending
{
    public interface IExtensionPropertyAttributeDtoFactory
    {
        ExtensionPropertyAttributeDto Create(Attribute attribute);
    }
}