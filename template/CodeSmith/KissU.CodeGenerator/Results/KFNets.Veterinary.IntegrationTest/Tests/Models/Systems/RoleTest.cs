using Xunit;
using KFNets.Veterinary.Domain.Systems.Models;

namespace KFNets.Veterinary.IntegrationTest.Tests.Models.Systems 
{
    /// <summary>
    /// 角色测试
    /// </summary>
    public partial class RoleTest 
	{
        /// <summary>
        /// 角色
        /// </summary>
        private Role _role;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public RoleTest() 
		{
            _role = Create();
        }
    }
}