﻿using System;
using System.ComponentModel.DataAnnotations;
using Util.Datas.Queries.Trees;

namespace GreatWall.Service.Queries {
    /// <summary>
    /// 资源查询参数
    /// </summary>
    public class ResourceQuery : TreeQueryParameter {
        /// <summary>
        /// 标识
        /// </summary>
        public Guid? ResourceId { get; set; }

        /// <summary>
        /// 应用程序标识
        /// </summary>
        public Guid? ApplicationId { get; set; }

        /// <summary>
        /// 角色标识
        /// </summary>
        public Guid? RoleId { get; set; }

        private string _uri = string.Empty;
        /// <summary>
        /// 资源标识
        /// </summary>
        [Display(Name="资源标识")]
        public string Uri {
            get => _uri == null ? string.Empty : _uri.Trim();
            set => _uri = value;
        }
        
        private string _name = string.Empty;
        /// <summary>
        /// 资源名称
        /// </summary>
        [Display(Name="资源名称")]
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
    }
}