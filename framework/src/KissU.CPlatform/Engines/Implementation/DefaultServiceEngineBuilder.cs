using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using KissU.Helpers;
using KissU.Modularity;

namespace KissU.CPlatform.Engines.Implementation
{
    /// <summary>
    /// 默认服务引擎生成器.
    /// </summary>
    public class DefaultServiceEngineBuilder 
    {
        private readonly IServiceBuilder _serviceBuilder;

        public DefaultServiceEngineBuilder(IServiceBuilder serviceBuilder)
        {
            _serviceBuilder = serviceBuilder;
        }

        /// <summary>
        /// Gets or sets the module service location formats.
        /// </summary>
        public static string ModuleServiceLocationFormat => EnvironmentHelper.GetEnvironmentVariable("${ModulePath}|Modules") ;

        /// <summary>
        /// Gets or sets the component service location formats.
        /// </summary>
        public static string ComponentServiceLocationFormat =>  EnvironmentHelper.GetEnvironmentVariable("${ComponentPath}|Components");

        /// <summary>
        /// 构建.
        /// </summary>
        /// <param name="serviceContainer">The service container.</param>
        public IServiceBuilder BuildServiceEngine()
        {
            if (_serviceBuilder != null)
            {
                if (!string.IsNullOrWhiteSpace(ModuleServiceLocationFormat))
                {
                    var paths = GetPaths(new[] { ModuleServiceLocationFormat});
                    if (paths != null)
                    {
                        _serviceBuilder.RegisterServices(paths);
                        _serviceBuilder.RegisterServiceBus(paths);
                        _serviceBuilder.RegisterInstanceByConstraint(paths);
                    }
                }


                if (!string.IsNullOrWhiteSpace(ComponentServiceLocationFormat))
                {
                    var paths = GetPaths(new[] { ComponentServiceLocationFormat });
                    if (paths != null)
                    {
                        _serviceBuilder.RegisterModules(paths);
                    }
                }
            }

            return _serviceBuilder;
        }

        public static string[] GetPaths(params string[] virtualPaths)
        {
            var directories = new List<string>(virtualPaths.Where(p => !string.IsNullOrEmpty(p)));
            var rootPath = string.IsNullOrEmpty(AppConfig.ServerOptions.RootPath)
                ? AppContext.BaseDirectory
                : AppConfig.ServerOptions.RootPath;
            var virPaths = virtualPaths;
            foreach (var virtualPath in virtualPaths)
            {
                var path = Path.Combine(rootPath, virtualPath);
                if (Directory.Exists(path))
                {
                    var dirs = Directory.GetDirectories(path);
                    directories.AddRange(dirs.Select(dir => Path.Combine(virtualPath, new DirectoryInfo(dir).Name)));
                }
                else
                {
                    directories.Remove(virtualPath);
                    virPaths = null;
                }
            }

            return directories.Any() ? directories.Distinct().ToArray() : virPaths;
        }
    }
}