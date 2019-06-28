using System;
using System.Collections.Generic;
using Util;
using KissU.Domain.Systems.Models;

namespace KissU.IntegrationTest.Tests.Models.Systems 
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
        public static readonly Guid Id = "bbb61071-2c03-41a8-bba7-cd823fc167ca".ToGuid();
        /// <summary>
        /// Api资源标识
        /// </summary>
        public static readonly Guid ApiId = "a687726a-d183-4c2d-926c-e367d9f4cf97".ToGuid();
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
        public static readonly DateTime? CreationTime = "2019/6/28 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId = "e58d438e-2185-47cf-a1e3-2cd8bc42bbad".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/6/28 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId = "d6e48ba0-db01-4c01-ac74-88860bde53ba".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Byte[] Version = Util.Helpers.Convert.ToBytes( "1" );
        
        #endregion
        
        #region 测试数据2
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Id2 = "49a2e853-cac7-404c-a5a6-f92e7b8f5cb0".ToGuid();
        /// <summary>
        /// Api资源标识
        /// </summary>
        public static readonly Guid ApiId2 = "27a5ab81-e759-44af-9e4d-52391a2dadf8".ToGuid();
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
        public static readonly DateTime? CreationTime2 = "2019/6/29 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId2 = "0987bdb1-efb3-49b9-aad5-b3e9e12f8d14".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/6/29 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId2 = "d5f3e8d2-430f-48cd-83e3-72e8e3b2b4cc".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Byte[] Version2 = Util.Helpers.Convert.ToBytes( "2" );
        
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
                Version = Version,
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
                Version = Version2,
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