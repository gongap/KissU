using Xunit;
using KissU.GreatWall.Systems.Domain.Models;

namespace KissU.GreatWall.Test.Models.Systems {
    /// <summary>
    /// 用户测试
    /// </summary>
    public partial class UserTest {
        /// <summary>
        /// 用户
        /// </summary>
        private User _user;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public UserTest() {
            _user = Create();
        }
    }
}