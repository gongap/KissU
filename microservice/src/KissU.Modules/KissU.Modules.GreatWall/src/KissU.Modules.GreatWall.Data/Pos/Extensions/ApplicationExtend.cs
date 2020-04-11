using KissU.Modules.GreatWall.Domain.Shared.Enums;

namespace KissU.Modules.GreatWall.Data.Pos.Extensions
{
    /// <summary>
    /// 应用程序扩展信息
    /// </summary>
    public class ApplicationExtend
    {
        /// <summary>
        /// 应用程序类型
        /// </summary>
        public ApplicationType ApplicationType { get; set; }

        /// <summary>
        /// 是否客户端
        /// </summary>
        public bool IsClient { get; set; }

        /// <summary>
        /// 客户端
        /// </summary>
        public string ClientId { get; set; }
    }
}