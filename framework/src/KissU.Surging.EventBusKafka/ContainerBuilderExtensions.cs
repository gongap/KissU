using System;
using System.Collections.Generic;
using Autofac;

using KissU.EventBus;
using KissU.EventBus.Events;
using KissU.EventBus.Implementation;
using KissU.Module;
using KissU.Surging.EventBusKafka.Configurations;
using KissU.Surging.EventBusKafka.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Surging.EventBusKafka
{
    /// <summary>
    /// ContainerBuilderExtensions.
    /// </summary>
    public static class ContainerBuilderExtensions
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
            var services = builder.Services;
            builder.Services.RegisterType(typeof(Implementation.EventBusKafka)).As(typeof(IEventBus)).SingleInstance();
            builder.Services.RegisterType(typeof(DefaultConsumeConfigurator)).As(typeof(IConsumeConfigurator))
                .SingleInstance();
            builder.Services.RegisterType(typeof(InMemoryEventBusSubscriptionsManager))
                .As(typeof(IEventBusSubscriptionsManager)).SingleInstance();
            builder.Services.RegisterType(typeof(KafkaProducerPersistentConnection))
                .Named(KafkaConnectionType.Producer.ToString(), typeof(IKafkaPersisterConnection)).SingleInstance();
            builder.Services.RegisterType(typeof(KafkaConsumerPersistentConnection))
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
            var services = builder.Services;
            services.RegisterAdapter(adapt);
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