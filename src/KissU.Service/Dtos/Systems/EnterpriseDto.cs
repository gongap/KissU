using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using Util.Applications.Dtos;

namespace KissU.Service.Dtos.Systems {
    /// <summary>
    /// 企业参数
    /// </summary>
    public class EnterpriseDto : DtoBase {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        [StringLength( 200 )]
        [Display( Name = "名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Display( Name = "是否启用" )]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        [StringLength( 200 )]
        [Display( Name = "拼音" )]
        public string PinYin { get; set; }
        /// <summary>
        /// Wcf地址
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "Wcf地址" )]
        public string WcfAddress { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 500 )]
        [Display( Name = "备注" )]
        public string Note { get; set; }
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