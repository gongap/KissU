using Autofac;
using KissU.Logging;
using KissU.Modularity;
using SkyApm;
using SkyApm.Config;
using SkyApm.Diagnostics;
using SkyApm.Logging;
using SkyApm.Sampling;
using SkyApm.Service;
using SkyApm.Tracing;
using SkyApm.Transport;
using SkyApm.Transport.Grpc;
using SkyApm.Utilities.Configuration;

namespace KissU.Apm.Skywalking
{
    public static class ServiceBuilderExtensions
    {
        public static IServiceBuilder UseSkywalking(this IServiceBuilder builder)
        {
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.RegisterType<AsyncQueueSegmentDispatcher>().As<ISegmentDispatcher>().SingleInstance();
            containerBuilder.RegisterType<RegisterService>().As<IExecutionService>().SingleInstance();
            containerBuilder.RegisterType<LogReportService>().As<IExecutionService>().SingleInstance();
            containerBuilder.RegisterType<PingService>().As<IExecutionService>().SingleInstance();
            containerBuilder.RegisterType<SegmentReportService>().As<IExecutionService>().SingleInstance();
            containerBuilder.RegisterType<CLRStatsService>().As<IExecutionService>().SingleInstance();
            containerBuilder.RegisterType<InstrumentStartup>().As<IInstrumentStartup>().SingleInstance();
            containerBuilder.Register(p => RuntimeEnvironment.Instance).SingleInstance();
            containerBuilder.RegisterType<TracingDiagnosticProcessorObserver>().SingleInstance();
            containerBuilder.RegisterType<ConfigAccessor>().As<IConfigAccessor>().SingleInstance();
            containerBuilder.RegisterType<ConfigurationFactory>().As<IConfigurationFactory>().SingleInstance();
            containerBuilder.RegisterType<HostingEnvironmentProvider>().As<IEnvironmentProvider>().SingleInstance();
           return AddTracing(builder).AddSkyApmLogger().AddSampling().AddGrpcTransport().AddSkyApmLogging().AddPushSkyApmLogger();
        }

        private static IServiceBuilder AddTracing(this IServiceBuilder builder)
        {
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.RegisterType<TracingContext>().As<ITracingContext>().SingleInstance();
            containerBuilder.RegisterType<CarrierPropagator>().As<ICarrierPropagator>().SingleInstance();
            containerBuilder.RegisterType<Sw8CarrierFormatter>().As<ICarrierFormatter>().SingleInstance();
            containerBuilder.RegisterType<SegmentContextFactory>().As<ISegmentContextFactory>().SingleInstance();
            containerBuilder.RegisterType<EntrySegmentContextAccessor>().As<IEntrySegmentContextAccessor>().SingleInstance();
            containerBuilder.RegisterType<LocalSegmentContextAccessor>().As<ILocalSegmentContextAccessor>().SingleInstance();
            containerBuilder.RegisterType<ExitSegmentContextAccessor>().As<IExitSegmentContextAccessor>().SingleInstance();
            containerBuilder.RegisterType<SamplerChainBuilder>().As<ISamplerChainBuilder>().SingleInstance();
            containerBuilder.RegisterType<UniqueIdGenerator>().As<IUniqueIdGenerator>().SingleInstance();
            containerBuilder.RegisterType<SegmentContextMapper>().As<ISegmentContextMapper>().SingleInstance();
            containerBuilder.RegisterType<Base64Formatter>().As<IBase64Formatter>().SingleInstance();

            return builder;
        }

        public static IServiceBuilder AddSkyApmLogger(this IServiceBuilder builder)
        {
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.RegisterType<AsyncQueueSkyApmLogDispatcher>().As<ISkyApmLogDispatcher>().SingleInstance();
            containerBuilder.RegisterType<LoggerContextContextMapper>().As<ILoggerContextContextMapper>().SingleInstance();
            return builder;
        }

        private static  IServiceBuilder AddSampling(this IServiceBuilder builder)
        {
            var containerBuilder = builder.ContainerBuilder;
            containerBuilder.RegisterType<SimpleCountSamplingInterceptor>().SingleInstance();
            containerBuilder.Register<ISamplingInterceptor>(p => p.Resolve<SimpleCountSamplingInterceptor>()).SingleInstance();
            containerBuilder.Register<IExecutionService>(p => p.Resolve<SimpleCountSamplingInterceptor>()).SingleInstance();
            containerBuilder.RegisterType<RandomSamplingInterceptor>().As<ISamplingInterceptor>().SingleInstance();
            containerBuilder.RegisterType<IgnorePathSamplingInterceptor>().As<ISamplingInterceptor>().SingleInstance();
            return builder;
        }

        private static IServiceBuilder AddGrpcTransport(this IServiceBuilder builder)
        {
            var services = builder.ContainerBuilder;
            services.RegisterType<ConnectService>().As<ISegmentReporter>().SingleInstance();
            services.RegisterType<ConnectService>().As<ILoggerReporter>().SingleInstance();
            services.RegisterType<ConnectService>().As<ICLRStatsReporter>().SingleInstance();
            services.RegisterType<ConnectionManager>().SingleInstance();
            services.RegisterType<PingCaller>().As<IPingCaller>().SingleInstance();
            services.RegisterType<ServiceRegister>().As<IServiceRegister>().SingleInstance();
            services.RegisterType<ConnectService>().As<IExecutionService>().SingleInstance();
            return builder;
        }

        private static IServiceBuilder AddSkyApmLogging(this IServiceBuilder builder)
        {
            var services = builder.ContainerBuilder;
            services.RegisterType<ApmLoggerFactory>().As<ILoggerFactory>().SingleInstance();
            return builder;
        }

        private static IServiceBuilder AddPushSkyApmLogger(this IServiceBuilder builder)
        {
            var services = builder.ContainerBuilder;
            services.RegisterType<SkyApmLogger>().As<ISkyApmLogger>().SingleInstance();
            return builder; 
        }
    }
}
