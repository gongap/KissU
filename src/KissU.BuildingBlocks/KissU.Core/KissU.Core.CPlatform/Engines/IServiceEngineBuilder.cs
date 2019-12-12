using System;
using System.Collections.Generic;
using Autofac;

namespace KissU.Core.CPlatform.Engines
{
   public interface IServiceEngineBuilder
    {
        void Build(ContainerBuilder serviceContainer);

        ValueTuple<List<Type>,IEnumerable<string>>? ReBuild(ContainerBuilder serviceContainer);
    }
}
