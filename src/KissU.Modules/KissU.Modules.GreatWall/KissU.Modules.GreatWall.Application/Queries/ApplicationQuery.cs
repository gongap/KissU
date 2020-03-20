using System;
using System.ComponentModel.DataAnnotations;
using KissU.Core.Datas.Queries;

namespace KissU.Modules.GreatWall.Application.Queries
{
    /// <summary>
    /// 应用程序查询参数
    /// </summary>
    public class ApplicationQuery : QueryParameter
    {
        private string _code = string.Empty;

        private string _name = string.Empty;

        private string _remark = string.Empty;

        /// <summary>
        /// 应用程序标识
        /// </summary>
        [Display(Name = "应用程序标识")]
        public Guid? ApplicationId { get; set; }

        /// <summary>
        /// 应用程序编码
        /// </summary>
        [Display(Name = "应用程序编码")]
        public string Code
        {
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }

        /// <summary>
        /// 应用程序名称
        /// </summary>
        [Display(Name = "应用程序名称")]
        public string Name
        {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }

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
        [Display(Name = "备注")]
        public string Remark
        {
            get => _remark == null ? string.Empty : _remark.Trim();
            set => _remark = value;
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

        /// <summary>
        /// 起始最后修改时间
        /// </summary>
        [Display(Name = "起始最后修改时间")]
        public DateTime? BeginLastModificationTime { get; set; }

        /// <summary>
        /// 结束最后修改时间
        /// </summary>
        [Display(Name = "结束最后修改时间")]
        public DateTime? EndLastModificationTime { get; set; }

        /// <summary>
        /// 最后修改人编号
        /// </summary>
        [Display(Name = "最后修改人编号")]
        public Guid? LastModifierId { get; set; }
    }
}