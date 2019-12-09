// <copyright file="UtilModule.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Core.Util
{
    using System.Text;
    using Autofac;
    using Surging.Core.CPlatform.Module;
    using Util.Helpers;

    /// <inheritdoc />
    public class UtilModule : SystemModule
    {
        /// <inheritdoc />
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
            Ioc.Register(context.ServiceProvoider.Current as IContainer);
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder"></param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Bootstrapper.Run(builder.ContainerBuilder);
        }
    }
}
