using Xunit;
using KissU.Domain.Systems.Models;

namespace KissU.Test.Models.Systems {
    /// <summary>
    /// 应用程序测试
    /// </summary>
    public partial class ApplicationTest {
        /// <summary>
        /// 应用程序
        /// </summary>
        private Application _application;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ApplicationTest() {
            _application = Create();
        }
    }
}