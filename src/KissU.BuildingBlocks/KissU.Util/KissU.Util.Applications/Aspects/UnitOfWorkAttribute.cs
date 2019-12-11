﻿using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using AspectCore.Extensions.AspectScope;
using KissU.Util.Aspects.Base;
using KissU.Util.Datas.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Util.Applications.Aspects {
    /// <summary>
    /// 工作单元拦截器
    /// </summary>
    public class UnitOfWorkAttribute : InterceptorBase,IScopeInterceptor {
        /// <summary>
        /// 作用域，当嵌套使用工作单元拦截器时，设置为Scope.Aspect，只有最外层工作单元拦截器生效
        /// </summary>
        public Scope Scope { get; set; } = Scope.Aspect;

        /// <summary>
        /// 执行
        /// </summary>
        public override async Task Invoke( AspectContext context, AspectDelegate next ) {
            await next( context );
            var manager = context.ServiceProvider.GetService<IUnitOfWorkManager>();
            if ( manager == null )
                return;
            await manager.CommitAsync();
            if( context.Implementation is ICommitAfter service )
                service.CommitAfter();
        }
    }
}
