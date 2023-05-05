using System;
using KissU.Modularity;
using KissU.CPlatform.Filters;

namespace KissU.CPlatform
{
    /// <summary>
    /// 注册扩展
    /// </summary>
    public static class RegistrationExtensions
    {
        /// <summary>
        /// 添加过滤器.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="filter">The filter.</param>
        public static void AddFilter(this ContainerBuilderWrapper builder, Type filter)
        {
            if (typeof(IExceptionFilter).IsAssignableFrom(filter))
            {
                builder.RegisterType(filter).As<IExceptionFilter>().SingleInstance();
            }
            else if (typeof(IAuthorizationFilter).IsAssignableFrom(filter))
            {
                builder.RegisterType(filter).As<IAuthorizationFilter>().SingleInstance();
            }
        }
    }
}