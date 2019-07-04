using System;
using System.Collections.Generic;
using Util;
using KFNets.Veterinary.Domain.Systems.Models;

namespace KFNets.Veterinary.IntegrationTest.Tests.Models.Systems 
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
        public static readonly Guid Id = "d6cc0cf9-2c76-42af-9e34-5bbbf271ae70".ToGuid();
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
        public static readonly DateTime? CreationTime = "2019/7/2 16:36:51".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId = "366eff1d-361e-4819-8072-ec3ff409b53d".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/7/2 16:36:51".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId = "ac187dc3-be13-4d1a-bd46-23095f60e16c".ToGuid();
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
        public static readonly Guid Id2 = "29f71137-1635-4551-8a0d-ec09ee5c9e9b".ToGuid();
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
        public static readonly DateTime? CreationTime2 = "2019/7/3 16:36:51".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId2 = "0a64e464-85f7-4836-b3f3-6577ae7fb541".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/7/3 16:36:51".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId2 = "f8addd87-4b7f-4c27-bb9b-9e7f03d9e8ed".ToGuid();
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