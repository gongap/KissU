using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using Util.Applications.Dtos;

namespace KissU.Service.Dtos.Systems 
{
    /// <summary>
    /// Api资源数据传输对象
    /// </summary>
    public class ApiDto : DtoBase 
	{
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        [StringLength( 200, ErrorMessage = "名称输入过长，不能超过200位" )]
        [Display( Name = "名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 显示名
        /// </summary>
        [StringLength( 200, ErrorMessage = "显示名输入过长，不能超过200位" )]
        [Display( Name = "显示名" )]
        public string DisplayName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength( 1000, ErrorMessage = "描述输入过长，不能超过1000位" )]
        [Display( Name = "描述" )]
        public string Description { get; set; }
        /// <summary>
        /// 声明类型
        /// </summary>
        [StringLength( 2000, ErrorMessage = "声明类型输入过长，不能超过2000位" )]
        [Display( Name = "声明类型" )]
        public string ClaimTypes { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Display( Name = "是否启用" )]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public Byte[] Version { get; set; }
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
        /// <summary>
        /// 
        /// </summary>
        [Display( Name = "" )]
        public bool? IsDeleted { get; set; }
    }
}