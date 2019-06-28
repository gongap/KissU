using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using Util.Applications.Dtos;

namespace KissU.Service.Dtos.Systems {
    /// <summary>
    /// 链接参数
    /// </summary>
    public class LinkDto : DtoBase {
        /// <summary>
        /// 编码
        /// </summary>
        [Required(ErrorMessage = "编码不能为空")]
        [StringLength( 50 )]
        [Display( Name = "编码" )]
        public string Code { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "标题" )]
        public string Title { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Required(ErrorMessage = "地址不能为空")]
        [StringLength( 16 )]
        [Display( Name = "地址" )]
        public string Address { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "图片" )]
        public string Image { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 500 )]
        [Display( Name = "备注" )]
        public string Comment { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Display( Name = "是否启用" )]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Display( Name = "状态" )]
        public int? Status { get; set; }
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
        public Byte[] Version { get; set; }
    }
}