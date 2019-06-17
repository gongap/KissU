using Xunit;
using KissU.Systems.Domain.Models;

namespace KissU.Test.Models.Systems {
    /// <summary>
    /// 测试
    /// </summary>
    public partial class MenuTest {
        /// <summary>
        /// 
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