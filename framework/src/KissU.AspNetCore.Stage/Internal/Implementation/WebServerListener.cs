﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Logging;

namespace KissU.AspNetCore.Stage.Internal.Implementation
{
    /// <summary>
    /// WebServerListener.
    /// Implements the <see cref="IWebServerListener" />
    /// </summary>
    /// <seealso cref="IWebServerListener" />
    public class WebServerListener : IWebServerListener
    {
        private readonly ILogger<WebServerListener> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebServerListener" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public WebServerListener(ILogger<WebServerListener> logger)
        {
            _logger = logger;
        }

        void IWebServerListener.Listen(WebHostContext context)
        {
            var httpsPorts = AppConfig.Options.HttpsPort?.Split(",") ?? new[] {"443"};
            var httpPorts = AppConfig.Options.HttpPorts?.Split(",");
            if (AppConfig.Options.EnableHttps)
            {
                foreach (var httpsPort in httpsPorts)
                {
                    int.TryParse(httpsPort, out var port);
                    if (string.IsNullOrEmpty(AppConfig.Options.HttpsPort)) port = 443;
                    if (port > 0)
                    {
                        context.KestrelOptions.Listen(context.Address, port, listOptions =>
                        {
                            X509Certificate2 certificate2 = null;
                            listOptions.Protocols = AppConfig.Options.Protocols;
                            var fileName = AppConfig.Options.CertificateFileName;
                            var password = AppConfig.Options.CertificatePassword;
                            if (fileName != null && password != null)
                            {
                                var pfxFile = Path.Combine(AppContext.BaseDirectory,
                                    AppConfig.Options.CertificateFileName);
                                if (File.Exists(pfxFile))
                                    certificate2 = new X509Certificate2(pfxFile, AppConfig.Options.CertificatePassword);
                                else
                                {
                                    var paths = GetPaths(AppConfig.Options.CertificateLocation);
                                    foreach (var path in paths)
                                    {
                                        pfxFile = Path.Combine(path, AppConfig.Options.CertificateFileName);
                                        if (File.Exists(pfxFile))
                                            certificate2 = new X509Certificate2(pfxFile,
                                                AppConfig.Options.CertificatePassword);
                                    }
                                }
                            }

                            listOptions = certificate2 == null
                                ? listOptions.UseHttps()
                                : listOptions.UseHttps(certificate2);
                        });
                    }
                }
            }
            
            if (httpPorts != null)
            {
                foreach (var httpPort in httpPorts)
                {
                    int.TryParse(httpPort, out var port);
                    if (port > 0)
                        context.KestrelOptions.Listen(context.Address, port);
                }
            }

            SetKestrelOptions(context);
        }

        private string[] GetPaths(params string[] virtualPaths)
        {
            var result = new List<string>();
            var rootPath = string.IsNullOrEmpty(CPlatform.AppConfig.ServerOptions.RootPath)
                ? AppContext.BaseDirectory
                : CPlatform.AppConfig.ServerOptions.RootPath;
            foreach (var virtualPath in virtualPaths)
            {
                var path = Path.Combine(rootPath, virtualPath);
                if (_logger.IsEnabled(LogLevel.Debug))
                    _logger.LogDebug($"准备查找路径{path}下的证书。");
                if (Directory.Exists(path))
                {
                    var dirs = Directory.GetDirectories(path);
                    result.AddRange(
                        dirs.Select(dir => Path.Combine(rootPath, virtualPath, new DirectoryInfo(dir).Name)));
                }
                else
                {
                    if (_logger.IsEnabled(LogLevel.Debug))
                        _logger.LogDebug($"未找到路径：{path}。");
                }
            }

            return result.ToArray();
        }

        private void SetKestrelOptions(WebHostContext context)
        {
            var requestBodyDataRate = AppConfig.Options.MinRequestBodyDataRate;
            var responseBodyDataRate = AppConfig.Options.MinResponseDataRate;
            context.KestrelOptions.Limits.MinRequestBodyDataRate = requestBodyDataRate == null
                ? null
                : new MinDataRate(requestBodyDataRate.BytesPerSecond, requestBodyDataRate.GracePeriod);
            context.KestrelOptions.Limits.MinResponseDataRate = responseBodyDataRate == null
                ? null
                : new MinDataRate(responseBodyDataRate.BytesPerSecond, responseBodyDataRate.GracePeriod);
            context.KestrelOptions.Limits.MaxConcurrentConnections = AppConfig.Options.MaxConcurrentConnections;
            context.KestrelOptions.Limits.MaxConcurrentUpgradedConnections =
                AppConfig.Options.MaxConcurrentUpgradedConnections;
            context.KestrelOptions.Limits.MaxRequestBodySize = AppConfig.Options.MaxRequestBodySize;
            context.KestrelOptions.Limits.MaxRequestBufferSize = AppConfig.Options.MaxRequestBufferSize;
            context.KestrelOptions.Limits.MaxRequestHeaderCount = AppConfig.Options.MaxRequestHeaderCount;
            context.KestrelOptions.Limits.MaxRequestHeadersTotalSize = AppConfig.Options.MaxRequestHeadersTotalSize;
            context.KestrelOptions.Limits.MaxRequestLineSize = AppConfig.Options.MaxRequestLineSize;
            context.KestrelOptions.Limits.MaxResponseBufferSize = AppConfig.Options.MaxResponseBufferSize;
        }
    }
}