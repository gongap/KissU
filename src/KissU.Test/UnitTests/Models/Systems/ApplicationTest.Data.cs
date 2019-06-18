using System;
using System.Collections.Generic;
using Util;
using KissU.Domain.Systems.Models;

namespace KissU.Test.Models.Systems {
    /// <summary>
    /// 应用程序测试数据
    /// </summary>
    public partial class ApplicationTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 应用程序编号
        /// </summary>
        public static readonly Guid Id = "1658530a-f5dd-4a10-9aaf-7704292a2381".ToGuid();
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
        public static readonly DateTime? CreationTime = "2019/6/19 1:27:59".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId = "5ee6622e-b582-45c0-abdd-17cff6f14b0f".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/6/19 1:27:59".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId = "41cb3c20-18f6-478c-958c-5af3832cf9b7".ToGuid();
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
        public static readonly Guid Id2 = "ea0c7243-f154-4a89-a298-9bd52b3e3d7c".ToGuid();
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
        public static readonly DateTime? CreationTime2 = "2019/6/20 1:27:59".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId2 = "023ca751-4a01-4277-b9da-96d57115a869".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/6/20 1:27:59".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId2 = "03427cdb-dccc-4a76-aac7-2209e10913c7".ToGuid();
        /// <summary>
        /// 是否删除
        /// </summary>
        public static readonly bool IsDeleted = false;
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version2 = Util.Helpers.Convert.ToBytes( "2" );
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建应用程序实体
        /// </summary>
        public static Application Create(string id = "") {
            return new Application( id.ToGuid() ) {
                Code = Code,
                Name = Name,
                Comment = Comment,
                Enabled = Enabled,
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
        public static Application Create2( string id = "" ) {
            return new Application( id.ToGuid() ) {
                Code = Code2,
                Name = Name2,
                Comment = Comment2,
                Enabled = Enabled2,
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
        public static List<Application> CreateList() {
            return new List<Application>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}