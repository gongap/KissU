using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using KissU.Engines;
using KissU.Engines.Implementation;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.CPlatform.Engines.Implementation
{
    /// <summary>
    /// 默认服务引擎生成器.
    /// Implements the <see cref="IServiceEngineBuilder" />
    /// </summary>
    /// <seealso cref="IServiceEngineBuilder" />
    public class DefaultServiceEngineBuilder : IServiceEngineBuilder
    {
        private readonly Dictionary<string, DateTime> _dic = new Dictionary<string, DateTime>();
        private readonly ILogger<DefaultServiceEngineBuilder> _logger;
        private readonly VirtualPathProviderServiceEngine _serviceEngine;
        private DateTime _lastBuildTime = DateTime.Now;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceEngineBuilder" /> class.
        /// </summary>
        /// <param name="serviceEngine">The service engine.</param>
        /// <param name="logger">The logger.</param>
        public DefaultServiceEngineBuilder(IServiceEngine serviceEngine, ILogger<DefaultServiceEngineBuilder> logger)
        {
            _serviceEngine = serviceEngine as VirtualPathProviderServiceEngine;
            _logger = logger;
        }

        /// <summary>
        /// 构建.
        /// </summary>
        /// <param name="serviceContainer">The service container.</param>
        public void Build(ContainerBuilder serviceContainer)
        {
            var serviceBuilder = new ServiceBuilder(serviceContainer);
            var virtualPaths = new List<string>();
            if (_serviceEngine != null)
            {
                if (_serviceEngine.ModuleServiceLocationFormats != null)
                {
                    var paths = GetPaths(_serviceEngine.ModuleServiceLocationFormats);
                    if (paths == null)
                    {
                        return;
                    }

                    if (_logger.IsEnabled(LogLevel.Debug))
                    {
                        _logger.LogDebug($"准备加载路径${string.Join(',', paths)}下的业务模块。");
                    }

                    serviceBuilder.RegisterServices(paths);
                    serviceBuilder.RegisterServiceBus(paths);
                    serviceBuilder.RegisterInstanceByConstraint(paths);
                }

                if (_serviceEngine.ComponentServiceLocationFormats != null)
                {
                    var paths = GetPaths(_serviceEngine.ComponentServiceLocationFormats);
                    if (paths == null)
                    {
                        return;
                    }

                    if (_logger.IsEnabled(LogLevel.Debug))
                    {
                        _logger.LogDebug($"准备加载路径${string.Join(',', paths)}下的组件模块。");
                    }

                    serviceBuilder.RegisterModules(paths);
                }

                _lastBuildTime = DateTime.Now;
            }
        }

        /// <summary>
        /// 重新构建.
        /// </summary>
        /// <param name="serviceContainer">The service container.</param>
        /// <returns>System.Nullable&lt;ValueTuple&lt;List&lt;Type&gt;, IEnumerable&lt;System.String&gt;&gt;&gt;.</returns>
        public ValueTuple<List<Type>, IEnumerable<string>>? ReBuild(ContainerBuilder serviceContainer)
        {
            ValueTuple<List<Type>, IEnumerable<string>>? result = null;
            var serviceBuilder = new ServiceBuilder(serviceContainer);
            var virtualPaths = new List<string>();
            var rootPath = string.IsNullOrEmpty(AppConfig.ServerOptions.RootPath)
                ? AppContext.BaseDirectory
                : AppConfig.ServerOptions.RootPath;
            if (_serviceEngine != null)
            {
                if (_serviceEngine.ModuleServiceLocationFormats != null)
                {
                    var paths = GetPaths(_serviceEngine.ModuleServiceLocationFormats);
                    paths = paths?.Where(p =>
                            (Directory.GetLastWriteTime(Path.Combine(rootPath, p)) - _lastBuildTime).TotalSeconds > 0)
                        .ToArray();
                    if (paths == null || paths.Length == 0)
                    {
                        return null;
                    }

                    if (_logger.IsEnabled(LogLevel.Debug))
                    {
                        _logger.LogDebug($"准备加载路径${string.Join(',', paths)}下的业务模块。");
                    }

                    serviceBuilder.RegisterServices(paths);
                    serviceBuilder.RegisterServiceBus(paths);
                    result = new ValueTuple<List<Type>, IEnumerable<string>>(serviceBuilder.GetInterfaceService(paths),
                        serviceBuilder.GetDataContractName(paths));
                }

                if (_serviceEngine.ComponentServiceLocationFormats != null)
                {
                    var paths = GetPaths(_serviceEngine.ComponentServiceLocationFormats);
                    paths = paths?.Where(p => (Directory.GetLastWriteTime(p) - _lastBuildTime).TotalSeconds > 0)
                        .ToArray();
                    if (paths != null && paths.Length > 0)
                    {
                        if (_logger.IsEnabled(LogLevel.Debug))
                        {
                            _logger.LogDebug($"准备加载路径${string.Join(',', paths)}下的组件模块。");
                        }

                        serviceBuilder.RegisterModules(paths);
                    }
                }

                _lastBuildTime = DateTime.Now;
            }

            return result;
        }

        private string[] GetPaths(params string[] virtualPaths)
        {
            var directories = new List<string>(virtualPaths.Where(p => !string.IsNullOrEmpty(p)));
            var rootPath = string.IsNullOrEmpty(AppConfig.ServerOptions.RootPath)
                ? AppContext.BaseDirectory
                : AppConfig.ServerOptions.RootPath;
            var virPaths = virtualPaths;
            foreach (var virtualPath in virtualPaths)
            {
                var path = Path.Combine(rootPath, virtualPath);
                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    _logger.LogDebug($"准备查找路径{path}下的目录。");
                }

                if (Directory.Exists(path))
                {
                    var dirs = Directory.GetDirectories(path);
                    directories.AddRange(dirs.Select(dir => Path.Combine(virtualPath, new DirectoryInfo(dir).Name)));
                }
                else
                {
                    if (_logger.IsEnabled(LogLevel.Debug))
                    {
                        _logger.LogDebug($"未找到路径：{path}。");
                    }

                    directories.Remove(virtualPath);
                    virPaths = null;
                }
            }

            return directories.Any() ? directories.Distinct().ToArray() : virPaths;
        }
    }
}