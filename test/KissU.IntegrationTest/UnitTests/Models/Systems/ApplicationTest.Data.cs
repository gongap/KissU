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
        public static readonly Guid Id = "820d5a8f-8f38-4591-9204-53580e4949d9".ToGuid();
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
        public static readonly DateTime? CreationTime = "2019/6/19 17:27:08".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId = "9c8b1cae-4ab4-4621-9f9d-831adafdfcfd".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/6/19 17:27:08".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId = "8ce88851-7fe3-4e56-a093-52396a9132c7".ToGuid();
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
        public static readonly Guid Id2 = "83d77017-382a-46e8-8665-5a5924b8c7e4".ToGuid();
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
        public static readonly DateTime? CreationTime2 = "2019/6/20 17:27:08".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId2 = "64c3eb6f-1715-4d04-953e-137cec0a9df2".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/6/20 17:27:08".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId2 = "3213773c-5be5-4328-9533-2cb4d1661564".ToGuid();
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
        public static Application Create(string id = "") {
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
        public static Application Create2( string id = "" ) {
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
        public static List<Application> CreateList() {
            return new List<Application>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}