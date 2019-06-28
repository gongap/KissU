using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using Util.Applications.Dtos;

namespace KissU.Service.Dtos.Systems {
    /// <summary>
    /// Api许可范围参数
    /// </summary>
    public class ApiScopeDto : DtoBase {
        /// <summary>
        /// Api资源标识
        /// </summary>
        [Required(ErrorMessage = "Api资源标识不能为空")]
        [Display( Name = "Api资源标识" )]
        public Guid ApiId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        [StringLength( 200 )]
        [Display( Name = "名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 显示名
        /// </summary>
        [StringLength( 200 )]
        [Display( Name = "显示名" )]
        public string DisplayName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength( 1000 )]
        [Display( Name = "描述" )]
        public string Description { get; set; }
        /// <summary>
        /// 声明类型
        /// </summary>
        [StringLength( 2000 )]
        [Display( Name = "声明类型" )]
        public string ClaimTypes { get; set; }
        /// <summary>
        /// 是否必选
        /// </summary>
        [Display( Name = "是否必选" )]
        public bool? Required { get; set; }
        /// <summary>
        /// 是否强调
        /// </summary>
        [Display( Name = "是否强调" )]
        public bool? Emphasize { get; set; }
        /// <summary>
        /// 是否显示在发现文档中
        /// </summary>
        [Display( Name = "是否显示在发现文档中" )]
        public bool? ShowInDiscoveryDocument { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public Guid? LastModifierId { get; set; }
    }
}