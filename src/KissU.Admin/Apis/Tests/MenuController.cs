using System.Collections.Generic;
using GreatWall.Service.Dtos.NgAlain;
using Microsoft.AspNetCore.Mvc;
using Util.Webs.Controllers;

namespace GreatWall.Apis.Tests {
    /// <summary>
    /// 测试菜单控制器
    /// </summary>
    public class MenuController : WebApiControllerBase {
        /// <summary>
        /// 获取应用程序数据
        /// </summary>
        [HttpGet]
        public IActionResult GetAppData() {
            var data = new AppData {
                App = { Name = "GreatWall", Description = ".Net Core权限系统" },
                User = { Name = "何镇汐", Avatar = "/assets/img/avatar.jpg", Email = "xiadao521@qq.com" },
                Menu = new List<MenuInfo> {
                    GetMainMenu(),
                    GetDemoMenu()
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
                Children = {
                    new MenuInfo {
                        Text = "仪表盘",
                        Icon = "anticon anticon-dashboard",
                        Children = {
                            new MenuInfo {
                                Text = "默认页",
                                Link = "/dashboard/v1",
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// 获取系统菜单
        /// </summary>
        private MenuInfo GetDemoMenu() {
            return new MenuInfo {
                Text = "系统菜单",
                Children = {
                    new MenuInfo {
                        Text = "应用程序",
                        Icon = "anticon anticon-database",
                        Link = "/systems/application"
                    },
                    new MenuInfo {
                        Text = "用户",
                        Icon = "anticon anticon-user",
                        Link = "/systems/user"
                    },
                    new MenuInfo {
                        Text = "角色",
                        Icon = "anticon anticon-team",
                        Link = "/systems/role",
                    },
                    new MenuInfo {
                        Text = "模块",
                        Icon = "anticon anticon-menu-fold",
                        Link = "/systems/module"
                    }
                }
            };
        }
    }
}