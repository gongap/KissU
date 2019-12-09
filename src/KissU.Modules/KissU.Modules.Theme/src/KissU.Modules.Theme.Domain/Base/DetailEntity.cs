// <copyright file="DetailEntity.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.Theme.Domain.Base
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Util.Domains;
    using Util.Domains.Auditing;

    /// <summary>
    ///     从表
    /// </summary>
    public abstract class DetailEntity : EntityBase<DetailEntity>, IAudited
    {
        /// <summary>
        ///     初始化
        /// </summary>
        protected DetailEntity() : this(Guid.Empty)
        {
        }

        /// <summary>
        ///     初始化
        /// </summary>
        /// <param name="id">语言国际化配置标识</param>
        protected DetailEntity(Guid id) : base(id)
        {
        }

        /// <summary>
        ///     主表标识
        /// </summary>
        [DisplayName("主表标识")]
        [Required(ErrorMessage = "主表标识不能为空")]
        public Guid MainId { get; set; }

        /// <summary>
        ///     创建人
        /// </summary>
        [DisplayName("创建人")]
        public Guid? CreatorId { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime? CreationTime { get; set; }

        /// <summary>
        ///     修改人
        /// </summary>
        [DisplayName("修改人")]
        public Guid? LastModifierId { get; set; }

        /// <summary>
        ///     修改时间
        /// </summary>
        [DisplayName("修改时间")]
        public DateTime? LastModificationTime { get; set; }
    }
}
