﻿using System;
using System.Linq.Expressions;
using KissU.Core;
using KissU.Util.Tests.Samples;
using Xunit;

namespace KissU.Util.Tests
{
    /// <summary>
    /// 扩展测试 - Lambda表达式扩展
    /// </summary>
    public partial class ExtensionTest
    {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public ExtensionTest()
        {
            _parameterExpression = Expression.Parameter(typeof(Sample), "t");
            _expression1 = _parameterExpression.Property("StringValue").Call("Contains", Expression.Constant("A"));
            _expression2 = _parameterExpression.Property("NullableDateValue")
                .Property("Value")
                .Property("Year")
                .Greater(Expression.Constant(2000));
        }

        /// <summary>
        /// 参数表达式
        /// </summary>
        private readonly ParameterExpression _parameterExpression;

        /// <summary>
        /// 表达式1
        /// </summary>
        private Expression _expression1;

        /// <summary>
        /// 表达式2
        /// </summary>
        private Expression _expression2;

        /// <summary>
        /// 测试And方法
        /// </summary>
        [Fact]
        public void TestAnd()
        {
            var andExpression = _expression1.And(_expression2).ToLambda<Func<Sample, bool>>(_parameterExpression);
            Expression<Func<Sample, bool>> expected = t =>
                t.StringValue.Contains("A") && t.NullableDateValue.Value.Year > 2000;
            Assert.Equal(expected.ToString(), andExpression.ToString());

            Expression<Func<Sample, bool>> left = t => t.StringValue == "A";
            Expression<Func<Sample, bool>> right = t => t.StringValue == "B";
            expected = t => t.StringValue == "A" && t.StringValue == "B";
            Assert.Equal(expected.ToString(), left.And(right).ToString());
        }

        /// <summary>
        /// 测试模糊匹配
        /// </summary>
        [Fact]
        public void TestContains()
        {
            _expression1 = _parameterExpression.Property("StringValue").Contains("a");
            Assert.Equal("t => t.StringValue.Contains(\"a\")",
                _expression1.ToLambda<Func<Sample, bool>>(_parameterExpression).ToString());
        }

        /// <summary>
        /// 测试尾匹配
        /// </summary>
        [Fact]
        public void TestEndsWith()
        {
            _expression1 = _parameterExpression.Property("StringValue").EndsWith("a");
            Assert.Equal("t => t.StringValue.EndsWith(\"a\")",
                _expression1.ToLambda<Func<Sample, bool>>(_parameterExpression).ToString());
        }

        /// <summary>
        /// 测试相等
        /// </summary>
        [Fact]
        public void TestEqual()
        {
            _expression1 = _parameterExpression.Property("IntValue").Equal(1);
            Assert.Equal("t => (t.IntValue == 1)",
                _expression1.ToLambda<Func<Sample, bool>>(_parameterExpression).ToString());
        }

        /// <summary>
        /// 测试大于
        /// </summary>
        [Fact]
        public void TestGreater()
        {
            _expression1 = _parameterExpression.Property("NullableIntValue").Greater(1);
            Assert.Equal("t => (t.NullableIntValue > 1)",
                _expression1.ToLambda<Func<Sample, bool>>(_parameterExpression).ToString());
        }

        /// <summary>
        /// 测试大于等于
        /// </summary>
        [Fact]
        public void TestGreaterEqual_Nullable()
        {
            _expression1 = _parameterExpression.Property("NullableIntValue").GreaterEqual(1);
            Assert.Equal("t => (t.NullableIntValue >= 1)",
                _expression1.ToLambda<Func<Sample, bool>>(_parameterExpression).ToString());
        }

        /// <summary>
        /// 测试小于
        /// </summary>
        [Fact]
        public void TestLess()
        {
            _expression1 = _parameterExpression.Property("NullableIntValue").Less(1);
            Assert.Equal("t => (t.NullableIntValue < 1)",
                _expression1.ToLambda<Func<Sample, bool>>(_parameterExpression).ToString());
        }

