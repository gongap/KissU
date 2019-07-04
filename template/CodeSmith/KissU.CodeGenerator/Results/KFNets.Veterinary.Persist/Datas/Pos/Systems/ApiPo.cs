using System;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Datas.Persistence;

namespace KFNets.Veterinary.Data.Pos.Systems{
    /// <summary>
    /// Api资源持久化对象
    /// </summary>
    public class ApiPo : PersistentObjectBase<Guid>,IDelete,IAudited{
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
        /// 是否启用
        /// </summary>  
        public bool Enabled { get; set; }
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