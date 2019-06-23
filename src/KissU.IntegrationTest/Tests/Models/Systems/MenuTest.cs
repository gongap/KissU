using Xunit;
using KissU.Domain.Systems.Models;

namespace KissU.IntegrationTest.Tests.Models.Systems {
    /// <summary>
    /// 菜单测试
    /// </summary>
    public partial class MenuTest {
        /// <summary>
        /// 菜单
        /// </summary>
        private Menu _menu;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public MenuTest() {
            _menu = Create();
        }
    }
}