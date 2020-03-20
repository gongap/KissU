using KissU.Core.Contexts;
using KissU.Util.AspNetCore.Helpers;

namespace KissU.Util.AspNetCore.Contexts
{
    /// <summary>
    /// 上下文工厂
    /// </summary>
    public static class ContextFactory
    {
        /// <summary>
        /// 创建上下文
        /// </summary>
        /// <returns>IContext.</returns>
        public static IContext Create()
        {
            if (Web.HttpContext == null)
                return NullContext.Instance;
            return new WebContext();
        }
    }
}