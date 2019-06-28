using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Data;

namespace KissU.Service.Dtos.Systems {
    /// <summary>
    /// 角色数据传输对象
    /// </summary>
    public class RoleDto : TreeDto<RoleDto> {
        /// <summary>
        /// 角色编码
        /// </summary>
        [Required(ErrorMessage = "角色编码不能为空")]
        [StringLength( 256 )]
        [Display( Name = "角色编码" )]
        public string Code { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required(ErrorMessage = "角色名称不能为空")]
        [StringLength( 256 )]
        [Display( Name = "角色名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 标准化角色名称
        /// </summary>
        [Required(ErrorMessage = "标准化角色名称不能为空")]
        [StringLength( 256 )]
        [Display( Name = "标准化角色名称" )]
        public string NormalizedName { get; set; }
        /// <summary>
        /// 角色类型
        /// </summary>
        [Required(ErrorMessage = "角色类型不能为空")]
        [StringLength( 80 )]
        [Display( Name = "角色类型" )]
        public string Type { get; set; }
        /// <summary>
        /// 管理员
        /// </summary>
        [Display( Name = "管理员" )]
        public bool? IsAdmin { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 500 )]
        [Display( Name = "备注" )]
        public string Comment { get; set; }
        /// <summary>
        /// 拼音简码
        /// </summary>
        [StringLength( 200 )]
        [Display( Name = "拼音简码" )]
        public string PinYin { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "签名" )]
        public string Sign { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display( Name = "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人编号
        /// </summary>
        [Display( Name = "创建人编号" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Display( Name = "最后修改时间" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        [Display( Name = "最后修改人编号" )]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        [Display( Name = "版本号" )]
        public Byte[] Version { get; set; }
    }
}