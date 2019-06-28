using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace KissU.Service.Queries.Systems {
    /// <summary>
    /// 企业查询参数
    /// </summary>
    public class EnterpriseQuery : QueryParameter {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public Guid? EnterpriseId { get; set; }
        
        private string _name = string.Empty;
        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name="名称")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Display(Name="是否启用")]
        public bool? Enabled { get; set; }
        
        private string _pinYin = string.Empty;
        /// <summary>
        /// 拼音
        /// </summary>
        [Display(Name="拼音")]
        public string PinYin {
            get => _pinYin == null ? string.Empty : _pinYin.Trim();
            set => _pinYin = value;
        }
        
        private string _wcfAddress = string.Empty;
        /// <summary>
        /// Wcf地址
        /// </summary>
        [Display(Name="Wcf地址")]
        public string WcfAddress {
            get => _wcfAddress == null ? string.Empty : _wcfAddress.Trim();
            set => _wcfAddress = value;
        }
        
        private string _note = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name="备注")]
        public string Note {
            get => _note == null ? string.Empty : _note.Trim();
            set => _note = value;
        }
        /// <summary>
        /// 起始
        /// </summary>
        [Display( Name = "起始" )]
        public DateTime? BeginCreationTime { get; set; }
        /// <summary>
        /// 结束
        /// </summary>
        [Display( Name = "结束" )]
        public DateTime? EndCreationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 起始
        /// </summary>
        [Display( Name = "起始" )]
        public DateTime? BeginLastModificationTime { get; set; }
        /// <summary>
        /// 结束
        /// </summary>
        [Display( Name = "结束" )]
        public DateTime? EndLastModificationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public Guid? LastModifierId { get; set; }
    }
}