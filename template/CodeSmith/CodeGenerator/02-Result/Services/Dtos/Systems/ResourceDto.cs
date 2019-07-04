using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Data;

namespace GreatWall.Service.Dtos.Systems {
    /// <summary>
    /// 资源数据传输对象
    /// </summary>
    public class ResourceDto : TreeDto<ResourceDto> {
        /// <summary>
        /// 应用程序标识
        /// </summary>
        [Display( Name = "应用程序标识" )]
        public Guid? ApplicationId { get; set; }
        /// <summary>
        /// 资源标识
        /// </summary>
        [StringLength( 300 )]
        [Display( Name = "资源标识" )]
        public string Uri { get; set; }
        /// <summary>
        /// 资源名称
        /// </summary>
        [Required(ErrorMessage = "资源名称不能为空")]
        [StringLength( 200 )]
        [Display( Name = "资源名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 资源类型
        /// </summary>
        [Required(ErrorMessage = "资源类型不能为空")]
        [Display( Name = "资源类型" )]
        public int Type { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 500 )]
        [Display( Name = "备注" )]
        public string Remark { get; set; }
        /// <summary>
        /// 拼音简码
        /// </summary>
        [StringLength( 200 )]
        [Display( Name = "拼音简码" )]
        public string PinYin { get; set; }
        /// <summary>
        /// 扩展
        /// </summary>
        [Display( Name = "扩展" )]
        public string Extend { get; set; }
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