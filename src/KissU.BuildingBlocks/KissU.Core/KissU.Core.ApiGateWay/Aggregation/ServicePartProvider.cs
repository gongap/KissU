using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core.ProxyGenerator;
using Newtonsoft.Json.Linq;

namespace KissU.Core.ApiGateWay.Aggregation
{
    /// <summary>
    /// 服务部件提供者
    /// </summary>
    public class ServicePartProvider : IServicePartProvider
    {
        private readonly ConcurrentDictionary<string, ServicePartType> _servicePartTypes =
            new ConcurrentDictionary<string, ServicePartType>();

        private readonly IServiceProxyProvider _serviceProxyProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicePartProvider" /> class.
        /// </summary>
        /// <param name="serviceProxyProvider">The service proxy provider.</param>
        public ServicePartProvider(IServiceProxyProvider serviceProxyProvider)
        {
            _serviceProxyProvider = serviceProxyProvider;
        }

        /// <summary>
        /// Determines whether the specified routh path is part.
        /// </summary>
        /// <param name="routhPath">The routh path.</param>
        /// <returns><c>true</c> if the specified routh path is part; otherwise, <c>false</c>.</returns>
        public bool IsPart(string routhPath)
        {
            var servicePart = AppConfig.ServicePart;
            var parts = servicePart.Services;
            if (!_servicePartTypes.TryGetValue(routhPath, out var partType))
            {
                if (servicePart.MainPath.Equals(routhPath, StringComparison.OrdinalIgnoreCase))
                {
                    partType = _servicePartTypes.GetOrAdd(routhPath, ServicePartType.Main);
                }
                else if (parts.Any(p => p.UrlMapping.Equals(routhPath, StringComparison.OrdinalIgnoreCase)))
                {
                    partType = _servicePartTypes.GetOrAdd(routhPath, ServicePartType.Section);
                }
            }

            return partType != ServicePartType.None;
        }

        /// <summary>
        /// Merges the specified routh path.
        /// </summary>
        /// <param name="routhPath">The routh path.</param>
        /// <param name="param">The parameter.</param>
        /// <returns>Task&lt;System.Object&gt;.</returns>
        public async Task<object> Merge(string routhPath, Dictionary<string, object> param)
        {
            var partType = _servicePartTypes.GetValueOrDefault(routhPath);
            var jObject = new JObject();
            if (partType == ServicePartType.Main)
            {
                param.TryGetValue("ServiceAggregation", out var model);
                var parts = model as JArray;
                foreach (var part in parts)
                {
                    var routeParam = part["Params"].ToObject<Dictionary<string, object>>();
                    var path = part.Value<string>("RoutePath");
                    var serviceKey = part.Value<string>("ServiceKey");
                    var result = await _serviceProxyProvider.Invoke<object>(routeParam, path, serviceKey);
                    jObject.Add(part.Value<string>("Key"), JToken.FromObject(result));
                }
            }
            else
            {
                var service = AppConfig.ServicePart.Services
                    .Where(p => p.UrlMapping.Equals(routhPath, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                foreach (var part in service.serviceAggregation)
                {
                    var result = await _serviceProxyProvider.Invoke<object>(param, part.RoutePath, part.ServiceKey);
                    jObject.Add(part.Key, JToken.FromObject(result));
                }

                ;
            }

            return jObject;
        }
    }
}