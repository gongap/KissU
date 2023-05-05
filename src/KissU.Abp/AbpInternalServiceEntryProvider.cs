using Autofac;
using Volo.Abp;
using Volo.Abp.Reflection;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery;
using KissU.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KissU.Abp
{
    /// <summary>
    /// InternalService标记类型的服务条目提供程序。
    /// </summary>
    public class AbpInternalServiceEntryProvider : IServiceEntryProvider
    {
        private readonly IClrServiceEntryFactory _clrServiceEntryFactory;
        private readonly CPlatformContainer _serviceProvider;
        private readonly IEnumerable<Type> _types;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbpInternalServiceEntryProvider" /> class.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <param name="clrServiceEntryFactory">The color service entry factory.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public AbpInternalServiceEntryProvider(IEnumerable<Type> types, IClrServiceEntryFactory clrServiceEntryFactory, CPlatformContainer serviceProvider)
        {
            _types = types.Distinct().ToArray();
            _clrServiceEntryFactory = clrServiceEntryFactory;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 获取服务条目集合。
        /// </summary>
        /// <returns>服务条目集合。</returns>
        public IEnumerable<ServiceEntry> GetEntries()
        {
            var services = GetTypes();
            var entries = new List<ServiceEntry>();
            foreach (var service in services)
            {
                entries.AddRange(_clrServiceEntryFactory.CreateServiceEntry(service,"api/internal/{InternalService}/{Async}", (_)=> true));
            }

            return entries;
        }

        /// <summary>
        /// 获取所有条目.
        /// </summary>
        /// <returns>IEnumerable&lt;ServiceEntry&gt;.</returns>
        public IEnumerable<ServiceEntry> GetAllEntries()
        {
            var services = GetAllTypes();
            var entries = new List<ServiceEntry>();
            foreach (var service in services)
            {
                entries.AddRange(_clrServiceEntryFactory.CreateServiceEntry(service,"api/internal/{InternalService}/{Async}", (_)=> true));
            }

            return entries;
        }

        /// <summary>
        /// 获取类型.
        /// </summary>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        public IEnumerable<Type> GetTypes()
        {
            var services = _types.Where(x=>IsRemoteService(x) && _serviceProvider.Current.IsRegistered(x));
            return services;
        }

        /// <summary>
        /// 获取类型.
        /// </summary>
        /// <returns>IEnumerable&lt;Type&gt;.</returns>
        public IEnumerable<Type> GetAllTypes()
        {
            var services = _types.Where(IsRemoteService);
            return services;
        }

        private static bool IsRemoteService(Type type)
        {
            if (!type.IsPublic || !type.IsInterface || type.IsGenericType)
            {
                return false;
            }

            var remoteServiceAttr = ReflectionHelper.GetSingleAttributeOrDefault<RemoteServiceAttribute>(type);
            if (remoteServiceAttr == null || !remoteServiceAttr.IsEnabledFor(type))
            {
                return false;
            }

            //if (type.IsInterface &&  typeof(IInternalService) != type &&  typeof(IInternalService).IsAssignableFrom(type))
            //{
            //    return true;
            //}

            return false;
        }
    }
}
