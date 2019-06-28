using Xunit;
using KissU.Domain.Systems.Models;

namespace KissU.IntegrationTest.Tests.Models.Systems 
{
    /// <summary>
    /// 企业测试
    /// </summary>
    public partial class EnterpriseTest 
	{
        /// <summary>
        /// 企业
        /// </summary>
        private Enterprise _enterprise;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public EnterpriseTest() 
		{
            _enterprise = Create();
        }
    }
}