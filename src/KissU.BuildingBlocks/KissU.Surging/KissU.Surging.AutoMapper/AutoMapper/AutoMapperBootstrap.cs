using System.Linq;
using AutoMapper;
using AutoMapper.Attributes;
using KissU.Surging.CPlatform.Utilities;
using Microsoft.Extensions.Logging;

namespace KissU.Surging.AutoMapper.AutoMapper
{
    /// <summary>
    /// AutoMapperBootstrap.
    /// Implements the <see cref="KissU.Surging.AutoMapper.AutoMapper.IAutoMapperBootstrap" />
    /// </summary>
    /// <seealso cref="KissU.Surging.AutoMapper.AutoMapper.IAutoMapperBootstrap" />
    public class AutoMapperBootstrap : IAutoMapperBootstrap
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            //var logger = ServiceLocator.GetService<ILogger<AutoMapperBootstrap>>();
            //Mapper.Initialize(config =>
            //{
            //    if (AppConfig.Assemblies.Any())
            //    {
            //        foreach (var assembly in AppConfig.Assemblies)
            //        {
            //            assembly.MapTypes(config);
            //        }
            //    }

            //    var profiles = AppConfig.Profiles;
            //    if (profiles.Any())
            //    {
            //        foreach (var profile in profiles)
            //        {
            //            logger.LogDebug($"解析到{profile.GetType().FullName}映射关系");
            //            config.AddProfile(profile);
            //        }
            //    }
            //});
        }
    }
}