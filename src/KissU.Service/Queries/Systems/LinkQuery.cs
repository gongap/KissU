using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace KissU.Service.Queries.Systems {
    /// <summary>
    /// 链接查询参数
    /// </summary>
    public class LinkQuery : QueryParameter {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public Guid? LinkId { get; set; }
        
        private string _code = string.Empty;
        /// <summary>
        /// 编码
        /// </summary>
        [Display(Name="编码")]
        public string Code {
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }
        
        private string _title = string.Empty;
        /// <summary>
        /// 标题
        /// </summary>
        [Display(Name="标题")]
        public string Title {
            get => _title == null ? string.Empty : _title.Trim();
            set => _title = value;
        }
        
        private string _address = string.Empty;
        /// <summary>
        /// 地址
        /// </summary>
        [Display(Name="地址")]
        public string Address {
            get => _address == null ? string.Empty : _address.Trim();
            set => _address = value;
        }
        
        private string _image = string.Empty;
        /// <summary>
        /// 图片
        /// </summary>
        [Display(Name="图片")]
        public string Image {
            get => _image == null ? string.Empty : _image.Trim();
            set => _image = value;
        }
        
        private string _comment = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name="备注")]
        public string Comment {
            get => _comment == null ? string.Empty : _comment.Trim();
            set => _comment = value;
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Display(Name="是否启用")]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name="状态")]
        public int? Status { get; set; }
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