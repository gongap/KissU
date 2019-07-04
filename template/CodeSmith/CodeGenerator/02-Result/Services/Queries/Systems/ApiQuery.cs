using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace GreatWall.Service.Queries.Systems {
    /// <summary>
    /// Api资源查询参数
    /// </summary>
    public class ApiQuery : QueryParameter {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public Guid? ApiId { get; set; }
        
        private string _name = string.Empty;
        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name="名称")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        
        private string _displayName = string.Empty;
        /// <summary>
        /// 显示名
        /// </summary>
        [Display(Name="显示名")]
        public string DisplayName {
            get => _displayName == null ? string.Empty : _displayName.Trim();
            set => _displayName = value;
        }
        
        private string _description = string.Empty;
        /// <summary>
        /// 描述
        /// </summary>
        [Display(Name="描述")]
        public string Description {
            get => _description == null ? string.Empty : _description.Trim();
            set => _description = value;
        }
        
        private string _claimTypes = string.Empty;
        /// <summary>
        /// 声明类型
        /// </summary>
        [Display(Name="声明类型")]
        public string ClaimTypes {
            get => _claimTypes == null ? string.Empty : _claimTypes.Trim();
            set => _claimTypes = value;
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Display(Name="是否启用")]
        public bool? Enabled { get; set; }
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