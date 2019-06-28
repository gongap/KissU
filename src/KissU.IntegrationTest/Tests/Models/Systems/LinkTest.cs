using Xunit;
using KissU.Domain.Systems.Models;

namespace KissU.IntegrationTest.Tests.Models.Systems 
{
    /// <summary>
    /// 链接测试
    /// </summary>
    public partial class LinkTest 
	{
        /// <summary>
        /// 链接
        /// </summary>
        private Link _link;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public LinkTest() 
		{
            _link = Create();
        }
    }
}