using System;
using System.ComponentModel.DataAnnotations;
using KissU.Util.Applications.Dtos;

namespace KissU.Modules.IdentityServer.Application.Dtos
{
    /// <summary>
    /// 设备流代码数据传输对象
    /// </summary>
    public class DeviceFlowCodeDto : DtoBase
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        [Required]
        [StringLength(200)]
        public string DeviceCode { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        [Required]
        [StringLength(200)]
        public string UserCode { get; set; }

        /// <summary>
        /// 主题标识
        /// </summary>
        [StringLength(200)]
        public string SubjectId { get; set; }

        /// <summary>
        /// 设备标识
        /// </summary>
        [Required]
        [StringLength(200)]
        public string ClientId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        [Required]
        public DateTime? Expiration { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [Required]
        [StringLength(50000)]
        public string Data { get; set; }
    }
}