using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace KissU.Core.ProxyGenerator.FastReflection
{
    /// <summary>
    /// Interface IMethodInvoker
    /// </summary>
    public interface IMethodInvoker
    {
        /// <summary>
        /// Invokes the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>System.Object.</returns>
        object Invoke(object instance, params object[] parameters);
    }

    /// <summary>
    /// MethodInvoker.
    /// Implements the <see cref="KissU.Core.ProxyGenerator.FastReflection.IMethodInvoker" />
    /// </summary>
    /// <seealso cref="KissU.Core.ProxyGenerator.FastReflection.IMethodInvoker" />
    public class MethodInvoker : IMethodInvoker
    {
        private Func<object, object[], object> m_invoker;

        /// <summary>
        /// Gets the method information.
        /// </summary>
        public MethodInfo MethodInfo { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodInvoker"/> class.
        /// </summary>
        /// <param name="methodInfo">The method information.</param>
        public MethodInvoker(MethodInfo methodInfo)
        {
            this.MethodInfo = methodInfo;
            this.m_invoker = CreateInvokeDelegate(methodInfo);
        }

        /// <summary>
        /// Invokes the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>System.Object.</returns>
        public object Invoke(object instance, params object[] parameters)
        {
            return this.m_invoker(instance, parameters);
        }

        private static Func<object, object[], object> CreateInvokeDelegate(MethodInfo methodInfo)
        {
            // Target: ((TInstance)instance).Method((T0)parameters[0], (T1)parameters[1], ...)

            // parameters to execute
            var instanceParameter = Expression.Parameter(typeof(object), "instance");
            var parametersParameter = Expression.Parameter(typeof(object[]), "parameters");

            // build parameter list
            var parameterExpressions = new List<Expression>();
            var paramInfos = methodInfo.GetParameters();
            for (int i = 0; i < paramInfos.Length; i++)
            {
                // (Ti)parameters[i]
                BinaryExpression valueObj = Expression.ArrayIndex(
                    parametersParameter, Expression.Constant(i));
                UnaryExpression valueCast = Expression.Convert(
                    valueObj, paramInfos[i].ParameterType);

                parameterExpressions.Add(valueCast);
            }

            // non-instance for static method, or ((TInstance)instance)
            var instanceCast = methodInfo.IsStatic ? null :
                Expression.Convert(instanceParameter, methodInfo.ReflectedType);

            // static invoke or ((TInstance)instance).Method
            var methodCall = Expression.Call(instanceCast, methodInfo, parameterExpressions);

            // ((TInstance)instance).Method((T0)parameters[0], (T1)parameters[1], ...)
            if (methodCall.Type == typeof(void))
            {
                var lambda = Expression.Lambda<Action<object, object[]>>(
                        methodCall, instanceParameter, parametersParameter);

                Action<object, object[]> execute = lambda.Compile();
                return (instance, parameters) =>
                {
                    execute(instance, parameters);
                    return null;
                };
            }
            else
            {
                var castMethodCall = Expression.Convert(methodCall, typeof(object));
                var lambda = Expression.Lambda<Func<object, object[], object>>(
                    castMethodCall, instanceParameter, parametersParameter);

                return lambda.Compile();
            }
        }

        #region IMethodInvoker Members

        object IMethodInvoker.Invoke(object instance, params object[] parameters)
        {
            return this.Invoke(instance, parameters);
        }

        #endregion
    }
}

