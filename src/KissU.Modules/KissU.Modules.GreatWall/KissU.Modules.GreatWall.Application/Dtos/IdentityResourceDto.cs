using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KissU.Util;
using KissU.Util.Applications.Dtos;

namespace KissU.Modules.GreatWall.Application.Dtos {
    /// <summary>
    /// 身份资源参数
    /// </summary>
    public class IdentityResourceDto : DtoBase {
        /// <summary>
        /// 资源标识
        /// </summary>
        [StringLength( 300 )]
        [Display( Name = "资源标识" )]
        [Required( ErrorMessage = "资源标识不能为空" )]
        public string Uri { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        [StringLength( 200 )]
        [Display( Name = "显示名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength( 500 )]
        [Display( Name = "描述" )]
        public string Remark { get; set; }
        /// <summary>
        /// 必选
        /// </summary>
        [Display( Name = "必选" )]
        public bool? Required { get; set; }
        /// <summary>
        /// 强调
        /// </summary>
        [Display( Name = "强调" )]
        public bool? Emphasize { get; set; }
        /// <summary>
        /// 发现文档中显示
        /// </summary>
        [Display( Name = "发现文档中显示" )]
        public bool? ShowInDiscoveryDocument { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [Display( Name = "启用" )]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 用户声明
        /// </summary>
        [Display( Name = "用户声明" )]
        public List<string> Claims { get; set; }
        /// <summary>
        /// 用户声明
        /// </summary>
        [Display( Name = "用户声明" )]
        public string ClaimsDisplay => Claims.Join();
        /// <summary>
        /// 排序号
        /// </summary>
        [Display( Name = "排序号" )]
        public int? SortId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display( Name = "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人标识
        /// </summary>
        [Display( Name = "创建人标识" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Display( Name = "最后修改时间" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人标识
        /// </summary>
        [Display( Name = "最后修改人标识" )]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        [Display( Name = "版本号" )]
        public Byte[] Version { get; set; }
    }
}