using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using KissU.Util.Aspects.Base;

namespace KissU.Util.Aspects
{
    /// <summary>
    /// 验证不能为null
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class NotNullAttribute : ParameterInterceptorBase
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="next">The next.</param>
        /// <returns>Task.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.Value == null)
                throw new ArgumentNullException(context.Parameter.Name);
            return next(context);
        }
    }
}
