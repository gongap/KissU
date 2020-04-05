using System;
using System.ComponentModel.DataAnnotations;
using KissU.Core;
using KissU.Modules.GreatWall.Domain.Enums;
using KissU.Util.Ddd.Applications.Dtos;

namespace KissU.Modules.GreatWall.Application.Dtos
{
    /// <summary>
    /// 应用程序参数
    /// </summary>
    public class ApplicationDto : DtoBase
    {
        /// <summary>
        /// 应用程序类型
        /// </summary>
        [Display(Name = "应用程序类型")]
        public ApplicationType ApplicationType { get; set; }

        /// <summary>
        /// 应用程序类型
        /// </summary>
        [Display(Name = "应用程序类型")]
        public string ApplicationTypeName => ApplicationType.Description();

        /// <summary>
        /// 应用程序编码
        /// </summary>
        [Required(ErrorMessage = "应用程序编码不能为空")]
        [StringLength(60)]
        [Display(Name = "应用程序编码")]
        public string Code { get; set; }

        /// <summary>
        /// 应用程序名称
        /// </summary>
        [Required(ErrorMessage = "应用程序名称不能为空")]
        [StringLength(200)]
        [Display(Name = "应用程序名称")]
        public string Name { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [Display(Name = "启用")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// 启用注册
        /// </summary>
        [Display(Name = "启用注册")]
        public bool? RegisterEnabled { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(500)]
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        public Guid? CreatorId { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [Display(Name = "版本号")]
        public byte[] Version { get; set; }
    }
}