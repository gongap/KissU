using System;
using System.Collections.Generic;
using System.Net;
using KissU.Core.CPlatform.Support;

namespace KissU.Core.CPlatform.Configurations
{
    /// <summary>
    /// 服务器引擎选项.
    /// Implements the <see cref="ServiceCommand" />
    /// </summary>
    /// <seealso cref="ServiceCommand" />
    public partial class ServerEngineOptions : ServiceCommand
    {
        /// <summary>
        /// Gets or sets the ip.
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// Gets or sets the mapping ip.
        /// </summary>
        public string MappingIP { get; set; }

        /// <summary>
        /// Gets or sets the mapping port.
        /// </summary>
        public int MappingPort { get; set; }

        /// <summary>
        /// Gets or sets the wan ip.
        /// </summary>
        public string WanIp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is module per lifetime scope.
        /// </summary>
        public bool IsModulePerLifetimeScope { get; set; }

        /// <summary>
        /// Gets or sets the watch interval.
        /// </summary>
        public double WatchInterval { get; set; } = 20d;

        /// <summary>
        /// Gets or sets the disconn time interval.
        /// </summary>
        public int DisconnTimeInterval { get; set; } = 60;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ServerEngineOptions" /> is libuv.
        /// </summary>
        public bool Libuv { get; set; } = false;

        /// <summary>
        /// Gets or sets the docker deploy mode.
        /// </summary>
        public DockerDeployMode DockerDeployMode { get; set; } = DockerDeployMode.Standard;

        /// <summary>
        /// Gets or sets the so backlog.
        /// </summary>
        public int SoBacklog { get; set; } = 8192;

        /// <summary>
        /// Gets or sets a value indicating whether [enable route watch].
        /// </summary>
        public bool EnableRouteWatch { get; set; }

        /// <summary>
        /// Gets or sets the ip endpoint.
        /// </summary>
        public IPEndPoint IpEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the packages.
        /// </summary>
        public List<ModulePackage> Packages { get; set; } = new List<ModulePackage>();

        /// <summary>
        /// Gets or sets the protocol.
        /// </summary>
        public CommunicationProtocol Protocol { get; set; }

        /// <summary>
        /// Gets or sets the root path.
        /// </summary>
        public string RootPath { get; set; }

        /// <summary>
        /// Gets or sets the web root path.
        /// </summary>
        public string WebRootPath { get; set; } = AppContext.BaseDirectory;

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [disable service registration].
        /// </summary>
        public bool DisableServiceRegistration { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [disable diagnostic].
        /// </summary>
        public bool DisableDiagnostic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [reload on change].
        /// </summary>
        public bool ReloadOnChange { get; set; } = false;

        /// <summary>
        /// Gets or sets the ports.
        /// </summary>
        public ProtocolPortOptions Ports { get; set; } = new ProtocolPortOptions();

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        public string Token { get; set; } = "True";

        /// <summary>
        /// Gets or sets the not related assembly files.
        /// </summary>
        public string NotRelatedAssemblyFiles { get; set; }

        /// <summary>
        /// Gets or sets the related assembly files.
        /// </summary>
        public string RelatedAssemblyFiles { get; set; } = string.Empty;
    }
}
