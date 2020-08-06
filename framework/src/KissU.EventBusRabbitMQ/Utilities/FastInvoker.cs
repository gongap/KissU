using System;
using System.Linq.Expressions;
using System.Reflection;

namespace KissU.EventBusRabbitMQ.Utilities
{
    /// <summary>
    /// FastInvoker.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FastInvoker<T>
    {
        [ThreadStatic] private static FastInvoker<T> _current;

        /// <summary>
        /// Gets the current.
        /// </summary>
        public static FastInvoker<T> Current
        {
            get
            {
                if (_current == null)
                    _current = new FastInvoker<T>();
                return _current;
            }
        }

        /// <summary>
        /// Fasts the invoke.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="expression">The expression.</param>
        /// <exception cref="ArgumentException">只支持方法调用表达式。 - expression</exception>
        public void FastInvoke(T target, Expression<Action<T>> expression)
        {
            var call = expression.Body as MethodCallExpression;
            if (call == null)
                throw new ArgumentException("只支持方法调用表达式。 ", "expression");
            var invoker = GetInvoker(() => call.Method);
            invoker(target);
        }

        /// <summary>
        /// Fasts the invoke.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="genericTypes">The generic types.</param>
        /// <param name="expression">The expression.</param>
        /// <exception cref="ArgumentException">只支持方法调用表达式 - expression</exception>
        public void FastInvoke(T target, Type[] genericTypes, Expression<Action<T>> expression)
        {
            var call = expression.Body as MethodCallExpression;
            if (call == null)
                throw new ArgumentException("只支持方法调用表达式", "expression");

            var method = call.Method;
            var invoker = GetInvoker(() =>
            {
                if (method.IsGenericMethod)
                    return GetGenericMethodFromTypes(method.GetGenericMethodDefinition(), genericTypes);
                return method;
            });
            invoker(target);
        }

        private MethodInfo GetGenericMethodFromTypes(MethodInfo method, Type[] genericTypes)
        {
            if (!method.IsGenericMethod)
                throw new ArgumentException("不能为非泛型方法指定泛型类型。: " + method.Name);
            var genericArguments = method.GetGenericArguments();
            if (genericArguments.Length != genericTypes.Length)
            {
                throw new ArgumentException("传递的泛型参数的数目错误" + genericTypes.Length
                                                           + " (needed " + genericArguments.Length + ")");
            }

            method = method.GetGenericMethodDefinition().MakeGenericMethod(genericTypes);
            return method;
        }

        private Action<T> GetInvoker(Func<MethodInfo> getMethodInfo)
        {
            var method = getMethodInfo();

            var instanceParameter = Expression.Parameter(typeof(T), "target");

            var call = Expression.Call(instanceParameter, method);

            return Expression.Lambda<Action<T>>(call, instanceParameter).Compile();
        }
    }
}