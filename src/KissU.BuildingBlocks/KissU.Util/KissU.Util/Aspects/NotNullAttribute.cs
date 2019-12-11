using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using KissU.Util.Aspects.Base;

namespace KissU.Util.Aspects {
    /// <summary>
    /// 验证不能为null
    /// </summary>
    [AttributeUsage( AttributeTargets.Parameter )]
    public class NotNullAttribute : ParameterInterceptorBase {
        /// <summary>
        /// 执行
        /// </summary>
        public override Task Invoke( ParameterAspectContext context, ParameterAspectDelegate next ) {
            if( context.Parameter.Value == null )
                throw new ArgumentNullException( context.Parameter.Name );
            return next( context );
        }
    }
}
