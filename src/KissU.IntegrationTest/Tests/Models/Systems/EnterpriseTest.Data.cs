using System;
using System.Collections.Generic;
using Util;
using KissU.Domain.Systems.Models;

namespace KissU.IntegrationTest.Tests.Models.Systems 
{
    /// <summary>
    /// 企业测试数据
    /// </summary>
    public partial class EnterpriseTest 
	{
        
        #region 测试数据1
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Id = "8a7d22bc-34c6-42e9-919d-176fe7fde5c5".ToGuid();
        /// <summary>
        /// 名称
        /// </summary>
        public static readonly string Name = "Name";
        /// <summary>
        /// 是否启用
        /// </summary>
        public static readonly bool Enabled = true;
        /// <summary>
        /// 拼音
        /// </summary>
        public static readonly string PinYin = "PinYin";
        /// <summary>
        /// Wcf地址
        /// </summary>
        public static readonly string WcfAddress = "WcfAddress";
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Note = "Note";
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? CreationTime = "2019/6/28 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId = "b57ff0ef-4bc0-43e2-b34e-d372964dd120".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/6/28 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId = "db4a05f9-3a63-458e-b32f-25d8c0e0434b".ToGuid();
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
        public static readonly Guid Id2 = "4d6aaf95-0647-41d0-84d5-0e020ab17687".ToGuid();
        /// <summary>
        /// 名称
        /// </summary>
        public static readonly string Name2 = "Name2";
        /// <summary>
        /// 是否启用
        /// </summary>
        public static readonly bool Enabled2 = true;
        /// <summary>
        /// 拼音
        /// </summary>
        public static readonly string PinYin2 = "PinYin2";
        /// <summary>
        /// Wcf地址
        /// </summary>
        public static readonly string WcfAddress2 = "WcfAddress2";
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Note2 = "Note2";
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? CreationTime2 = "2019/6/29 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId2 = "c80fba6f-9af7-48eb-b699-4d48c2642c2b".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/6/29 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId2 = "3fdba701-8cd0-4d74-9d89-cf5be1356d3c".ToGuid();
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
        /// 创建企业实体
        /// </summary>
        public static Enterprise Create(string id = "") 
		{
            return 
			new Enterprise( id.ToGuid() ) {
                Name = Name,
                PinYin = PinYin,
                WcfAddress = WcfAddress,
                Note = Note,
                CreationTime = CreationTime,
                CreatorId = CreatorId,
                LastModificationTime = LastModificationTime,
                LastModifierId = LastModifierId,
                IsDeleted = IsDeleted,
                Version = Version,
            };
        }
        
        /// <summary>
        /// 创建企业实体2
        /// </summary>
        /// <param name="id">企业编号</param>
        public static Enterprise Create2( string id = "" ) 
		{
            return 
			new Enterprise( id.ToGuid() ) {
                Name = Name2,
                PinYin = PinYin2,
                WcfAddress = WcfAddress2,
                Note = Note2,
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
        public static List<Enterprise> CreateList() 
		{
            return new List<Enterprise>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}