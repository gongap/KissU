using System;
using KissU.Util.Domains.Trees;

namespace KissU.Util.Tests.Samples
{
    /// <summary>
    /// 树形实体测试样例
    /// </summary>
    public class TreeEntitySample : TreeEntityBase<TreeEntitySample>
    {
        /// <summary>
        /// 初始化树形实体测试样例
        /// </summary>
        public TreeEntitySample() : this(Guid.Empty)
        {
        }

        /// <summary>
        /// 初始化树形实体测试样例
        /// </summary>
        /// <param name="id">标识</param>
        public TreeEntitySample(Guid id)
            : base(id, "", 0)
        {
        }

        /// <summary>
        /// 初始化树形实体测试样例
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="path">The path.</param>
        public TreeEntitySample(Guid id, string path)
            : base(id, path, 0)
        {
        }
    }
}