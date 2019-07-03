using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using Util.Applications.Dtos;
using System.Collections.Generic;

namespace KissU.Service.Dtos.Systems {
    /// <summary>
    /// Api资源创建参数
    /// </summary>
    public class ApiCreateRequest : RequestBase
    {
        /// <summary>
        /// 许可范围
        /// </summary>
        [Display(Name = "许可范围")]
        public List<ApiScopeDto> ApiScopes { get; set; }
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
        /// 是否启用
        /// </summary>
        [Display( Name = "是否启用" )]
        public bool? Enabled { get; set; }
    }
}