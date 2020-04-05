using System;
using KissU.Util.Ddd.Datas.Persistence;
using KissU.Util.Ddd.Domains;
using KissU.Util.Ddd.Domains.Auditing;

namespace KissU.Modules.GreatWall.Data.Pos
{
    /// <summary>
    /// 应用程序持久化对象
    /// </summary>
    public class ApplicationPo : PersistentObjectBase<Guid>, IDelete, IAudited
    {
        /// <summary>
        /// 应用程序编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 应用程序名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 启用注册
        /// </summary>
        public bool RegisterEnabled { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 扩展
        /// </summary>
        public string Extend { get; set; }

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