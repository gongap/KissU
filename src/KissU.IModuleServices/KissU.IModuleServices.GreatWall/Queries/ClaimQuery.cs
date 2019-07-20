using System;
using System.ComponentModel.DataAnnotations;
using Util.Datas.Queries;

namespace GreatWall.Service.Queries {
    /// <summary>
    /// 声明查询参数
    /// </summary>
    public class ClaimQuery : QueryParameter {
        /// <summary>
        /// 声明标识
        /// </summary>
        [Display(Name="声明标识")]
        public Guid? ClaimId { get; set; }
        
        private string _name = string.Empty;
        /// <summary>
        /// 声明名称
        /// </summary>
        [Display(Name="声明名称")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        
        private string _remark = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name="备注")]
        public string Remark {
            get => _remark == null ? string.Empty : _remark.Trim();
            set => _remark = value;
        }
    }
}