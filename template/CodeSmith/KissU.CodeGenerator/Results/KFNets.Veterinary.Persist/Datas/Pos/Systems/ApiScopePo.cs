using System;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Datas.Persistence;

namespace KFNets.Veterinary.Data.Pos.Systems{
    /// <summary>
    /// Api许可范围持久化对象
    /// </summary>
    public class ApiScopePo : PersistentObjectBase<Guid>,IDelete,IAudited{
        /// <summary>
        /// Api资源标识
        /// </summary>  
        public Guid ApiId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>  
        public string Name { get; set; }
        /// <summary>
        /// 显示名
        /// </summary>  
        public string DisplayName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>  
        public string Description { get; set; }
        /// <summary>
        /// 声明类型
        /// </summary>  
        public string ClaimTypes { get; set; }
        /// <summary>
        /// 是否必选
        /// </summary>  
        public bool Required { get; set; }
        /// <summary>
        /// 是否强调
        /// </summary>  
        public bool Emphasize { get; set; }
        /// <summary>
        /// 是否显示在发现文档中
        /// </summary>  
        public bool ShowInDiscoveryDocument { get; set; }
        /// <summary>
        /// 
        /// </summary>  
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>  
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 
        /// </summary>  
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>  
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 
        /// </summary>  
        public bool IsDeleted { get; set; }
    }
}