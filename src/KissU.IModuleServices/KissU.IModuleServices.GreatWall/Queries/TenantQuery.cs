using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace KissU.IModuleServices.QuickStart.Queries
{
    /// <summary>
    /// 租户查询参数
    /// </summary>
    public class TenantQuery : QueryParameter
    {
        private string _code = string.Empty;
        /// <summary>
        /// 租户编码
        /// </summary>
        [Display(Name = "租户编码")]
        public string Code
        {
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }

        /// <summary>
        /// 启用
        /// </summary>
        [Display(Name = "启用")]
        public bool? Enabled { get; set; }
    }
}