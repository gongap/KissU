using System;
using System.Linq.Expressions;

namespace KissU.Core.EventBusRabbitMQ.Utilities
{
    /// <summary>
    /// ExtensionsToFastActivator.
    /// </summary>
    public static class ExtensionsToFastActivator
    {
        /// <summary>
        /// Fasts the invoke.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target.</param>
        /// <param name="genericTypes">The generic types.</param>
        /// <param name="expression">The expression.</param>
        public static void FastInvoke<T>(this T target, Type[] genericTypes, Expression<Action<T>> expression)
        {
            FastInvoker<T>.Current.FastInvoke(target, genericTypes, expression);
        }
    }
}