﻿using KissU.Core.Datas.Queries;
using KissU.Util.Ddd.Domain.Datas.Sql.Builders.Conditions;
using KissU.Util.Ddd.Domain.Datas.Sql.Builders.Core;
using Xunit;

namespace KissU.Util.Datas.Tests.Integration.Sql.Builders.Base
{
    /// <summary>
    /// 表连接项测试
    /// </summary>
    public class JoinItemTest
    {
        /// <summary>
        /// 测试复制
        /// </summary>
        [Fact]
        public void Test_1()
        {
            var item = new JoinItem("join", "b");
            item.On(SqlConditionFactory.Create("a.A", "b.B", Operator.Equal));

            //复制一份
            var copy = item.Clone(null);
            Assert.Equal("join b On a.A=b.B", item.ToSql());
            Assert.Equal("join b On a.A=b.B", copy.ToSql());

            //修改副本
            copy.On(SqlConditionFactory.Create("a.C", "b.D", Operator.Equal));
            Assert.Equal("join b On a.A=b.B", item.ToSql());
            Assert.Equal("join b On a.A=b.B And a.C=b.D", copy.ToSql());
        }
    }
}