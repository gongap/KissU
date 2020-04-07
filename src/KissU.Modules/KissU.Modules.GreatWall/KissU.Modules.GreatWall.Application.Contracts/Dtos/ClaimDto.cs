using System;
using System.ComponentModel.DataAnnotations;
using KissU.Util.Ddd.Application.Contracts.Dtos;

namespace KissU.Modules.GreatWall.Application.Contracts.Dtos
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
        /// 启用
        /// </summary>
        [Display(Name = "启用")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [Display(Name = "排序号")]
        public int? SortId { get; set; }

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
        public byte[] Version { get; set; }
    }
}