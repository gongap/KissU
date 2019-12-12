﻿using System;
using System.Collections.Generic;
using KissU.Core.CPlatform.Engines;
using KissU.Core.CPlatform.EventBus;
using KissU.Core.CPlatform.EventBus.Events;
using KissU.Core.CPlatform.EventBus.Implementation;
using KissU.Core.CPlatform.Module;
using KissU.Core.EventBusKafka.Configurations;
using KissU.Core.EventBusKafka.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Core.EventBusKafka
{
    public class EventBusKafkaModule : EnginePartModule
    {
        public override void Initialize(AppModuleContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            base.Initialize(context);
            serviceProvider.GetInstances<ISubscriptionAdapt>().SubscribeAt();
            serviceProvider.GetInstances<IServiceEngineLifetime>().ServiceEngineStarted.Register(() =>
             {
                 KafkaConsumerPersistentConnection connection = serviceProvider.GetInstances<IKafkaPersisterConnection>(KafkaConnectionType.Consumer.ToString()) as KafkaConsumerPersistentConnection;
                 connection.Listening(TimeSpan.FromMilliseconds(AppConfig.Options.Timeout));
            });
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder"></param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            UseKafkaMQTransport(builder).AddKafkaMQAdapt(builder);
        }

        public  EventBusKafkaModule UseKafkaMQTransport(ContainerBuilderWrapper builder)
        {
            AppConfig.Options = new KafkaOptions();
            var section = CPlatform.AppConfig.GetSection("EventBus_Kafka");
            if (section.Exists())
                AppConfig.Options = section.Get<KafkaOptions>();
            else if (AppConfig.Configuration != null)
                AppConfig.Options = AppConfig.Configuration.Get<KafkaOptions>();
            AppConfig.KafkaConsumerConfig = AppConfig.Options.GetConsumerConfig();
            AppConfig.KafkaProducerConfig = AppConfig.Options.GetProducerConfig();
            builder.RegisterType(typeof(Implementation.EventBusKafka)).As(typeof(IEventBus)).SingleInstance();
            builder.RegisterType(typeof(DefaultConsumeConfigurator)).As(typeof(IConsumeConfigurator)).SingleInstance();
            builder.RegisterType(typeof(InMemoryEventBusSubscriptionsManager)).As(typeof(IEventBusSubscriptionsManager)).SingleInstance();
            builder.RegisterType(typeof(KafkaProducerPersistentConnection))
           .Named(KafkaConnectionType.Producer.ToString(), typeof(IKafkaPersisterConnection)).SingleInstance();
            builder.RegisterType(typeof(KafkaConsumerPersistentConnection))
            .Named(KafkaConnectionType.Consumer.ToString(), typeof(IKafkaPersisterConnection)).SingleInstance();
            return this;
        }

        public  ContainerBuilderWrapper UseKafkaMQEventAdapt(ContainerBuilderWrapper builder, Func<IServiceProvider, ISubscriptionAdapt> adapt)
        {
            builder.RegisterAdapter(adapt);
            return builder;
        }

        public  EventBusKafkaModule AddKafkaMQAdapt(ContainerBuilderWrapper builder)
        {
              UseKafkaMQEventAdapt(builder,provider =>
             new KafkaSubscriptionAdapt(
                 provider.GetService<IConsumeConfigurator>(),
                 provider.GetService<IEnumerable<IIntegrationEventHandler>>()
                 )
            );
            return this;
        }
    }
}
