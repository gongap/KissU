using System;
using System.Collections.Generic;
using Util;
using GreatWall.Systems.Domain.Models;

namespace GreatWall.Test.Models.Systems {
    /// <summary>
    /// 角色测试数据
    /// </summary>
    public partial class RoleTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 角色标识
        /// </summary>
        public static readonly Guid Id = "366712da-3b29-49e2-87d7-a6b2bc349fef".ToGuid();
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
        /// 父标识
        /// </summary>
        public static readonly Guid? ParentId = "49414232-59af-4b51-b42b-e2f7b969540e".ToGuid();
        /// <summary>
        /// 路径
        /// </summary>
        public static readonly string Path = "Path";
        /// <summary>
        /// 层级
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
        public static readonly string Remark = "Remark";
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
        public static readonly DateTime? CreationTime = "2019/7/4 22:34:20".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId = "584e6f18-a3c4-49bd-bbc3-fbf9f747fff2".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/7/4 22:34:20".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId = "38a3e038-8961-45f8-b709-e075a0e0d021".ToGuid();
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
        /// 角色标识
        /// </summary>
        public static readonly Guid Id2 = "33ffb01f-db6c-4cbb-9fc7-4caeb2bfecfc".ToGuid();
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
        /// 父标识
        /// </summary>
        public static readonly Guid? ParentId2 = "b319bb28-2deb-44de-abaa-d231b88122ee".ToGuid();
        /// <summary>
        /// 路径
        /// </summary>
        public static readonly string Path2 = "Path2";
        /// <summary>
        /// 层级
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
        public static readonly string Remark2 = "Remark2";
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
        public static readonly DateTime? CreationTime2 = "2019/7/5 22:34:20".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId2 = "0aea0277-690d-4fe3-88da-ea71ceebb389".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/7/5 22:34:20".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId2 = "9ca72960-a907-4836-91b2-579b24349bab".ToGuid();
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
                Remark = Remark,
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
                Remark = Remark2,
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