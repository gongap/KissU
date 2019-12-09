// <copyright file="ResourcePo.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Data.Pos
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using KissU.Modules.GreatWall.Domain.Shared.Enums;
    using Util.Datas.Persistence;
    using Util.Domains;
    using Util.Domains.Auditing;

    /// <summary>
    /// 资源持久化对象
    /// </summary>
    public class ResourcePo : TreePersistentObjectBase, IDelete, IAudited
    {
        /// <summary>
        /// 应用程序标识
        /// </summary>
        public Guid? ApplicationId { get; set; }

        /// <summary>
        /// 资源标识
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// 资源名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 资源类型
        /// </summary>
        public ResourceType Type { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 拼音简码
        /// </summary>
        public string PinYin { get; set; }

        /// <summary>
        /// 扩展
        /// </summary>
        public string Extend { get; set; }

        /// <summary>
        /// 应用程序
        /// </summary>
        [ForeignKey("ApplicationId")]
        public ApplicationPo Application { get; set; }

        /// <summary>
        /// 父资源
        /// </summary>
        [ForeignKey("ParentId")]
        public ResourcePo Parent { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// 创建人编号
        /// </summary>
        public Guid? CreatorId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 最后修改人编号
        /// </summary>
        public Guid? LastModifierId { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
