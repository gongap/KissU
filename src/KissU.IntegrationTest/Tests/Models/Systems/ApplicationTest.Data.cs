using System;
using System.Collections.Generic;
using Util;
using KissU.Domain.Systems.Models;

namespace KissU.IntegrationTest.Tests.Models.Systems 
{
    /// <summary>
    /// 应用程序测试数据
    /// </summary>
    public partial class ApplicationTest 
	{
        
        #region 测试数据1
        
        /// <summary>
        /// 应用程序编号
        /// </summary>
        public static readonly Guid Id = "16dea4d1-0bd0-44c3-8763-30edb71e45f2".ToGuid();
        /// <summary>
        /// 应用程序编码
        /// </summary>
        public static readonly string Code = "Code";
        /// <summary>
        /// 应用程序名称
        /// </summary>
        public static readonly string Name = "Name";
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Comment = "Comment";
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled = true;
        /// <summary>
        /// 启用注册
        /// </summary>
        public static readonly bool RegisterEnabled = true;
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime? CreationTime = "2019/6/28 14:04:32".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId = "f1924828-7141-483d-bc2c-fc2e686886cb".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/6/28 14:04:32".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId = "53e232c4-d5a8-43f5-9be4-b1d3a463ee98".ToGuid();
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
        /// 应用程序编号
        /// </summary>
        public static readonly Guid Id2 = "77c05176-b003-4347-a000-be88f4cf5edf".ToGuid();
        /// <summary>
        /// 应用程序编码
        /// </summary>
        public static readonly string Code2 = "Code2";
        /// <summary>
        /// 应用程序名称
        /// </summary>
        public static readonly string Name2 = "Name2";
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Comment2 = "Comment2";
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled2 = true;
        /// <summary>
        /// 启用注册
        /// </summary>
        public static readonly bool RegisterEnabled2 = true;
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime? CreationTime2 = "2019/6/29 14:04:32".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId2 = "6d8f8d52-da72-48c3-9d23-a3946674d8cc".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/6/29 14:04:32".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId2 = "dc1327d3-1008-4bd2-8eaa-b9a9f2a74f5c".ToGuid();
        /// <summary>
        /// 是否删除
        /// </summary>
        public static readonly bool IsDeleted2 = false;
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version2 = Util.Helpers.Convert.ToBytes( "2" );
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建应用程序实体
        /// </summary>
        public static Application Create(string id = "") 
		{
            return 
			new Application( id.ToGuid() ) {
                Code = Code,
                Name = Name,
                Comment = Comment,
                RegisterEnabled = RegisterEnabled,
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
        public static Application Create2( string id = "" ) 
		{
            return 
			new Application( id.ToGuid() ) {
                Code = Code2,
                Name = Name2,
                Comment = Comment2,
                RegisterEnabled = RegisterEnabled2,
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
        public static List<Application> CreateList() 
		{
            return new List<Application>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}