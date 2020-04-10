using Autofac;
using KissU.Apm.Skywalking.Abstractions;
using KissU.Apm.Skywalking.Abstractions.Config;
using KissU.Apm.Skywalking.Abstractions.Tracing;
using KissU.Apm.Skywalking.Abstractions.Transport;
using KissU.Apm.Skywalking.Abstractions.Transport.V5;
using KissU.Apm.Skywalking.Configuration;
using KissU.Apm.Skywalking.Core;
using KissU.Apm.Skywalking.Core.Common;
using KissU.Apm.Skywalking.Core.Diagnostics;
using KissU.Apm.Skywalking.Core.Sampling;
using KissU.Apm.Skywalking.Core.Service;
using KissU.Apm.Skywalking.Core.Tracing;
using KissU.Apm.Skywalking.Core.Transport;
using KissU.Apm.Skywalking.Transport.Grpc;
using KissU.Apm.Skywalking.Transport.Grpc.V5;
using KissU.Apm.Skywalking.Transport.Grpc.V6;
using KissU.Core;
using KissU.Surging.CPlatform.Diagnostics;

namespace KissU.Apm.Skywalking
{
    public static class ContainerBuilderExtensions
    {
        public static IServiceBuilder UseSkywalking(this IServiceBuilder builder)
        {
            var services = builder.Services;
            services.RegisterType<AsyncQueueSegmentDispatcher>().As<ISegmentDispatcher>().SingleInstance();
            services.RegisterType<RegisterService>().As<IExecutionService>().SingleInstance();
            services.RegisterType<PingService>().As<IExecutionService>().SingleInstance();
            services.RegisterType<ServiceDiscoveryV5Service>().As<IExecutionService>().SingleInstance();
            services.RegisterType<SegmentReportService>().As<IExecutionService>().SingleInstance();
            services.RegisterType<InstrumentStartup>().As<IInstrumentStartup>().SingleInstance();
            services.Register(p => RuntimeEnvironment.Instance).SingleInstance();
            services.RegisterType<TracingDiagnosticProcessorObserver>().SingleInstance();
            services.RegisterType<ConfigAccessor>().As<IConfigAccessor>().SingleInstance();
            services.RegisterType<ConfigurationFactory>().As<IConfigurationFactory>().SingleInstance();
            services.RegisterType<HostingEnvironmentProvider>().As<IEnvironmentProvider>().SingleInstance();
           return  AddTracing(builder).AddSampling().AddGrpcTransport();
        }

        private static IServiceBuilder AddTracing(this IServiceBuilder builder)
        {
            var services = builder.Services;
            services.RegisterType<TracingContext>().As<ITracingContext>().SingleInstance();
            services.RegisterType<CarrierPropagator>().As<ICarrierPropagator>().SingleInstance();
            services.RegisterType<Sw3CarrierFormatter>().As<ICarrierFormatter>().SingleInstance();
            services.RegisterType<Sw6CarrierFormatter>().As<ICarrierFormatter>().SingleInstance();
            services.RegisterType<SegmentContextFactory>().As<ISegmentContextFactory>().SingleInstance();
            services.RegisterType<EntrySegmentContextAccessor>().As<IEntrySegmentContextAccessor>().SingleInstance();
            services.RegisterType<LocalSegmentContextAccessor>().As<ILocalSegmentContextAccessor>().SingleInstance();
            services.RegisterType<ExitSegmentContextAccessor>().As<IExitSegmentContextAccessor>().SingleInstance();
            services.RegisterType<SamplerChainBuilder>().As<ISamplerChainBuilder>().SingleInstance();
            services.RegisterType<UniqueIdGenerator>().As<IUniqueIdGenerator>().SingleInstance();
            services.RegisterType<UniqueIdParser>().As<IUniqueIdParser>().SingleInstance();
            services.RegisterType<SegmentContextMapper>().As<ISegmentContextMapper>().SingleInstance();
            services.RegisterType<Base64Formatter>().As<IBase64Formatter>().SingleInstance();
            return builder;
        }

        private static  IServiceBuilder AddSampling(this IServiceBuilder builder)
        {
            var services = builder.Services;
            services.RegisterType<SimpleCountSamplingInterceptor>().SingleInstance();
            services.Register<ISamplingInterceptor>(p => p.Resolve<SimpleCountSamplingInterceptor>()).SingleInstance();
            services.Register<IExecutionService>(p => p.Resolve<SimpleCountSamplingInterceptor>()).SingleInstance();
            services.RegisterType<RandomSamplingInterceptor>().As<ISamplingInterceptor>().SingleInstance();
            return builder;
        }

        private static IServiceBuilder AddGrpcTransport(this IServiceBuilder builder)
        {
            var services = builder.Services;
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
