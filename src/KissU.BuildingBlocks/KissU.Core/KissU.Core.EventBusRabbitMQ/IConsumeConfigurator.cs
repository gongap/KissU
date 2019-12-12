using System;
using System.Collections.Generic;

namespace KissU.Core.EventBusRabbitMQ
{
   public  interface IConsumeConfigurator
    {
        void Configure(List<Type> consumers);

        void Unconfigure(List<Type> consumers);
    }
}
