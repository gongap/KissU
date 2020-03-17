using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace KissU.Surging.ProxyGenerator.FastReflection
{
    /// <summary>
    /// Interface IConstructorInvoker
    /// </summary>
    public interface IConstructorInvoker
    {
        /// <summary>
        /// Invokes the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>System.Object.</returns>
        object Invoke(params object[] parameters);
    }

    /// <summary>
    /// ConstructorInvoker.
    /// Implements the <see cref="KissU.Surging.ProxyGenerator.FastReflection.IConstructorInvoker" />
    /// </summary>
    /// <seealso cref="KissU.Surging.ProxyGenerator.FastReflection.IConstructorInvoker" />
    public class ConstructorInvoker : IConstructorInvoker
    {
        private readonly Func<object[], object> m_invoker;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructorInvoker" /> class.
        /// </summary>
        /// <param name="constructorInfo">The constructor information.</param>
        public ConstructorInvoker(ConstructorInfo constructorInfo)
        {
            ConstructorInfo = constructorInfo;
            m_invoker = InitializeInvoker(constructorInfo);
        }

        /// <summary>
        /// Gets the constructor information.
        /// </summary>
        public ConstructorInfo ConstructorInfo { get; }

        #region IConstructorInvoker Members

        object IConstructorInvoker.Invoke(params object[] parameters)
        {
            return Invoke(parameters);
        }

        #endregion

        private Func<object[], object> InitializeInvoker(ConstructorInfo constructorInfo)
        {
            // Target: (object)new T((T0)parameters[0], (T1)parameters[1], ...)

            // parameters to execute
            var parametersParameter = Expression.Parameter(typeof(object[]), "parameters");

            // build parameter list
            var parameterExpressions = new List<Expression>();
            var paramInfos = constructorInfo.GetParameters();
            for (var i = 0; i < paramInfos.Length; i++)
            {
                // (Ti)parameters[i]
                var valueObj = Expression.ArrayIndex(parametersParameter, Expression.Constant(i));
                var valueCast = Expression.Convert(valueObj, paramInfos[i].ParameterType);

                parameterExpressions.Add(valueCast);
            }

            // new T((T0)parameters[0], (T1)parameters[1], ...)
            var instanceCreate = Expression.New(constructorInfo, parameterExpressions);

            // (object)new T((T0)parameters[0], (T1)parameters[1], ...)
            var instanceCreateCast = Expression.Convert(instanceCreate, typeof(object));

            var lambda = Expression.Lambda<Func<object[], object>>(instanceCreateCast, parametersParameter);

            return lambda.Compile();
        }

        /// <summary>
        /// Invokes the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>System.Object.</returns>
        public object Invoke(params object[] parameters)
        {
            return m_invoker(parameters);
        }
    }
}