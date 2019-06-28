using Xunit;
using KissU.Domain.Systems.Models;

namespace KissU.IntegrationTest.Tests.Models.Systems 
{
    /// <summary>
    /// 用户测试
    /// </summary>
    public partial class UserTest 
	{
        /// <summary>
        /// 用户
        /// </summary>
        private User _user;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public UserTest() 
		{
            _user = Create();
        }
    }
}