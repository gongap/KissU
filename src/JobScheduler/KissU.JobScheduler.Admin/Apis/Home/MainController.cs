using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using KissU.JobScheduler.Admin.Models.Home;
using Util.Webs.Controllers;

namespace KissU.JobScheduler.Admin.Apis.Home {
    /// <summary>
    /// 主控制器
    /// </summary>
    public class MainController : WebApiControllerBase {
        /// <summary>
        /// 获取应用程序数据
        /// </summary>
        [HttpGet]
        public IActionResult GetAppData() {
            var data = new AppData {
                App = { Name = "KissU", Description = ".Net Core应用框架" },
                User = { Name = "龚安平", Avatar = "/assets/img/avatar.jpg", Email = "gonganping@qq.com" },
                Menu = new List<MenuInfo> {
                    GetMainMenu(),
                    GetSystemMenu()
                }
            };
            return Success( data );
        }

        /// <summary>
        /// 获取主导航菜单
        /// </summary>
        private MenuInfo GetMainMenu() {
            return new MenuInfo {
                Text = "主菜单",
                Group = true,
                HideInBreadcrumb = true,
                Children = {
                    new MenuInfo {
                        Text = "仪表盘",
                        Icon = "anticon anticon-dashboard",
                        Children = {
                            new MenuInfo {
                                Text = "默认页",
                                Icon = "anticon anticon-dashboard",
                                Link = "/dashboard/index",
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// 获取系统管理菜单
        /// </summary>
        private MenuInfo GetSystemMenu()
        {
            return new MenuInfo
            {
                Text = "系统管理",
                Group = true,
                Children = {
                    new MenuInfo {
                        Text = "接口管理",
                        Icon = "anticon anticon-appstore",
                        Link = "/system/api"
                    },
                    new MenuInfo {
                        Text = "应用管理",
                        Icon = "anticon anticon-appstore",
                        Link = "/system/application"
                    },
                    new MenuInfo {
                        Text = "角色管理",
                        Icon = "anticon anticon-team",
                        Link = "/system/role"
                    }
                }
            };
        }
    }
}