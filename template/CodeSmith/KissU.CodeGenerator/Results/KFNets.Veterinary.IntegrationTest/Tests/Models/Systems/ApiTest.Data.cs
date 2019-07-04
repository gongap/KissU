using System;
using System.Collections.Generic;
using Util;
using KFNets.Veterinary.Domain.Systems.Models;

namespace KFNets.Veterinary.IntegrationTest.Tests.Models.Systems 
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
        public static readonly Guid Id = "da154e64-89e9-467f-9a5d-31e6667a5c03".ToGuid();
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
        public static readonly DateTime? CreationTime = "2019/7/2 16:36:51".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId = "1b21f28e-ae58-4a70-bb39-70b7e96f826d".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/7/2 16:36:51".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId = "677da250-77c8-431b-abae-0b835ef47738".ToGuid();
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
        public static readonly Guid Id2 = "ab2bccd4-1905-4d92-b95d-dd1c2cb33746".ToGuid();
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
        public static readonly DateTime? CreationTime2 = "2019/7/3 16:36:51".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId2 = "c459d09b-893d-48a1-b3bf-4da7052f51f1".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/7/3 16:36:51".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId2 = "19fd2db6-b41a-4355-8add-9d1a979c8031".ToGuid();
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