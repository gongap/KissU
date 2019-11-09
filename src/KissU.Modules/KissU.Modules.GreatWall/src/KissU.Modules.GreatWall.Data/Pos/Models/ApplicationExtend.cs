using KissU.Modules.GreatWall.Domain.Models;

namespace KissU.Modules.GreatWall.Data.Pos.Models
{
    /// <summary>
    /// 应用程序扩展信息
    /// </summary>
    public class ApplicationExtend
    {
        /// <summary>
        /// 是否客户端
        /// </summary>
        public bool IsClient { get; set; }
        /// <summary>
        /// 客户端
        /// </summary>
        public Client Client { get; set; }
    }
}