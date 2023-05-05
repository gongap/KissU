using System;

namespace KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ReactiveAttribute : Attribute
    {
    }
}
