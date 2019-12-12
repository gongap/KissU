using System;
using System.Collections.Generic;
using System.Reflection;
using KissU.Core.ProxyGenerator.Interceptors.Implementation;

namespace KissU.Core.ProxyGenerator.Interceptors
{
    public  class InvocationMethods
    {
        public static readonly ConstructorInfo CompositionInvocationConstructor =
        typeof(ActionInvocation).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null,
                                                     new[]
                                                     {
                                                             typeof(IDictionary<string, object>),
                                                             typeof(string),
                                                             typeof(string[]),
                                                             typeof(List<Attribute>),
                                                             typeof(Type),
                                                             typeof(object)
                                                     },
                                                     null);


    }
}
