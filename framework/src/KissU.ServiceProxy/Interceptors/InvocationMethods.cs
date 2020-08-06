using System;
using System.Collections.Generic;
using System.Reflection;
using KissU.ServiceProxy.Interceptors.Implementation;

namespace KissU.ServiceProxy.Interceptors
{
    /// <summary>
    /// InvocationMethods.
    /// </summary>
    public class InvocationMethods
    {
        /// <summary>
        /// The composition invocation constructor
        /// </summary>
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