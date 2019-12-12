using System;
using System.Collections.Generic;

namespace KissU.Core.EventBusKafka
{
   public interface IConsumeConfigurator
    {
        void Configure(List<Type> consumers);

        void Unconfigure(List<Type> consumers);
    }
}
