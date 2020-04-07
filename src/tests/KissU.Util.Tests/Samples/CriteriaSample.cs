using System;
using System.Linq.Expressions;
using KissU.Util.Ddd.Data.Repositories;

namespace KissU.Util.Tests.Samples
{
    /// <summary>
    /// 查询条件对象样例
    /// </summary>
    public class CriteriaSample : ICriteria<AggregateRootSample>
    {
        /// <summary>
        /// 获取查询条件,返回结果："t =&gt; ((t.Name == \"A\") AndAlso (t.Tel == 1))"
        /// </summary>
        /// <returns>Expression&lt;Func&lt;AggregateRootSample, System.Boolean&gt;&gt;.</returns>
        public Expression<Func<AggregateRootSample, bool>> GetPredicate()
        {
            return t => t.Name == "A" && t.Tel == 1;
        }
    }
}