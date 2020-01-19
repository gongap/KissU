using KissU.Util.AspNetCore.Helpers;
using KissU.Util.Contexts;

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
        public static IContext Create()
        {
            if (Web.HttpContext == null)
                return NullContext.Instance;
            return new WebContext();
        }
    }
}
