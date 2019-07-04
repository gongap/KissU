using System;
using System.Collections.Generic;
using Util;
using KissU.GreatWall.Systems.Domain.Models;

namespace KissU.GreatWall.Test.Models.Systems {
    /// <summary>
    /// Api资源测试数据
    /// </summary>
    public partial class ApiTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Id = "b2dc5bbb-02ae-44b2-a89e-1da0d23bd91f".ToGuid();
        /// <summary>
        /// 名称
        /// </summary>
        public static readonly string Name = "Name";
        /// <summary>
        /// 显示名
        /// </summary>
        public static readonly string DisplayName = "DisplayName";
        /// <summary>
        /// 描述
        /// </summary>
        public static readonly string Description = "Description";
        /// <summary>
        /// 声明类型
        /// </summary>
        public static readonly string ClaimTypes = "ClaimTypes";
        /// <summary>
        /// 是否启用
        /// </summary>
        public static readonly bool Enabled = true;
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? CreationTime = "2019/7/4 14:34:19".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId = "eff68ee4-c06e-4d63-97b4-c13af9258d04".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/7/4 14:34:19".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId = "3e6896b6-477f-4dad-a49a-bd759b813d5b".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly bool IsDeleted = false;
        /// <summary>
        /// 
        /// </summary>
        public static readonly Byte[] Version = Util.Helpers.Convert.ToBytes( "1" );
        
        #endregion
        
        #region 测试数据2
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Id2 = "ec81a142-ced5-49d6-8fc4-a7ef25f6de96".ToGuid();
        /// <summary>
        /// 名称
        /// </summary>
        public static readonly string Name2 = "Name2";
        /// <summary>
        /// 显示名
        /// </summary>
        public static readonly string DisplayName2 = "DisplayName2";
        /// <summary>
        /// 描述
        /// </summary>
        public static readonly string Description2 = "Description2";
        /// <summary>
        /// 声明类型
        /// </summary>
        public static readonly string ClaimTypes2 = "ClaimTypes2";
        /// <summary>
        /// 是否启用
        /// </summary>
        public static readonly bool Enabled2 = true;
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? CreationTime2 = "2019/7/5 14:34:19".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId2 = "8a1269f6-d2cb-443a-ab1a-107868b464ca".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/7/5 14:34:19".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId2 = "370953e1-c5a0-4428-8a55-d11ac8289fe2".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly bool IsDeleted = false;
        /// <summary>
        /// 
        /// </summary>
        public static readonly Byte[] Version2 = Util.Helpers.Convert.ToBytes( "2" );
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建Api资源实体
        /// </summary>
        public static Api Create(string id = "") {
            return new Api( id.ToGuid() ) {
                Name = Name,
                DisplayName = DisplayName,
                Description = Description,
                ClaimTypes = ClaimTypes,
                Enabled = Enabled,
                CreationTime = CreationTime,
                CreatorId = CreatorId,
                LastModificationTime = LastModificationTime,
                LastModifierId = LastModifierId,
                IsDeleted = IsDeleted,
                Version = Version,
            };
        }
        
        /// <summary>
        /// 创建Api资源实体2
        /// </summary>
        /// <param name="id">Api资源编号</param>
        public static Api Create2( string id = "" ) {
            return new Api( id.ToGuid() ) {
                Name = Name2,
                DisplayName = DisplayName2,
                Description = Description2,
                ClaimTypes = ClaimTypes2,
                Enabled = Enabled2,
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
        public static List<Api> CreateList() {
            return new List<Api>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}