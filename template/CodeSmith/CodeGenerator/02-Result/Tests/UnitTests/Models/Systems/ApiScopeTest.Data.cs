using System;
using System.Collections.Generic;
using Util;
using KissU.GreatWall.Systems.Domain.Models;

namespace KissU.GreatWall.Test.Models.Systems {
    /// <summary>
    /// Api许可范围测试数据
    /// </summary>
    public partial class ApiScopeTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Id = "740bbac3-9f7b-4160-a790-09d9daf261c6".ToGuid();
        /// <summary>
        /// Api资源标识
        /// </summary>
        public static readonly Guid ApiId = "69ad73b2-8332-4f94-937a-e290da500a4d".ToGuid();
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
        /// 是否必选
        /// </summary>
        public static readonly bool Required = true;
        /// <summary>
        /// 是否强调
        /// </summary>
        public static readonly bool Emphasize = true;
        /// <summary>
        /// 是否显示在发现文档中
        /// </summary>
        public static readonly bool ShowInDiscoveryDocument = true;
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? CreationTime = "2019/7/4 14:34:19".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId = "47f32bc4-a142-4aa6-9e0f-ecdde8d3e560".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/7/4 14:34:19".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId = "a8bcd209-8bd5-46da-bf35-0bac1d3b75d2".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly bool IsDeleted = false;
        
        #endregion
        
        #region 测试数据2
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Id2 = "ed8ef52a-7477-4865-b1ad-3d9c608e5d0b".ToGuid();
        /// <summary>
        /// Api资源标识
        /// </summary>
        public static readonly Guid ApiId2 = "49635ecc-9d4b-49f2-8099-cd10d49e4634".ToGuid();
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
        /// 是否必选
        /// </summary>
        public static readonly bool Required2 = true;
        /// <summary>
        /// 是否强调
        /// </summary>
        public static readonly bool Emphasize2 = true;
        /// <summary>
        /// 是否显示在发现文档中
        /// </summary>
        public static readonly bool ShowInDiscoveryDocument2 = true;
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? CreationTime2 = "2019/7/5 14:34:19".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId2 = "a7555db6-0965-4c73-85f5-ba522ddce1a3".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/7/5 14:34:19".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId2 = "3ef29924-278a-4e58-b827-ad7df2c2759f".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly bool IsDeleted = false;
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建Api许可范围实体
        /// </summary>
        public static ApiScope Create(string id = "") {
            return new ApiScope( id.ToGuid() ) {
                ApiId = ApiId,
                Name = Name,
                DisplayName = DisplayName,
                Description = Description,
                ClaimTypes = ClaimTypes,
                Required = Required,
                Emphasize = Emphasize,
                ShowInDiscoveryDocument = ShowInDiscoveryDocument,
                CreationTime = CreationTime,
                CreatorId = CreatorId,
                LastModificationTime = LastModificationTime,
                LastModifierId = LastModifierId,
                IsDeleted = IsDeleted,
            };
        }
        
        /// <summary>
        /// 创建Api许可范围实体2
        /// </summary>
        /// <param name="id">Api许可范围编号</param>
        public static ApiScope Create2( string id = "" ) {
            return new ApiScope( id.ToGuid() ) {
                ApiId = ApiId2,
                Name = Name2,
                DisplayName = DisplayName2,
                Description = Description2,
                ClaimTypes = ClaimTypes2,
                Required = Required2,
                Emphasize = Emphasize2,
                ShowInDiscoveryDocument = ShowInDiscoveryDocument2,
                CreationTime = CreationTime2,
                CreatorId = CreatorId2,
                LastModificationTime = LastModificationTime2,
                LastModifierId = LastModifierId2,
                IsDeleted = IsDeleted2,
            };
        }
        
        #endregion
        
        #region CreateList(创建列表)

        /// <summary>
        /// 创建列表
        /// </summary>
        public static List<ApiScope> CreateList() {
            return new List<ApiScope>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}