using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries.Trees;

namespace KissU.Service.Queries.Systems {
    /// <summary>
    /// 角色查询参数
    /// </summary>
    public class RoleQuery : TreeQueryParameter {
        /// <summary>
        /// 角色编号
        /// </summary>
        [Display(Name="角色编号")]
        public Guid? RoleId { get; set; }
        
        private string _code = string.Empty;
        /// <summary>
        /// 角色编码
        /// </summary>
        [Display(Name="角色编码")]
        public string Code {
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }
        
        private string _name = string.Empty;
        /// <summary>
        /// 角色名称
        /// </summary>
        [Display(Name="角色名称")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        
        private string _normalizedName = string.Empty;
        /// <summary>
        /// 标准化角色名称
        /// </summary>
        [Display(Name="标准化角色名称")]
        public string NormalizedName {
            get => _normalizedName == null ? string.Empty : _normalizedName.Trim();
            set => _normalizedName = value;
        }
        
        private string _type = string.Empty;
        /// <summary>
        /// 角色类型
        /// </summary>
        [Display(Name="角色类型")]
        public string Type {
            get => _type == null ? string.Empty : _type.Trim();
            set => _type = value;
        }
        /// <summary>
        /// 管理员
        /// </summary>
        [Display(Name="管理员")]
        public bool? IsAdmin { get; set; }
        
        private string _comment = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name="备注")]
        public string Comment {
            get => _comment == null ? string.Empty : _comment.Trim();
            set => _comment = value;
        }
        
        private string _pinYin = string.Empty;
        /// <summary>
        /// 拼音简码
        /// </summary>
        [Display(Name="拼音简码")]
        public string PinYin {
            get => _pinYin == null ? string.Empty : _pinYin.Trim();
            set => _pinYin = value;
        }
        
        private string _sign = string.Empty;
        /// <summary>
        /// 签名
        /// </summary>
        [Display(Name="签名")]
        public string Sign {
            get => _sign == null ? string.Empty : _sign.Trim();
            set => _sign = value;
        }
        /// <summary>
        /// 起始创建时间
        /// </summary>
        [Display( Name = "起始创建时间" )]
        public DateTime? BeginCreationTime { get; set; }
        /// <summary>
        /// 结束创建时间
        /// </summary>
        [Display( Name = "结束创建时间" )]
        public DateTime? EndCreationTime { get; set; }        
        /// <summary>
        /// 创建人编号
        /// </summary>
        [Display(Name="创建人编号")]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 起始最后修改时间
        /// </summary>
        [Display( Name = "起始最后修改时间" )]
        public DateTime? BeginLastModificationTime { get; set; }
        /// <summary>
        /// 结束最后修改时间
        /// </summary>
        [Display( Name = "结束最后修改时间" )]
        public DateTime? EndLastModificationTime { get; set; }        
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        [Display(Name="最后修改人编号")]
        public Guid? LastModifierId { get; set; }
    }
}