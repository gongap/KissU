using System;
using System.Collections.Generic;
using Util;
using GreatWall.Systems.Domain.Models;

namespace GreatWall.Test.Models.Systems {
    /// <summary>
    /// 应用程序测试数据
    /// </summary>
    public partial class ApplicationTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 应用程序标识
        /// </summary>
        public static readonly Guid Id = "2927b72d-2567-4a0c-8b15-81f32beb8be9".ToGuid();
        /// <summary>
        /// 应用程序编码
        /// </summary>
        public static readonly string Code = "Code";
        /// <summary>
        /// 应用程序名称
        /// </summary>
        public static readonly string Name = "Name";
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled = true;
        /// <summary>
        /// 启用注册
        /// </summary>
        public static readonly bool RegisterEnabled = true;
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Remark = "Remark";
        /// <summary>
        /// 扩展
        /// </summary>
        public static readonly string Extend = "Extend";
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime? CreationTime = "2019/7/4 22:34:20".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId = "b9748f9c-506a-49a1-8bf6-f21431c39882".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/7/4 22:34:20".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId = "b0b0d900-7ac5-4f1b-9578-3fe6cb6b92a4".ToGuid();
        /// <summary>
        /// 是否删除
        /// </summary>
        public static readonly bool IsDeleted = false;
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version = Util.Helpers.Convert.ToBytes( "1" );
        
        #endregion
        
        #region 测试数据2
        
        /// <summary>
        /// 应用程序标识
        /// </summary>
        public static readonly Guid Id2 = "bc976aae-a090-41ee-8db4-4180745591b3".ToGuid();
        /// <summary>
        /// 应用程序编码
        /// </summary>
        public static readonly string Code2 = "Code2";
        /// <summary>
        /// 应用程序名称
        /// </summary>
        public static readonly string Name2 = "Name2";
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled2 = true;
        /// <summary>
        /// 启用注册
        /// </summary>
        public static readonly bool RegisterEnabled2 = true;
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Remark2 = "Remark2";
        /// <summary>
        /// 扩展
        /// </summary>
        public static readonly string Extend2 = "Extend2";
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime? CreationTime2 = "2019/7/5 22:34:20".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId2 = "072fcb3e-c7c9-4d5d-97f7-f2506a5d1bf5".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/7/5 22:34:20".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId2 = "c5840bd8-9960-4a89-9248-6847bb4a3193".ToGuid();
        /// <summary>
        /// 是否删除
        /// </summary>
        public static readonly bool IsDeleted = false;
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version2 = Util.Helpers.Convert.ToBytes( "2" );
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建应用程序实体
        /// </summary>
        public static Application Create(string id = "") {
            return new Application( id.ToGuid() ) {
                Code = Code,
                Name = Name,
                Enabled = Enabled,
                RegisterEnabled = RegisterEnabled,
                Remark = Remark,
                Extend = Extend,
                CreationTime = CreationTime,
                CreatorId = CreatorId,
                LastModificationTime = LastModificationTime,
                LastModifierId = LastModifierId,
                IsDeleted = IsDeleted,
                Version = Version,
            };
        }
        
        /// <summary>
        /// 创建应用程序实体2
        /// </summary>
        /// <param name="id">应用程序编号</param>
        public static Application Create2( string id = "" ) {
            return new Application( id.ToGuid() ) {
                Code = Code2,
                Name = Name2,
                Enabled = Enabled2,
                RegisterEnabled = RegisterEnabled2,
                Remark = Remark2,
                Extend = Extend2,
                CreationTime = CreationTime2,
                CreatorId = CreatorId2,
                LastModificationTime = LastModificationTime2,
                LastModifierId = LastModifierId2,
                IsDeleted = IsDeleted2,
                Version = Version2,
            };
        }
        
        #endregion
        
        #region CreateList(创建列表)

        /// <summary>
        /// 创建列表
        /// </summary>
        public static List<Application> CreateList() {
            return new List<Application>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}