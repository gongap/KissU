using System;
using Autofac;

namespace KissU.Core.ServiceHosting.Internal
{
   public interface IServiceHost : IDisposable
    {
        IDisposable Run();

        IContainer Initialize();
    }
}
