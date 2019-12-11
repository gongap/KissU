using System.Threading.Tasks;
using KissU.Util.Dependency;

namespace KissU.Util.Ui.Core.Pages {
    /// <summary>
    /// Html生成器
    /// </summary>
    public interface IHtmlGenerator : IScopeDependency {
        /// <summary>
        /// 构建并生成Html
        /// </summary>
        Task BuildAsync();
    }
}
