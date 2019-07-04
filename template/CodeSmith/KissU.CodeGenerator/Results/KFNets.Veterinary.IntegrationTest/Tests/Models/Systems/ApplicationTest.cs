using Xunit;
using KFNets.Veterinary.Domain.Systems.Models;

namespace KFNets.Veterinary.IntegrationTest.Tests.Models.Systems 
{
    /// <summary>
    /// 应用程序测试
    /// </summary>
    public partial class ApplicationTest 
	{
        /// <summary>
        /// 应用程序
        /// </summary>
        private Application _application;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ApplicationTest() 
		{
            _application = Create();
        }
    }
}