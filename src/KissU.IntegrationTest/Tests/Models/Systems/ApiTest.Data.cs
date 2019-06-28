using System;
using System.Collections.Generic;
using Util;
using KissU.Domain.Systems.Models;

namespace KissU.IntegrationTest.Tests.Models.Systems 
{
    /// <summary>
    /// Api资源测试数据
    /// </summary>
    public partial class ApiTest 
	{
        
        #region 测试数据1
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Id = "465d08c8-15f3-4430-9cd8-2ceeec5ee6ef".ToGuid();
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
        public static readonly DateTime? CreationTime = "2019/6/28 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId = "a8042b90-1bec-401f-8295-286bd42b1b93".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/6/28 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId = "1396a564-2527-456e-be62-7e63fd10ad2a".ToGuid();
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
        public static readonly Guid Id2 = "d249a17f-1231-4753-aea9-8aed8adbf67e".ToGuid();
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
        public static readonly DateTime? CreationTime2 = "2019/6/29 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId2 = "42e7faac-e3e7-4f50-9653-90f2850e299b".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/6/29 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId2 = "5b312f4c-9986-410a-b8a0-59065d1db1d4".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly bool IsDeleted2 = false;
        /// <summary>
        /// 
        /// </summary>
        public static readonly Byte[] Version2 = Util.Helpers.Convert.ToBytes( "2" );
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建Api资源实体
        /// </summary>
        public static Api Create(string id = "") 
		{
            return 
			new Api( id.ToGuid() ) {
                Name = Name,
                DisplayName = DisplayName,
                Description = Description,
                ClaimTypes = ClaimTypes,
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
        public static Api Create2( string id = "" ) 
		{
            return 
			new Api( id.ToGuid() ) {
                Name = Name2,
                DisplayName = DisplayName2,
                Description = Description2,
                ClaimTypes = ClaimTypes2,
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
        public static List<Api> CreateList() 
		{
            return new List<Api>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}