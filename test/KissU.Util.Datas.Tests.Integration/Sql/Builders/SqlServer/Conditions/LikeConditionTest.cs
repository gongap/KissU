﻿using KissU.Util.Datas.Sql.Builders.Conditions;
using Xunit;

namespace KissU.Util.Datas.Tests.Integration.Sql.Builders.SqlServer.Conditions {
    /// <summary>
    /// Sql模糊查询条件测试
    /// </summary>
    public class LikeConditionTest {
        /// <summary>
        /// 获取条件
        /// </summary>
        [Fact]
        public void Test() {
            var condition = new LikeCondition( "Name", "@Name" );
            Assert.Equal( "Name Like @Name", condition.GetCondition() );
        }
    }
}