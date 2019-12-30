namespace KissU.Modules.IdentityServer.Application.Services.Options
{
    /// <summary>
    /// 令牌清理的配置
    /// </summary>
    public class OperationalStoreOptions
    {
        /// <summary>
        /// 是否将从数据库自动清除陈旧的条目
        /// </summary>
        public bool EnableTokenCleanup { get; set; } = false;

        /// <summary>
        /// 令牌清理间隔（以秒为单位）。默认值是3600（1小时）
        /// </summary>
        public int TokenCleanupInterval { get; set; } = 3600;

        /// <summary>
        /// 一次删除的记录的数量。默认为100
        /// </summary>
        public int TokenCleanupBatchSize { get; set; } = 100;
    }
}