﻿using Autofac;
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
using KissU.Module;
using KissU.Surging.CPlatform.Diagnostics;

namespace KissU.Surging.Apm.Skywalking
{
    public class SkywalkingModule : EnginePartModule
    {
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
            context.ServiceProvoider.GetInstances<IInstrumentStartup>().StartAsync();
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder"></param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            builder.RegisterType<AsyncQueueSegmentDispatcher>().As<ISegmentDispatcher>().SingleInstance();
            builder.RegisterType<RegisterService>().As<IExecutionService>().SingleInstance();
            builder.RegisterType<PingService>().As<IExecutionService>().SingleInstance();
            builder.RegisterType<ServiceDiscoveryV5Service>().As<IExecutionService>().SingleInstance();
            builder.RegisterType<SegmentReportService>().As<IExecutionService>().SingleInstance();
            builder.RegisterType<InstrumentStartup>().As<IInstrumentStartup>().SingleInstance();
            builder.Register(p => RuntimeEnvironment.Instance).SingleInstance();
            builder.RegisterType<TracingDiagnosticProcessorObserver>().SingleInstance();
            builder.RegisterType<ConfigAccessor>().As<IConfigAccessor>().SingleInstance();
            builder.RegisterType<ConfigurationFactory>().As<IConfigurationFactory>().SingleInstance();
            builder.RegisterType<HostingEnvironmentProvider>().As<IEnvironmentProvider>().SingleInstance();
            AddTracing(builder).AddSampling(builder).AddGrpcTransport(builder);
        }

        private SkywalkingModule AddTracing(ContainerBuilderWrapper builder)
        {
            builder.RegisterType<TracingContext>().As<ITracingContext>().SingleInstance();
            builder.RegisterType<CarrierPropagator>().As<ICarrierPropagator>().SingleInstance();
            builder.RegisterType<Sw3CarrierFormatter>().As<ICarrierFormatter>().SingleInstance();
            builder.RegisterType<Sw6CarrierFormatter>().As<ICarrierFormatter>().SingleInstance();
            builder.RegisterType<SegmentContextFactory>().As<ISegmentContextFactory>().SingleInstance();
            builder.RegisterType<EntrySegmentContextAccessor>().As<IEntrySegmentContextAccessor>().SingleInstance();
            builder.RegisterType<LocalSegmentContextAccessor>().As<ILocalSegmentContextAccessor>().SingleInstance();
            builder.RegisterType<ExitSegmentContextAccessor>().As<IExitSegmentContextAccessor>().SingleInstance();
            builder.RegisterType<SamplerChainBuilder>().As<ISamplerChainBuilder>().SingleInstance();
            builder.RegisterType<UniqueIdGenerator>().As<IUniqueIdGenerator>().SingleInstance();
            builder.RegisterType<UniqueIdParser>().As<IUniqueIdParser>().SingleInstance();
            builder.RegisterType<SegmentContextMapper>().As<ISegmentContextMapper>().SingleInstance();
            builder.RegisterType<Base64Formatter>().As<IBase64Formatter>().SingleInstance();
            return this;
        }

        private SkywalkingModule AddSampling(ContainerBuilderWrapper builder)
        {
            builder.RegisterType<SimpleCountSamplingInterceptor>().SingleInstance();
            builder.Register<ISamplingInterceptor>(p => p.Resolve<SimpleCountSamplingInterceptor>()).SingleInstance();
            builder.Register<IExecutionService>(p => p.Resolve<SimpleCountSamplingInterceptor>()).SingleInstance();
            builder.RegisterType<RandomSamplingInterceptor>().As<ISamplingInterceptor>().SingleInstance();
            return this;
        }

        private SkywalkingModule AddGrpcTransport(ContainerBuilderWrapper builder)
        {
            builder.RegisterType<SkyApmClientV5>().As<ISkyApmClientV5>().SingleInstance();
            builder.RegisterType<Transport.Grpc.SegmentReporter>().As<ISegmentReporter>().SingleInstance();
            builder.RegisterType<ConnectionManager>().SingleInstance();
            builder.RegisterType<PingCaller>().As<IPingCaller>().SingleInstance();
            builder.RegisterType<ServiceRegister>().As<IServiceRegister>().SingleInstance();
            builder.RegisterType<ConnectService>().As<IExecutionService>().SingleInstance();
            return this; 
        }
    }
}
