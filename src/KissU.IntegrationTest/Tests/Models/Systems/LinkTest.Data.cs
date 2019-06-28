using System;
using System.Collections.Generic;
using Util;
using KissU.Domain.Systems.Models;

namespace KissU.IntegrationTest.Tests.Models.Systems 
{
    /// <summary>
    /// 链接测试数据
    /// </summary>
    public partial class LinkTest 
	{
        
        #region 测试数据1
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid Id = "faa7baeb-f932-4920-9169-039114e1a665".ToGuid();
        /// <summary>
        /// 编码
        /// </summary>
        public static readonly string Code = "Code";
        /// <summary>
        /// 标题
        /// </summary>
        public static readonly string Title = "Title";
        /// <summary>
        /// 地址
        /// </summary>
        public static readonly string Address = "Address";
        /// <summary>
        /// 图片
        /// </summary>
        public static readonly string Image = "Image";
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Comment = "Comment";
        /// <summary>
        /// 是否启用
        /// </summary>
        public static readonly bool? Enabled = true;
        /// <summary>
        /// 状态
        /// </summary>
        public static readonly int? Status = 1;
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? CreationTime = "2019/6/28 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId = "6d936173-728c-4a7c-ad12-29cbca240641".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/6/28 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId = "e1395e68-8641-4a9f-850f-1ff040c1e520".ToGuid();
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
        public static readonly Guid Id2 = "ca555161-8cd1-4ba3-ad90-15d01b9623a7".ToGuid();
        /// <summary>
        /// 编码
        /// </summary>
        public static readonly string Code2 = "Code2";
        /// <summary>
        /// 标题
        /// </summary>
        public static readonly string Title2 = "Title2";
        /// <summary>
        /// 地址
        /// </summary>
        public static readonly string Address2 = "Address2";
        /// <summary>
        /// 图片
        /// </summary>
        public static readonly string Image2 = "Image2";
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Comment2 = "Comment2";
        /// <summary>
        /// 是否启用
        /// </summary>
        public static readonly bool? Enabled2 = true;
        /// <summary>
        /// 状态
        /// </summary>
        public static readonly int? Status2 = 2;
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? CreationTime2 = "2019/6/29 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? CreatorId2 = "46581564-622f-48be-82a1-1c0aded5a3ac".ToGuid();
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/6/29 14:04:32".ToDate();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid? LastModifierId2 = "620c3534-5d78-42cd-a2e7-1959d13a0d0e".ToGuid();
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
        /// 创建链接实体
        /// </summary>
        public static Link Create(string id = "") 
		{
            return 
			new Link( id.ToGuid() ) {
                Code = Code,
                Title = Title,
                Address = Address,
                Image = Image,
                Comment = Comment,
                Status = Status,
                CreationTime = CreationTime,
                CreatorId = CreatorId,
                LastModificationTime = LastModificationTime,
                LastModifierId = LastModifierId,
                IsDeleted = IsDeleted,
                Version = Version,
            };
        }
        
        /// <summary>
        /// 创建链接实体2
        /// </summary>
        /// <param name="id">链接编号</param>
        public static Link Create2( string id = "" ) 
		{
            return 
			new Link( id.ToGuid() ) {
                Code = Code2,
                Title = Title2,
                Address = Address2,
                Image = Image2,
                Comment = Comment2,
                Status = Status2,
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
        public static List<Link> CreateList() 
		{
            return new List<Link>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}