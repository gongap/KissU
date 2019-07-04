using System;
using System.Collections.Generic;
using Util;
using KissU.GreatWall.Systems.Domain.Models;

namespace KissU.GreatWall.Test.Models.Systems {
    /// <summary>
    /// 资源测试数据
    /// </summary>
    public partial class ResourceTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 资源标识
        /// </summary>
        public static readonly Guid Id = "75e6ed21-975f-43d7-b13f-1ad8cdf07ddf".ToGuid();
        /// <summary>
        /// 应用程序标识
        /// </summary>
        public static readonly Guid? ApplicationId = "211e690f-e6a8-4215-9c96-c8d77167651e".ToGuid();
        /// <summary>
        /// 资源标识
        /// </summary>
        public static readonly string Uri = "Uri";
        /// <summary>
        /// 资源名称
        /// </summary>
        public static readonly string Name = "Name";
        /// <summary>
        /// 资源类型
        /// </summary>
        public static readonly int Type = 1;
        /// <summary>
        /// 父标识
        /// </summary>
        public static readonly Guid? ParentId = "e1c79e3b-cd93-4eda-8fb9-252a2cf702c8".ToGuid();
        /// <summary>
        /// 路径
        /// </summary>
        public static readonly string Path = "Path";
        /// <summary>
        /// 层级
        /// </summary>
        public static readonly int? Level = 1;
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Remark = "Remark";
        /// <summary>
        /// 拼音简码
        /// </summary>
        public static readonly string PinYin = "PinYin";
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled = true;
        /// <summary>
        /// 排序号
        /// </summary>
        public static readonly int? SortId = 1;
        /// <summary>
        /// 扩展
        /// </summary>
        public static readonly string Extend = "Extend";
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime? CreationTime = "2019/7/4 22:34:20".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId = "8a25543f-c819-467e-abe2-358194f3a679".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime = "2019/7/4 22:34:20".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId = "3754decb-e7ba-4f6f-ad82-f5ab6e02b0bd".ToGuid();
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
        /// 资源标识
        /// </summary>
        public static readonly Guid Id2 = "f5f2b995-d250-4d0e-95cb-2457d055f5dc".ToGuid();
        /// <summary>
        /// 应用程序标识
        /// </summary>
        public static readonly Guid? ApplicationId2 = "c5334e9b-927d-4f27-8960-e6f093d04a4a".ToGuid();
        /// <summary>
        /// 资源标识
        /// </summary>
        public static readonly string Uri2 = "Uri2";
        /// <summary>
        /// 资源名称
        /// </summary>
        public static readonly string Name2 = "Name2";
        /// <summary>
        /// 资源类型
        /// </summary>
        public static readonly int Type2 = 2;
        /// <summary>
        /// 父标识
        /// </summary>
        public static readonly Guid? ParentId2 = "851971c1-c308-4c66-a98a-404ee8bacdf3".ToGuid();
        /// <summary>
        /// 路径
        /// </summary>
        public static readonly string Path2 = "Path2";
        /// <summary>
        /// 层级
        /// </summary>
        public static readonly int? Level2 = 2;
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Remark2 = "Remark2";
        /// <summary>
        /// 拼音简码
        /// </summary>
        public static readonly string PinYin2 = "PinYin2";
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled2 = true;
        /// <summary>
        /// 排序号
        /// </summary>
        public static readonly int? SortId2 = 2;
        /// <summary>
        /// 扩展
        /// </summary>
        public static readonly string Extend2 = "Extend2";
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime? CreationTime2 = "2019/7/5 22:34:20".ToDate();
        /// <summary>
        /// 创建人编号
        /// </summary>
        public static readonly Guid? CreatorId2 = "826e1b83-f0de-466e-8a0f-dfbc009fae09".ToGuid();
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public static readonly DateTime? LastModificationTime2 = "2019/7/5 22:34:20".ToDate();
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public static readonly Guid? LastModifierId2 = "f25e7f75-fc9a-4cd2-93a1-3f38e24a8abe".ToGuid();
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
        /// 创建资源实体
        /// </summary>
        public static Resource Create(string id = "") {
            return new Resource( id.ToGuid() ) {
                ApplicationId = ApplicationId,
                Uri = Uri,
                Name = Name,
                Type = Type,
                ParentId = ParentId,
                Path = Path,
                Level = Level,
                Remark = Remark,
                PinYin = PinYin,
                Enabled = Enabled,
                SortId = SortId,
                Extend = Extend,
                CreationTime = CreationTime,
                CreatorId = CreatorId,
                LastModificationTime = LastModificationTime,
                LastModifierId = LastModifierId,
                IsDeleted = IsDeleted,
                Version = Version,
            };
        }
        
        /// <summary>
        /// 创建资源实体2
        /// </summary>
        /// <param name="id">资源编号</param>
        public static Resource Create2( string id = "" ) {
            return new Resource( id.ToGuid() ) {
                ApplicationId = ApplicationId2,
                Uri = Uri2,
                Name = Name2,
                Type = Type2,
                ParentId = ParentId2,
                Path = Path2,
                Level = Level2,
                Remark = Remark2,
                PinYin = PinYin2,
                Enabled = Enabled2,
                SortId = SortId2,
                Extend = Extend2,
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
        public static List<Resource> CreateList() {
            return new List<Resource>() {
                Create(),
                Create2()
            };
        }

        #endregion
    }
}