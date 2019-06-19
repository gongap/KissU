using System;
using System.Collections.Generic;
using Util;
using KissU.Domain.Systems.Models;

namespace KissU.Test.Models.Systems {
    /// <summary>
    /// 角色测试数据
    /// </summary>
    public partial class RoleTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 角色编号
        /// </summary>
        public static readonly Guid Id = "e087cd67-1e33-4097-a7e8-c01bf776b227".ToGuid();
        /// <summary>
        /// 角色编码
        /// </summary>
        public static readonly string Code = "Code";
        /// <summary>
        /// 角色名称
        /// </summary>
        public static readonly string Name = "Name";
        /// <summary>
        /// 标准化角色名称
        /// </summary>
        public static readonly string NormalizedName = "NormalizedName";
        /// <summary>
        /// 角色类型
        /// </summary>
        public static readonly string Type = "Type";
        /// <summary>
        /// 管理员
        /// </summary>
        public static readonly bool IsAdmin = true;
        /// <summary>
        /// 父编号
        /// </summary>
        public static readonly Guid? ParentId = "1965a6b0-6b16-4396-9799-0e084bbb9bb4".ToGuid();
        /// <summary>
        /// 路径
        /// </summary>
        public static readonly string Path = "Path";
        /// <summary>
        /// 级数
        /// </summary>
        public static readonly int Level = 1;
        /// <summary>
        /// 排序号
        /// </summary>
        public static readonly int? SortId = 1;
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled = true;
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Comment = "Comment";
        /// <summary>
        /// 拼音简码
        /// </summary>
        public static readonly string PinYin = "PinYin";
        /// <summary>
        /// 签名
        /// </summary>
        public static readonly string Sign = "Sign";
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime? CreationTime = "2019/6/19 17:27:08".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId = "c92d32a5-ed8c-471f-b49a-3caf783f79af".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/6/19 17:27:08".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId = "011e1bae-3735-4280-830e-50060bf714eb".ToGuid();
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
        /// 角色编号
        /// </summary>
        public static readonly Guid Id2 = "26639465-6a39-437d-b3c3-cd2ce399a303".ToGuid();
        /// <summary>
        /// 角色编码
        /// </summary>
        public static readonly string Code2 = "Code2";
        /// <summary>
        /// 角色名称
        /// </summary>
        public static readonly string Name2 = "Name2";
        /// <summary>
        /// 标准化角色名称
        /// </summary>
        public static readonly string NormalizedName2 = "NormalizedName2";
        /// <summary>
        /// 角色类型
        /// </summary>
        public static readonly string Type2 = "Type2";
        /// <summary>
        /// 管理员
        /// </summary>
        public static readonly bool IsAdmin2 = true;
        /// <summary>
        /// 父编号
        /// </summary>
        public static readonly Guid? ParentId2 = "96892060-8c44-475f-88d3-3e728a35e4e3".ToGuid();
        /// <summary>
        /// 路径
        /// </summary>
        public static readonly string Path2 = "Path2";
        /// <summary>
        /// 级数
        /// </summary>
        public static readonly int Level2 = 2;
        /// <summary>
        /// 排序号
        /// </summary>
        public static readonly int? SortId2 = 2;
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled2 = true;
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Comment2 = "Comment2";
        /// <summary>
        /// 拼音简码
        /// </summary>
        public static readonly string PinYin2 = "PinYin2";
        /// <summary>
        /// 签名
        /// </summary>
        public static readonly string Sign2 = "Sign2";
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime? CreationTime2 = "2019/6/20 17:27:08".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId2 = "5b19df04-d0a1-4c56-886c-48e762d560af".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/6/20 17:27:08".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId2 = "33ec021e-2661-47c7-abdb-e7923bad15ce".ToGuid();
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
        /// 创建角色实体
        /// </summary>
        public static Role Create(string id = "") {
            return 
			new Role( id.ToGuid(),"", 0  ) {
                Code = Code,
                Name = Name,
                NormalizedName = NormalizedName,
                Type = Type,
                IsAdmin = IsAdmin,
                Comment = Comment,
                PinYin = PinYin,
                Sign = Sign,
                CreationTime = CreationTime,
                CreatorId = CreatorId,
                LastModificationTime = LastModificationTime,
                LastModifierId = LastModifierId,
                IsDeleted = IsDeleted,
                Version = Version,
            };
        }
        
        /// <summary>
        /// 创建角色实体2
        /// </summary>
        /// <param name="id">角色编号</param>
        public static Role Create2( string id = "" ) {
            return 
			new Role( id.ToGuid(),"", 0 ) {
                Code = Code2,
                Name = Name2,
                NormalizedName = NormalizedName2,
                Type = Type2,
                IsAdmin = IsAdmin2,
                Comment = Comment2,
                PinYin = PinYin2,
                Sign = Sign2,
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
        public static List<Role> CreateList() {
            return new List<Role>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}