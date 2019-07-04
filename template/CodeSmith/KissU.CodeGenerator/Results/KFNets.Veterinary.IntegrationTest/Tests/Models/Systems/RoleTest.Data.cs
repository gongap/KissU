using System;
using System.Collections.Generic;
using Util;
using KFNets.Veterinary.Domain.Systems.Models;

namespace KFNets.Veterinary.IntegrationTest.Tests.Models.Systems 
{
    /// <summary>
    /// 角色测试数据
    /// </summary>
    public partial class RoleTest 
	{
        
        #region 测试数据1
        
        /// <summary>
        /// 角色编号
        /// </summary>
        public static readonly Guid Id = "32767e99-195d-4946-8de2-df2c1cb87be1".ToGuid();
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
        public static readonly Guid? ParentId = "e4495d36-7283-45cf-94f2-0f7d179991c6".ToGuid();
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
        public static readonly DateTime? CreationTime = "2019/7/2 16:36:51".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId = "355cd241-4d35-4c63-90c4-27bb1f63b0d5".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/7/2 16:36:51".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId = "7378fa4a-31a6-49bc-a341-cd0653fe00d4".ToGuid();
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
        public static readonly Guid Id2 = "921d8d24-219f-48d1-ab37-66147308c82d".ToGuid();
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
        public static readonly Guid? ParentId2 = "08d6cf79-9112-49e5-9cab-8eb1d68d52f2".ToGuid();
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
        public static readonly DateTime? CreationTime2 = "2019/7/3 16:36:51".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId2 = "0882c83c-965a-48e2-838c-9ff943c4a936".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/7/3 16:36:51".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId2 = "8f1460f9-60ab-45b5-9f98-a58d6b424f87".ToGuid();
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
        public static Role Create(string id = "") 
		{
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
        public static Role Create2( string id = "" ) 
		{
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
        public static List<Role> CreateList() 
		{
            return new List<Role>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}