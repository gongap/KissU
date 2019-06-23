using Util.Helpers;

namespace KissU.IntegrationTest.Commons.Datas.SqlServer.Configs {
    /// <summary>
    /// 全局测试配置
    /// </summary>
    public class GlobalFixture {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public GlobalFixture() {
            Ioc.Register( new IocConfig() );
        }
    }
}
