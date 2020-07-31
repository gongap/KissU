using Autofac;
using KissU.Modularity;
using KissU.Surging.Apm.Skywalking.Abstractions;
using KissU.Surging.Apm.Skywalking.Abstractions.Config;
using KissU.Surging.Apm.Skywalking.Abstractions.Tracing;
using KissU.Surging.Apm.Skywalking.Abstractions.Transport;
using KissU.Surging.Apm.Skywalking.Abstractions.Transport.V5;
using KissU.Surging.Apm.Skywalking.Configuration;
using KissU.Surging.Apm.Skywalking.Core;
using KissU.Surging.Apm.Skywalking.Core.Common;
using KissU.Surging.Apm.Skywalking.Core.Diagnostics;
using KissU.Surging.Apm.Skywalking.Core.Sampling;
using KissU.Surging.Apm.Skywalking.Core.Service;
using KissU.Surging.Apm.Skywalking.Core.Tracing;
using KissU.Surging.Apm.Skywalking.Core.Transport;
using KissU.Surging.Apm.Skywalking.Transport.Grpc;
using KissU.Surging.Apm.Skywalking.Transport.Grpc.V5;
using KissU.Surging.Apm.Skywalking.Transport.Grpc.V6;
using KissU.Surging.CPlatform.Diagnostics;

namespace KissU.Surging.Apm.Skywalking
{
    public static class ServiceBuilderExtensions
    {
        public static IServiceBuilder UseSkywalking(this IServiceBuilder builder)
        {
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.RegisterType<AsyncQueueSegmentDispatcher>().As<ISegmentDispatcher>().SingleInstance();
            containerBuilder.RegisterType<RegisterService>().As<IExecutionService>().SingleInstance();
            containerBuilder.RegisterType<PingService>().As<IExecutionService>().SingleInstance();
            containerBuilder.RegisterType<ServiceDiscoveryV5Service>().As<IExecutionService>().SingleInstance();
            containerBuilder.RegisterType<SegmentReportService>().As<IExecutionService>().SingleInstance();
            containerBuilder.RegisterType<InstrumentStartup>().As<IInstrumentStartup>().SingleInstance();
            containerBuilder.Register(p => RuntimeEnvironment.Instance).SingleInstance();
            containerBuilder.RegisterType<TracingDiagnosticProcessorObserver>().SingleInstance();
            containerBuilder.RegisterType<ConfigAccessor>().As<IConfigAccessor>().SingleInstance();
            containerBuilder.RegisterType<ConfigurationFactory>().As<IConfigurationFactory>().SingleInstance();
            containerBuilder.RegisterType<HostingEnvironmentProvider>().As<IEnvironmentProvider>().SingleInstance();
           return  AddTracing(builder).AddSampling().AddGrpcTransport();
        }

        private static IServiceBuilder AddTracing(this IServiceBuilder builder)
        {
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.RegisterType<TracingContext>().As<ITracingContext>().SingleInstance();
            containerBuilder.RegisterType<CarrierPropagator>().As<ICarrierPropagator>().SingleInstance();
            containerBuilder.RegisterType<Sw3CarrierFormatter>().As<ICarrierFormatter>().SingleInstance();
            containerBuilder.RegisterType<Sw6CarrierFormatter>().As<ICarrierFormatter>().SingleInstance();
            containerBuilder.RegisterType<SegmentContextFactory>().As<ISegmentContextFactory>().SingleInstance();
            containerBuilder.RegisterType<EntrySegmentContextAccessor>().As<IEntrySegmentContextAccessor>().SingleInstance();
            containerBuilder.RegisterType<LocalSegmentContextAccessor>().As<ILocalSegmentContextAccessor>().SingleInstance();
            containerBuilder.RegisterType<ExitSegmentContextAccessor>().As<IExitSegmentContextAccessor>().SingleInstance();
            containerBuilder.RegisterType<SamplerChainBuilder>().As<ISamplerChainBuilder>().SingleInstance();
            containerBuilder.RegisterType<UniqueIdGenerator>().As<IUniqueIdGenerator>().SingleInstance();
            containerBuilder.RegisterType<UniqueIdParser>().As<IUniqueIdParser>().SingleInstance();
            containerBuilder.RegisterType<SegmentContextMapper>().As<ISegmentContextMapper>().SingleInstance();
            containerBuilder.RegisterType<Base64Formatter>().As<IBase64Formatter>().SingleInstance();
            return builder;
        }

        private static  IServiceBuilder AddSampling(this IServiceBuilder builder)
        {
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.RegisterType<SimpleCountSamplingInterceptor>().SingleInstance();
            containerBuilder.Register<ISamplingInterceptor>(p => p.Resolve<SimpleCountSamplingInterceptor>()).SingleInstance();
            containerBuilder.Register<IExecutionService>(p => p.Resolve<SimpleCountSamplingInterceptor>()).SingleInstance();
            containerBuilder.RegisterType<RandomSamplingInterceptor>().As<ISamplingInterceptor>().SingleInstance();
            return builder;
        }

        private static IServiceBuilder AddGrpcTransport(this IServiceBuilder builder)
        {
            var services = builder.ContainerBuilder;
            services.RegisterType<SkyApmClientV5>().As<ISkyApmClientV5>().SingleInstance();
            services.RegisterType<Transport.Grpc.SegmentReporter>().As<ISegmentReporter>().SingleInstance();
            services.RegisterType<ConnectionManager>().SingleInstance();
            services.RegisterType<PingCaller>().As<IPingCaller>().SingleInstance();
            services.RegisterType<ServiceRegister>().As<IServiceRegister>().SingleInstance();
            services.RegisterType<ConnectService>().As<IExecutionService>().SingleInstance();
            return builder;
        }
    }
}
