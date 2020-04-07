using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KissU.Util.Ddd.Domain.Trees;

namespace KissU.Modules.GreatWall.Domain.Models
{
    /// <summary>
    /// 模块
    /// </summary>
    [Description("模块")]
    public partial class Module : TreeEntityBase<Module>
    {
        /// <summary>
        /// 初始化模块
        /// </summary>
        public Module()
            : this(Guid.Empty, "", 0)
        {
        }

        /// <summary>
        /// 初始化模块
        /// </summary>
        /// <param name="id">模块标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">级数</param>
        public Module(Guid id, string path, int level)
            : base(id, path, level)
        {
        }

        /// <summary>
        /// 应用程序编号
        /// </summary>
        public Guid? ApplicationId { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        [Required(ErrorMessage = "模块名称不能为空")]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// 模块地址
        /// </summary>
        [StringLength(300)]
        public string Url { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 是否展开
        /// </summary>
        public bool? Expanded { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(500)]
        public string Remark { get; set; }

        /// <summary>
        /// 拼音简码
        /// </summary>
        [StringLength(200)]
        public string PinYin { get; set; }

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
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions()
        {
            AddDescription(t => t.Id);
            AddDescription(t => t.ApplicationId);
            AddDescription(t => t.Name);
            AddDescription(t => t.Url);
            AddDescription(t => t.Icon);
            AddDescription(t => t.Expanded);
            AddDescription(t => t.ParentId);
            AddDescription(t => t.Path);
            AddDescription(t => t.Level);
            AddDescription(t => t.Remark);
            AddDescription(t => t.PinYin);
            AddDescription(t => t.Enabled);
            AddDescription(t => t.SortId);
            AddDescription(t => t.CreationTime);
            AddDescription(t => t.CreatorId);
            AddDescription(t => t.LastModificationTime);
            AddDescription(t => t.LastModifierId);
        }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        /// <param name="other">The other.</param>
        protected override void AddChanges(Module other)
        {
            AddChange(t => t.Id, other.Id);
            AddChange(t => t.ApplicationId, other.ApplicationId);
            AddChange(t => t.Url, other.Url);
            AddChange(t => t.Name, other.Name);
            AddChange(t => t.ParentId, other.ParentId);
            AddChange(t => t.Path, other.Path);
            AddChange(t => t.Level, other.Level);
            AddChange(t => t.Remark, other.Remark);
            AddChange(t => t.PinYin, other.PinYin);
            AddChange(t => t.Enabled, other.Enabled);
            AddChange(t => t.SortId, other.SortId);
            AddChange(t => t.CreationTime, other.CreationTime);
            AddChange(t => t.CreatorId, other.CreatorId);
            AddChange(t => t.LastModificationTime, other.LastModificationTime);
            AddChange(t => t.LastModifierId, other.LastModifierId);
        }
    }
}