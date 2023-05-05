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
    public class SkywalkingModule : EnginePartModule
    {
        public override void Initialize(ModuleInitializationContext context)
        {
            base.Initialize(context);
            context.ServiceProvoider.GetInstances<IInstrumentStartup>().StartAsync();
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder"></param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterType<AsyncQueueSegmentDispatcher>().As<ISegmentDispatcher>().SingleInstance();
            builder.RegisterType<RegisterService>().As<IExecutionService>().SingleInstance();
            builder.RegisterType<LogReportService>().As<IExecutionService>().SingleInstance();
            builder.RegisterType<PingService>().As<IExecutionService>().SingleInstance();
            builder.RegisterType<SegmentReportService>().As<IExecutionService>().SingleInstance();
            builder.RegisterType<CLRStatsService>().As<IExecutionService>().SingleInstance();
            builder.RegisterType<InstrumentStartup>().As<IInstrumentStartup>().SingleInstance();
            builder.Register(p => RuntimeEnvironment.Instance).SingleInstance();
            builder.RegisterType<TracingDiagnosticProcessorObserver>().SingleInstance();
            builder.RegisterType<ConfigAccessor>().As<IConfigAccessor>().SingleInstance();
            builder.RegisterType<ConfigurationFactory>().As<IConfigurationFactory>().SingleInstance();
            builder.RegisterType<HostingEnvironmentProvider>().As<IEnvironmentProvider>().SingleInstance();
            AddTracing(builder).AddSkyApmLogger(builder).AddSampling(builder).AddGrpcTransport(builder).AddSkyApmLogging(builder).AddPushSkyApmLogger(builder);
        }

        private SkywalkingModule AddTracing(ContainerBuilderWrapper builder)
        {
            builder.RegisterType<TracingContext>().As<ITracingContext>().SingleInstance();
            builder.RegisterType<CarrierPropagator>().As<ICarrierPropagator>().SingleInstance();
            builder.RegisterType<Sw8CarrierFormatter>().As<ICarrierFormatter>().SingleInstance();
            builder.RegisterType<SegmentContextFactory>().As<ISegmentContextFactory>().SingleInstance();
            builder.RegisterType<EntrySegmentContextAccessor>().As<IEntrySegmentContextAccessor>().SingleInstance();
            builder.RegisterType<LocalSegmentContextAccessor>().As<ILocalSegmentContextAccessor>().SingleInstance();
            builder.RegisterType<ExitSegmentContextAccessor>().As<IExitSegmentContextAccessor>().SingleInstance();
            builder.RegisterType<SamplerChainBuilder>().As<ISamplerChainBuilder>().SingleInstance();
            builder.RegisterType<UniqueIdGenerator>().As<IUniqueIdGenerator>().SingleInstance();
            builder.RegisterType<SegmentContextMapper>().As<ISegmentContextMapper>().SingleInstance();
            builder.RegisterType<Base64Formatter>().As<IBase64Formatter>().SingleInstance();
            return this;
        }

        private SkywalkingModule AddSkyApmLogger(ContainerBuilderWrapper builder)
        {
            builder.RegisterType<AsyncQueueSkyApmLogDispatcher>().As<ISkyApmLogDispatcher>().SingleInstance();
            builder.RegisterType<LoggerContextContextMapper>().As<ILoggerContextContextMapper>().SingleInstance();
            return this;
        }

        private SkywalkingModule AddSampling(ContainerBuilderWrapper builder)
        {
            builder.RegisterType<SimpleCountSamplingInterceptor>().SingleInstance();
            builder.Register<ISamplingInterceptor>(p => p.Resolve<SimpleCountSamplingInterceptor>()).SingleInstance();
            builder.Register<IExecutionService>(p => p.Resolve<SimpleCountSamplingInterceptor>()).SingleInstance();
            builder.RegisterType<RandomSamplingInterceptor>().As<ISamplingInterceptor>().SingleInstance();
            builder.RegisterType<IgnorePathSamplingInterceptor>().As<ISamplingInterceptor>().SingleInstance();
            return this;
        }

        private SkywalkingModule AddGrpcTransport(ContainerBuilderWrapper builder)
        {
            builder.RegisterType<SegmentReporter>().As<ISegmentReporter>().SingleInstance();
            builder.RegisterType<LoggerReporter>().As<ILoggerReporter>().SingleInstance();
            builder.RegisterType<CLRStatsReporter>().As<ICLRStatsReporter>().SingleInstance();
            builder.RegisterType<ConnectionManager>().As<ConnectionManager>().SingleInstance();
            builder.RegisterType<PingCaller>().As<IPingCaller>().SingleInstance();
            builder.RegisterType<ServiceRegister>().As<IServiceRegister>().SingleInstance();
            builder.RegisterType<ConnectService>().As<IExecutionService>().SingleInstance();
            return this; 
        }

        private SkywalkingModule AddSkyApmLogging(ContainerBuilderWrapper builder)
        {
            builder.RegisterType<ApmLoggerFactory>().As<ILoggerFactory>().SingleInstance();
            return this; 
        }

        private SkywalkingModule AddPushSkyApmLogger(ContainerBuilderWrapper builder)
        {
            builder.RegisterType<SkyApmLogger>().As<ISkyApmLogger>().SingleInstance();
            return this; 
        }
    }
}
