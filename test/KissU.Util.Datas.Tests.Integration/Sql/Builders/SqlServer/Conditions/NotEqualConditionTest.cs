﻿using KissU.Util.Datas.Sql.Builders.Conditions;
using Xunit;

namespace KissU.Util.Datas.Tests.Integration.Sql.Builders.SqlServer.Conditions {
    /// <summary>
    /// Sql不相等查询条件测试
    /// </summary>
    public class NotEqualConditionTest {
        /// <summary>
        /// 获取条件
        /// </summary>
        [Fact]
        public void Test() {
            var condition = new NotEqualCondition( "Name", "@Name" );
            Assert.Equal( "Name<>@Name", condition.GetCondition() );
        }
    }
}