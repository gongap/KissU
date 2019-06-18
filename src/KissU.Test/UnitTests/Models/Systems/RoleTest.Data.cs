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
        public static readonly Guid Id = "30de0f72-b123-4ff4-a49f-82f835502a99".ToGuid();
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
        public static readonly Guid? ParentId = "669f3eb7-aef6-4b85-95cf-d5d5c3508545".ToGuid();
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
        public static readonly DateTime? CreationTime = "2019/6/19 1:27:59".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId = "5df7b9fb-c0a0-4606-be06-a75549fc0fc4".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/6/19 1:27:59".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId = "c72a2e12-28d2-49de-84e7-033606271049".ToGuid();
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
        public static readonly Guid Id2 = "9618d701-6521-4061-bd46-22fb9d895666".ToGuid();
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
        public static readonly Guid? ParentId2 = "54fe6ad0-05d4-426b-8ba0-a12ba0456130".ToGuid();
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
        public static readonly DateTime? CreationTime2 = "2019/6/20 1:27:59".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId2 = "2ff6dc6a-d894-4a69-96a8-a4bd6a6b16e4".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/6/20 1:27:59".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId2 = "4c9460d4-01cd-4dc4-a1bb-99b802a78771".ToGuid();
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
        /// 创建角色实体
        /// </summary>
        public static Role Create(string id = "") {
            return new Role( id.ToGuid() ) {
                Code = Code,
                Name = Name,
                NormalizedName = NormalizedName,
                Type = Type,
                IsAdmin = IsAdmin,
                ParentId = ParentId,
                Path = Path,
                Level = Level,
                SortId = SortId,
                Enabled = Enabled,
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
            return new Role( id.ToGuid() ) {
                Code = Code2,
                Name = Name2,
                NormalizedName = NormalizedName2,
                Type = Type2,
                IsAdmin = IsAdmin2,
                ParentId = ParentId2,
                Path = Path2,
                Level = Level2,
                SortId = SortId2,
                Enabled = Enabled2,
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