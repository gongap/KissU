using KissU.Util.Ddd.Domain.Datas.Queries;
using KissU.Util.Ddd.Domain.Datas.Queries.Criterias;
using KissU.Util.Tests.Samples;
using Xunit;

namespace KissU.Util.Tests.Datas.Queries.Criterias
{
    /// <summary>
    /// 测试double范围过滤条件
    /// </summary>
    public class DecimalSegmentCriteriaTest
    {
        /// <summary>
        /// 测试获取查询条件
        /// </summary>
        [Fact]
        public void TestGetPredicate()
        {
            var criteria = new DecimalSegmentCriteria<AggregateRootSample, decimal>(t => t.DecimalValue, 1.1M, 10.1M);
            Assert.Equal("t => ((t.DecimalValue >= 1.1) AndAlso (t.DecimalValue <= 10.1))",
                criteria.GetPredicate().ToString());

            var criteria2 =
                new DecimalSegmentCriteria<AggregateRootSample, decimal?>(t => t.NullableDecimalValue, 1.1M, 10.1M);
            Assert.Equal("t => ((t.NullableDecimalValue >= 1.1) AndAlso (t.NullableDecimalValue <= 10.1))",
                criteria2.GetPredicate().ToString());
        }

        /// <summary>
        /// 测试获取查询条件 - 设置边界
        /// </summary>
        [Fact]
        public void TestGetPredicate_Boundary()
        {
            var criteria =
                new DecimalSegmentCriteria<AggregateRootSample, decimal>(t => t.DecimalValue, 1.1M, 10.1M,
                    Boundary.Neither);
            Assert.Equal("t => ((t.DecimalValue > 1.1) AndAlso (t.DecimalValue < 10.1))",
                criteria.GetPredicate().ToString());

            criteria = new DecimalSegmentCriteria<AggregateRootSample, decimal>(t => t.DecimalValue, 1.1M, 10.1M,
                Boundary.Left);
            Assert.Equal("t => ((t.DecimalValue >= 1.1) AndAlso (t.DecimalValue < 10.1))",
                criteria.GetPredicate().ToString());

            var criteria2 =
                new DecimalSegmentCriteria<AggregateRootSample, decimal?>(t => t.NullableDecimalValue, 1.1M, 10.1M,
                    Boundary.Right);
            Assert.Equal("t => ((t.NullableDecimalValue > 1.1) AndAlso (t.NullableDecimalValue <= 10.1))",
                criteria2.GetPredicate().ToString());

            criteria2 = new DecimalSegmentCriteria<AggregateRootSample, decimal?>(t => t.NullableDecimalValue, 1.1M,
                10.1M);
            Assert.Equal("t => ((t.NullableDecimalValue >= 1.1) AndAlso (t.NullableDecimalValue <= 10.1))",
                criteria2.GetPredicate().ToString());
        }
    }
}