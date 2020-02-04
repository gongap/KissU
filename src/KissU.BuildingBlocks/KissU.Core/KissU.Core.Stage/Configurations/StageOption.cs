using System.Collections.Generic;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace KissU.Core.Stage.Configurations
{
    /// <summary>
    /// StageOption.
    /// </summary>
    public class StageOption
    {
        /// <summary>
        /// Gets or sets a value indicating whether [enable HTTPS].
        /// </summary>
        public bool EnableHttps { get;  set; }

        /// <summary>
        /// Gets or sets the name of the certificate file.
        /// </summary>
        public string CertificateFileName { get;  set; }

        /// <summary>
        /// Gets or sets the certificate location.
        /// </summary>
        public string CertificateLocation { get; set; }

        /// <summary>
        /// Gets or sets the certificate password.
        /// </summary>
        public string CertificatePassword { get;  set; }

        /// <summary>
        /// Gets or sets the HTTPS port.
        /// </summary>
        public string HttpsPort { get;  set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is camel case resolver.
        /// </summary>
        public bool IsCamelCaseResolver { get; set; }

        /// <summary>
        /// Gets or sets the API get way.
        /// </summary>
        public ApiGetwayOption ApiGetWay { get; set; }

        /// <summary>
        /// Gets or sets the protocols.
        /// </summary>
        public HttpProtocols Protocols { get; set; } = HttpProtocols.Http1AndHttp2;

        /// <summary>
        /// Gets or sets the minimum request body data rate.
        /// </summary>
        public DataRateOption MinRequestBodyDataRate { get; set; }

        /// <summary>
        /// Gets or sets the minimum response data rate.
        /// </summary>
        public DataRateOption MinResponseDataRate { get; set; }

        /// <summary>
        /// Gets or sets the maximum size of the request body.
        /// </summary>
        public long? MaxRequestBodySize { get; set; }

        /// <summary>
        /// Gets or sets the maximum concurrent connections.
        /// </summary>
        public long? MaxConcurrentConnections { get; set; }

        /// <summary>
        /// Gets or sets the maximum concurrent upgraded connections.
        /// </summary>
        public long? MaxConcurrentUpgradedConnections { get; set; }

        /// <summary>
        /// Gets or sets the maximum size of the request buffer.
        /// </summary>
        public long? MaxRequestBufferSize { get; set; }

        /// <summary>
        /// Gets or sets the maximum request header count.
        /// </summary>
        public int MaxRequestHeaderCount { get; set; } = 100;

        /// <summary>
        /// Gets or sets the maximum size of the request headers total.
        /// </summary>
        public int MaxRequestHeadersTotalSize { get; set; } = 32768;

        /// <summary>
        /// Gets or sets the maximum size of the request line.
        /// </summary>
        public int MaxRequestLineSize { get; set; } = 8192;

        /// <summary>
        /// Gets or sets the maximum size of the response buffer.
        /// </summary>
        public long? MaxResponseBufferSize { get; set; }

        /// <summary>
        /// Gets or sets the access policy.
        /// </summary>
        public AccessPolicyOption AccessPolicy { get; set; }

        /// <summary>
        /// Gets or sets the access setting.
        /// </summary>
        public List<AccessSettingOption> AccessSetting { get; set; }

        /// <summary>
        /// Gets or sets the HTTP ports.
        /// </summary>
        public string HttpPorts { get;  set; }
    }
}
