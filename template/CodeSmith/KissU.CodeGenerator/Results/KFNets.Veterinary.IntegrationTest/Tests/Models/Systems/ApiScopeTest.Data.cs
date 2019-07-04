using System;
using System.Collections.Generic;
using Util;
using KFNets.Veterinary.Domain.Systems.Models;

namespace KFNets.Veterinary.IntegrationTest.Tests.Models.Systems 
{
    /// <summary>
    /// Api许可范围测试数据
    /// </summary>
    public partial class ApiScopeTest 
	{
        
        #region 测试数据1
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Id = "737470d3-1dcc-4e31-b835-1048298142d7".ToGuid();
        /// <summary>
        /// Api资源标识
        /// </summary>
        public static readonly Guid ApiId = "1f639038-8cb7-4f2e-b915-6464275c2d2b".ToGuid();
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
        public static readonly DateTime? CreationTime = "2019/7/2 16:36:51".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId = "1bcb1c45-02d4-4d96-a04d-0f05b23e2d61".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/7/2 16:36:51".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId = "1a52188f-5880-4042-a64e-6057d45439ce".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly bool IsDeleted = false;
        
        #endregion
        
        #region 测试数据2
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Id2 = "73180091-1c4f-4d8a-a33b-4acf0b1e4450".ToGuid();
        /// <summary>
        /// Api资源标识
        /// </summary>
        public static readonly Guid ApiId2 = "48c06d31-68a2-4d51-a4b2-c6a113379954".ToGuid();
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
        public static readonly DateTime? CreationTime2 = "2019/7/3 16:36:51".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId2 = "f1993045-21ec-46a4-ab86-076fdd47a217".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/7/3 16:36:51".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId2 = "711b00fd-b0f3-4fda-a61d-b032168b0fcc".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly bool IsDeleted2 = false;
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建Api许可范围实体
        /// </summary>
        public static ApiScope Create(string id = "") 
		{
            return 
			new ApiScope( id.ToGuid() ) {
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
        public static ApiScope Create2( string id = "" ) 
		{
            return 
			new ApiScope( id.ToGuid() ) {
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
        public static List<ApiScope> CreateList() 
		{
            return new List<ApiScope>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}