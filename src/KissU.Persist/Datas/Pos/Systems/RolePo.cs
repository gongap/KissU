using System;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Datas.Persistence;

namespace KissU.Data.Pos.Systems
{
    /// <summary>
    /// 角色持久化对象
    /// </summary>
    public class RolePo : TreePersistentObjectBase,IDelete,IAudited 
	{
        /// <summary>
        /// 角色编码
        /// </summary>  
        public string Code { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>  
        public string Name { get; set; }
        /// <summary>
        /// 标准化角色名称
        /// </summary>  
        public string NormalizedName { get; set; }
        /// <summary>
        /// 角色类型
        /// </summary>  
        public string Type { get; set; }
        /// <summary>
        /// 管理员
        /// </summary>  
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 备注
        /// </summary>  
        public string Comment { get; set; }
        /// <summary>
        /// 拼音简码
        /// </summary>  
        public string PinYin { get; set; }
        /// <summary>
        /// 签名
        /// </summary>  
        public string Sign { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>  
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人编号
        /// </summary>  
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>  
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人编号
        /// </summary>  
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>  
        public bool IsDeleted { get; set; }
    }
}