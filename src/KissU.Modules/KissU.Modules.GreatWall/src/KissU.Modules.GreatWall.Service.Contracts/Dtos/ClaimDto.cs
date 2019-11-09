using System;
using System.ComponentModel.DataAnnotations;
using Util.Applications.Dtos;

namespace KissU.IModuleServices.GreatWall.Dtos
{
    /// <summary>
    /// 声明参数
    /// </summary>
    public class ClaimDto : DtoBase
    {
        /// <summary>
        /// 声明名称
        /// </summary>
        [Required(ErrorMessage = "声明名称不能为空")]
        [StringLength(200)]
        [Display(Name = "声明名称")]
        public string Name { get; set; }

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
        /// 创建人标识
        /// </summary>
        [Display(Name = "创建人标识")]
        public Guid? CreatorId { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [Display(Name = "版本号")]
        public Byte[] Version { get; set; }
    }
}