        /// <summary>
        /// 测试小于等于
        /// </summary>
        [Fact]
        public void TestLessEqual()
        {
            _expression1 = _parameterExpression.Property("NullableIntValue").LessEqual(1);
            Assert.Equal("t => (t.NullableIntValue <= 1)",
                _expression1.ToLambda<Func<Sample, bool>>(_parameterExpression).ToString());
        }

        /// <summary>
        /// 测试不相等
        /// </summary>
        [Fact]
        public void TestNotEqual()
        {
            _expression1 = _parameterExpression.Property("NullableIntValue").NotEqual(1);
            Assert.Equal("t => (t.NullableIntValue != 1)",
                _expression1.ToLambda<Func<Sample, bool>>(_parameterExpression).ToString());
        }

        /// <summary>
        /// 测试Or方法
        /// </summary>
        [Fact]
        public void TestOr()
        {
            var andExpression = _expression1.Or(_expression2).ToLambda<Func<Sample, bool>>(_parameterExpression);
            Expression<Func<Sample, bool>> expected = t =>
                t.StringValue.Contains("A") || t.NullableDateValue.Value.Year > 2000;
            Assert.Equal(expected.ToString(), andExpression.ToString());
        }

        /// <summary>
        /// 测试Or方法
        /// </summary>
        [Fact]
        public void TestOr_2()
        {
            Expression<Func<Sample, bool>> left = t => t.StringValue == "A";
            Expression<Func<Sample, bool>> right = t => t.StringValue == "B";
            Expression<Func<Sample, bool>> expected = t => t.StringValue == "A" || t.StringValue == "B";
            Assert.Equal(expected.ToString(), left.Or(right).ToString());
        }

        /// <summary>
        /// 测试Or方法 - 左表达式为空
        /// </summary>
        [Fact]
        public void TestOr_2_LeftIsNull()
        {
            Expression<Func<Sample, bool>> left = null;
            Expression<Func<Sample, bool>> right = t => t.StringValue == "B";
            Expression<Func<Sample, bool>> expected = t => t.StringValue == "B";
            Assert.Equal(expected.ToString(), left.Or(right).ToString());
        }

        /// <summary>
        /// 测试Or方法 - 右表达式为空
        /// </summary>
        [Fact]
        public void TestOr_2_RightIsNull()
        {
            Expression<Func<Sample, bool>> left = t => t.StringValue == "A";
            Expression<Func<Sample, bool>> right = null;
            Expression<Func<Sample, bool>> expected = t => t.StringValue == "A";
            Assert.Equal(expected.ToString(), left.Or(right).ToString());
        }

        /// <summary>
        /// 测试Or方法 - 左表达式为空
        /// </summary>
        [Fact]
        public void TestOr_LeftIsNull()
        {
            _expression1 = null;
            var andExpression = _expression1.Or(_expression2).ToLambda<Func<Sample, bool>>(_parameterExpression);
            Expression<Func<Sample, bool>> expected = t => t.NullableDateValue.Value.Year > 2000;
            Assert.Equal(expected.ToString(), andExpression.ToString());
        }

        /// <summary>
        /// 测试Or方法 - 右表达式为空
        /// </summary>
        [Fact]
        public void TestOr_RightIsNull()
        {
            _expression2 = null;
            var andExpression = _expression1.Or(_expression2).ToLambda<Func<Sample, bool>>(_parameterExpression);
            Expression<Func<Sample, bool>> expected = t => t.StringValue.Contains("A");
            Assert.Equal(expected.ToString(), andExpression.ToString());
        }

        /// <summary>
        /// 测试头匹配
        /// </summary>
        [Fact]
        public void TestStartsWith()
        {
            _expression1 = _parameterExpression.Property("StringValue").StartsWith("a");
            Assert.Equal("t => t.StringValue.StartsWith(\"a\")",
                _expression1.ToLambda<Func<Sample, bool>>(_parameterExpression).ToString());
        }

        /// <summary>
        /// 获取lambda表达式成员值
        /// </summary>
        [Fact]
        public void TestValue_LambdaExpression()
        {
            Expression<Func<Sample, bool>> expression = test => test.StringValue == "A";
            Assert.Equal("A", expression.Value());
        }
    }
}