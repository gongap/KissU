﻿using System;
using System.ComponentModel.DataAnnotations;
using KissU.Core.Datas.Queries.Trees;

namespace KissU.Modules.GreatWall.Application.Queries
{
    /// <summary>
    /// 角色查询参数
    /// </summary>
    public class RoleQuery : TreeQueryParameter
    {
        private string _code = string.Empty;

        private string _name = string.Empty;

        private string _pinYin = string.Empty;

        private string _remark = string.Empty;

        private string _type = string.Empty;

        /// <summary>
        /// 角色标识
        /// </summary>
        [Display(Name = "角色标识")]
        public Guid? RoleId { get; set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        [Display(Name = "角色编码")]
        public string Code
        {
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Display(Name = "角色名称")]
        public string Name
        {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }

        /// <summary>
        /// 角色类型
        /// </summary>
        [Display(Name = "角色类型")]
        public string Type
        {
            get => _type == null ? string.Empty : _type.Trim();
            set => _type = value;
        }

        /// <summary>
        /// 管理员
        /// </summary>
        [Display(Name = "管理员")]
        public bool? IsAdmin { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark
        {
            get => _remark == null ? string.Empty : _remark.Trim();
            set => _remark = value;
        }

        /// <summary>
        /// 拼音简码
        /// </summary>
        [Display(Name = "拼音简码")]
        public string PinYin
        {
            get => _pinYin == null ? string.Empty : _pinYin.Trim();
            set => _pinYin = value;
        }

        /// <summary>
        /// 起始创建时间
        /// </summary>
        [Display(Name = "起始创建时间")]
        public DateTime? BeginCreationTime { get; set; }

        /// <summary>
        /// 结束创建时间
        /// </summary>
        [Display(Name = "结束创建时间")]
        public DateTime? EndCreationTime { get; set; }

        /// <summary>
        /// 创建人编号
        /// </summary>
        [Display(Name = "创建人编号")]
        public Guid? CreatorId { get; set; }
    }
}