using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.ProxyGenerator.Implementation;

namespace KissU.Core.ProxyGenerator.Interceptors.Implementation
{
    public class ActionInvocation : AbstractInvocation
    { 
        protected ActionInvocation(
             IDictionary<string, object> arguments,
           string serviceId,
            string[] cacheKey,
            List<Attribute> attributes,
            Type returnType,
            object proxy
            ) : base(arguments, serviceId, cacheKey, attributes, returnType, proxy)
        {
        }

        public override async Task Proceed()
        {
            try
            {
                if(_returnValue ==null)
                _returnValue = await (Proxy as ServiceProxyBase).CallInvoke(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}