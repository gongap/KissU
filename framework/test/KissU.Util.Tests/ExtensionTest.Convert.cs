﻿using System;
using System.Collections.Generic;
using KissU.Core;
using Xunit;

namespace KissU.Util.Tests
{
    /// <summary>
    /// 扩展测试 - 类型转换
    /// </summary>
    public partial class ExtensionTest
    {
        /// <summary>
        /// 安全转换为字符串
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData(null, "")]
        [InlineData("  ", "")]
        [InlineData(1, "1")]
        [InlineData(" 1 ", "1")]
        public void TestSafeString(object input, string result)
        {
            Assert.Equal(result, input.SafeString());
        }

        /// <summary>
        /// 转换为整数
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="result">The result.</param>
        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        public void TestToInt(string input, int result)
        {
            Assert.Equal(result, input.ToInt());
        }

        /// <summary>
        /// 转换为可空整数
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="result">The result.</param>
        [Theory]
        [InlineData("", null)]
        [InlineData("1", 1)]
        public void TestToIntOrNull(string input, int? result)
        {
            Assert.Equal(result, input.ToIntOrNull());
        }

        /// <summary>
        /// 转换为双精度浮点数
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="result">The result.</param>
        [Theory]
        [InlineData("", 0)]
        [InlineData("1.2", 1.2)]
        public void TestToDouble(string input, double result)
        {
            Assert.Equal(result, input.ToDouble());
        }

        /// <summary>
        /// 转换为可空双精度浮点数
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="result">The result.</param>
        [Theory]
        [InlineData("", null)]
        [InlineData("1.2", 1.2)]
        public void TestToDoubleOrNull(string input, double? result)
        {
            Assert.Equal(result, input.ToDoubleOrNull());
        }

        /// <summary>
        /// 转换为日期
        /// </summary>
        [Fact]
        public void TestToDate()
        {
            Assert.Equal(DateTime.MinValue, "".ToDate());
            Assert.Equal(new DateTime(2000, 1, 1), "2000-1-1".ToDate());
        }

        /// <summary>
        /// 转换为可空日期
        /// </summary>
        [Fact]
        public void TestToDateOrNull()
        {
            Assert.Null("".ToDateOrNull());
            Assert.Equal(new DateTime(2000, 1, 1), "2000-1-1".ToDateOrNull());
        }

        /// <summary>
        /// 转换为高精度浮点数
        /// </summary>
        [Fact]
        public void TestToDecimal()
        {
            Assert.Equal(0, "".ToDecimal());
            Assert.Equal(1.2M, "1.2".ToDecimal());
        }

        /// <summary>
        /// 转换为可空高精度浮点数
        /// </summary>
        [Fact]
        public void TestToDecimalOrNull()
        {
            Assert.Null("".ToDecimalOrNull());
            Assert.Equal(1.2M, "1.2".ToDecimalOrNull());
        }

        /// <summary>
        /// 转换为Guid
        /// </summary>
        [Fact]
        public void TestToGuid()
        {
            Assert.Equal(Guid.Empty, "".ToGuid());
            Assert.Equal(new Guid("B9EB56E9-B720-40B4-9425-00483D311DDC"),
                "B9EB56E9-B720-40B4-9425-00483D311DDC".ToGuid());
        }

        /// <summary>
        /// 转换为Guid集合,值为字符串
        /// </summary>
        [Fact]
        public void TestToGuidList_String()
        {
            const string guid = "83B0233C-A24F-49FD-8083-1337209EBC9A,,EAB523C6-2FE7-47BE-89D5-C6D440C3033A,";
            Assert.Equal(2, guid.ToGuidList().Count);
            Assert.Equal(new Guid("83B0233C-A24F-49FD-8083-1337209EBC9A"), guid.ToGuidList()[0]);
            Assert.Equal(new Guid("EAB523C6-2FE7-47BE-89D5-C6D440C3033A"), guid.ToGuidList()[1]);
        }

        /// <summary>
        /// 转换为Guid集合,值为字符串集合
        /// </summary>
        [Fact]
        public void TestToGuidList_StringList()
        {
            var list = new List<string>
                {"83B0233C-A24F-49FD-8083-1337209EBC9A", "EAB523C6-2FE7-47BE-89D5-C6D440C3033A"};
            Assert.Equal(2, list.ToGuidList().Count);
            Assert.Equal(new Guid("83B0233C-A24F-49FD-8083-1337209EBC9A"), list.ToGuidList()[0]);
            Assert.Equal(new Guid("EAB523C6-2FE7-47BE-89D5-C6D440C3033A"), list.ToGuidList()[1]);
        }

        /// <summary>
        /// 转换为可空Guid
        /// </summary>
        [Fact]
        public void TestToGuidOrNull()
        {
            Assert.Null("".ToGuidOrNull());
            Assert.Equal(new Guid("B9EB56E9-B720-40B4-9425-00483D311DDC"),
                "B9EB56E9-B720-40B4-9425-00483D311DDC".ToGuidOrNull());
        }
    }
}