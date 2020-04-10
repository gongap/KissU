using System;
using System.ComponentModel.DataAnnotations;
using KissU.Core.Datas.Queries;

namespace KissU.Modules.GreatWall.Application.Contracts.Queries
{
    /// <summary>
    /// 声明查询参数
    /// </summary>
    public class ClaimQuery : QueryParameter
    {
        private string _name = string.Empty;

        private string _remark = string.Empty;

        /// <summary>
        /// 声明标识
        /// </summary>
        [Display(Name = "声明标识")]
        public Guid? ClaimId { get; set; }

        /// <summary>
        /// 声明名称
        /// </summary>
        [Display(Name = "声明名称")]
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
        /// 排序号
        /// </summary>
        [Display(Name = "排序号")]
        public int? SortId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark
        {
            get => _remark == null ? string.Empty : _remark.Trim();
            set => _remark = value;
        }
    }
}