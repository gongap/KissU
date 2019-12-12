using System;
using System.Collections.Generic;

namespace KissU.Core.ProxyGenerator.Interceptors
{
    public interface ICacheInvocation : IInvocation
    {
        string[] CacheKey { get; }

        List<Attribute> Attributes { get; }
    }
}
