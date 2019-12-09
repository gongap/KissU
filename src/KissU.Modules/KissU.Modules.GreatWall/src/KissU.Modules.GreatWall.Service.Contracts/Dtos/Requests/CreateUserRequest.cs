// <copyright file="CreateUserRequest.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.GreatWall.Service.Contracts.Dtos.Requests
{
    using System.ComponentModel.DataAnnotations;
    using Util.Applications.Dtos;

    /// <summary>
    ///     创建用户参数
    /// </summary>
    public class CreateUserRequest : RequestBase
    {
        /// <summary>
        ///     用户名
        /// </summary>
        [StringLength(256)]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        ///     安全邮箱
        /// </summary>
        [StringLength(256)]
        [EmailAddress]
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        /// <summary>
        ///     安全手机
        /// </summary>
        [StringLength(64)]
        [Phone]
        [Display(Name = "手机号")]
        public string PhoneNumber { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(256)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }
    }
}
