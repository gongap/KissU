using System.Collections.Generic;

namespace KissU.IModuleServices.Admin.Dtos.NgAlain
{
    /// <summary>
    /// NgAlain应用程序数据
    /// </summary>
    public class AppData
    {
        /// <summary>
        /// 初始化NgAlain应用程序数据
        /// </summary>
        public AppData()
        {
            App = new AppInfo();
            User = new UserInfo();
            Menu = new List<MenuInfo>();
        }

        /// <summary>
        /// 应用程序信息
        /// </summary>
        public AppInfo App { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserInfo User { get; set; }
        /// <summary>
        /// 菜单信息
        /// </summary>
        public List<MenuInfo> Menu { get; set; }
    }
}