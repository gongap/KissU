using System.Collections.Generic;

namespace KissU.Core.CPlatform.Module
{
    public interface IModuleProvider
    {
        List<AbstractModule> Modules { get; }

        string[] VirtualPaths { get; }
        void Initialize();
    }
}
