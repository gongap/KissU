using System;
using System.Collections.Generic;
using Autofac;

using KissU.EventBus;
using KissU.EventBus.Events;
using KissU.EventBus.Implementation;
using KissU.Modularity;
using KissU.EventBusKafka.Configurations;
using KissU.EventBusKafka.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.EventBusKafka
{
    /// <summary>
    /// ContainerBuilderExtensions.
    /// </summary>
    public static class ServiceBuilderExtensions
    {
        /// <summary>
        /// 使用KafkaMQ进行传输。
        /// </summary>
        /// <param name="builder">服务构建者。</param>
        /// <param name="options">The options.</param>
        /// <returns>服务构建者。</returns>
        public static IServiceBuilder UseKafkaMQTransport(this IServiceBuilder builder, Action<KafkaOptions> options)
        {
            AppConfig.Options = new KafkaOptions();
            var section = CPlatform.AppConfig.GetSection("Kafka");
            if (section.Exists())
                AppConfig.Options = section.Get<KafkaOptions>();
            else if (AppConfig.Configuration != null)
                AppConfig.Options = AppConfig.Configuration.Get<KafkaOptions>();
            options.Invoke(AppConfig.Options);
            AppConfig.KafkaConsumerConfig = AppConfig.Options.GetConsumerConfig();
            AppConfig.KafkaProducerConfig = AppConfig.Options.GetProducerConfig();
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.RegisterType(typeof(Implementation.EventBusKafka)).As(typeof(IEventBus)).SingleInstance();
            containerBuilder.RegisterType(typeof(DefaultConsumeConfigurator)).As(typeof(IConsumeConfigurator))
                .SingleInstance();
            containerBuilder.RegisterType(typeof(InMemoryEventBusSubscriptionsManager))
                .As(typeof(IEventBusSubscriptionsManager)).SingleInstance();
            containerBuilder.RegisterType(typeof(KafkaProducerPersistentConnection))
                .Named(KafkaConnectionType.Producer.ToString(), typeof(IKafkaPersisterConnection)).SingleInstance();
            containerBuilder.RegisterType(typeof(KafkaConsumerPersistentConnection))
                .Named(KafkaConnectionType.Consumer.ToString(), typeof(IKafkaPersisterConnection)).SingleInstance();
            return builder;
        }

        /// <summary>
        /// Uses the kafka mq event adapt.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="adapt">The adapt.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder UseKafkaMQEventAdapt(this IServiceBuilder builder,
            Func<IServiceProvider, ISubscriptionAdapt> adapt)
        {
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.RegisterAdapter(adapt);
            return builder;
        }

        /// <summary>
        /// Adds the kafka mq adapt.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IServiceBuilder.</returns>
        public static IServiceBuilder AddKafkaMQAdapt(this IServiceBuilder builder)
        {
            return builder.UseKafkaMQEventAdapt(provider =>
                new KafkaSubscriptionAdapt(
                    provider.GetService<IConsumeConfigurator>(),
                    provider.GetService<IEnumerable<IIntegrationEventHandler>>()
                )
            );
        }
    }
}