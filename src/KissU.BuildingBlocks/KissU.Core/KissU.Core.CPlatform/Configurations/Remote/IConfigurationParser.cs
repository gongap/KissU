using System.Collections.Generic;
using System.IO;

namespace KissU.Core.CPlatform.Configurations.Remote
{
    /// <summary>
    /// 配置解析器
    /// </summary>
    public interface IConfigurationParser
    {
        /// <summary>
        /// 解析.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="initialContext">The initial context.</param>
        /// <returns>IDictionary&lt;System.String, System.String&gt;.</returns>
        IDictionary<string, string> Parse(Stream input, string initialContext);
    }
}