using System;
using System.Linq.Expressions;

namespace KissU.Core.EventBusRabbitMQ.Utilities
{
    public static class ExtensionsToFastActivator
    {
        public static void FastInvoke<T>(this T target, Type[] genericTypes, Expression<Action<T>> expression)
        {
            FastInvoker<T>.Current.FastInvoke(target, genericTypes,expression);
        }

    }
}
