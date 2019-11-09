using System;
using System.ComponentModel.DataAnnotations;
using Util.Ui.Data;

namespace KissU.IModuleServices.GreatWall.Dtos
{
    /// <summary>
    /// 角色参数
    /// </summary>
    public class RoleDto : TreeDto<RoleDto>
    {
        /// <summary>
        /// 角色编码
        /// </summary>
        [Required(ErrorMessage = "角色编码不能为空")]
        [StringLength(256)]
        [Display(Name = "角色编码")]
        public string Code { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Required(ErrorMessage = "角色名称不能为空")]
        [StringLength(256)]
        [Display(Name = "角色名称")]
        public string Name { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        [StringLength(80)]
        [Display(Name = "角色类型")]
        public string Type { get; set; }

        /// <summary>
        /// 管理员
        /// </summary>
        [Display(Name = "管理员")]
        public bool? IsAdmin { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(500)]
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 拼音简码
        /// </summary>
        [StringLength(200)]
        [Display(Name = "拼音简码")]
        public string PinYin { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [Display(Name = "版本号")]
        public Byte[] Version { get; set; }
    }
}