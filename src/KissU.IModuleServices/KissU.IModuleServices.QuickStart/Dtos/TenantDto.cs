using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Applications.Dtos;

namespace KissU.IModuleServices.QuickStart.Dtos
{
    /// <summary>
    /// 租户数据传输对象
    /// </summary>
    public class TenantDto : DtoBase
    {
        /// <summary>
        /// 租户编码
        /// </summary>
        [Required(ErrorMessage = "租户编码不能为空")]
        [StringLength(60, ErrorMessage = "租户编码输入过长，不能超过60位")]
        [Display(Name = "租户编码")]
        [DataMember]
        public string Code { get; set; }
        /// <summary>
        /// 租户名称
        /// </summary>
        [Required(ErrorMessage = "租户名称不能为空")]
        [StringLength(200, ErrorMessage = "租户名称输入过长，不能超过200位")]
        [Display(Name = "租户名称")]
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(500, ErrorMessage = "备注输入过长，不能超过500位")]
        [Display(Name = "备注")]
        [DataMember]
        public string Comment { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [Display(Name = "启用")]
        [DataMember]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        [DataMember]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人编号
        /// </summary>
        [Display(Name = "创建人编号")]
        [DataMember]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Display(Name = "最后修改时间")]
        [DataMember]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        [Display(Name = "最后修改人编号")]
        [DataMember]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Display(Name = "是否删除")]
        [DataMember]
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        [Display(Name = "版本号")]
        [DataMember]
        public Byte[] Version { get; set; }
    }
}