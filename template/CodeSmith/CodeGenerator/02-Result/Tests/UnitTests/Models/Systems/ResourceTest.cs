using Xunit;
using GreatWall.Systems.Domain.Models;

namespace GreatWall.Test.Models.Systems {
    /// <summary>
    /// 资源测试
    /// </summary>
    public partial class ResourceTest {
        /// <summary>
        /// 资源
        /// </summary>
        private Resource _resource;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ResourceTest() {
            _resource = Create();
        }
    }
}