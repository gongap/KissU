using System.Collections.Generic;

namespace KissU.Util.Logs.Exceptionless
{
    /// <summary>
    /// 日志转换器
    /// </summary>
    public interface ILogConvert
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <returns>List&lt;Item&gt;.</returns>
        List<Item> To();
    }
}