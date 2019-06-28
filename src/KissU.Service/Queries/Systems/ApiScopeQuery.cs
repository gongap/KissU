using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace KissU.Service.Queries.Systems {
    /// <summary>
    /// Api许可范围查询参数
    /// </summary>
    public class ApiScopeQuery : QueryParameter {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name="")]
        public Guid? ApiScopeId { get; set; }
        /// <summary>
        /// Api资源标识
        /// </summary>
        [Display(Name="Api资源标识")]
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
        /// 是否必选
        /// </summary>
        [Display(Name="是否必选")]
        public bool? Required { get; set; }
        /// <summary>
        /// 是否强调
        /// </summary>
        [Display(Name="是否强调")]
        public bool? Emphasize { get; set; }
        /// <summary>
        /// 是否显示在发现文档中
        /// </summary>
        [Display(Name="是否显示在发现文档中")]
        public bool? ShowInDiscoveryDocument { get; set; }
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