using System;
using KissU.Core;
using KissU.Core.Helpers;
using Xunit;

namespace KissU.Util.Tests
{
    /// <summary>
    /// 系统扩展测试 - 日期格式扩展
    /// </summary>
    public partial class ExtensionTest
    {
        /// <summary>
        /// 测试获取时间间隔描述
        /// </summary>
        [Fact]
        public void TestDescription_Span()
        {
            var span = new DateTime(2000, 1, 1, 1, 0, 1) - new DateTime(2000, 1, 1, 1, 0, 0);
            Assert.Equal("1秒", span.Description());
            span = new DateTime(2000, 1, 1, 1, 1, 0) - new DateTime(2000, 1, 1, 1, 0, 0);
            Assert.Equal("1分", span.Description());
            span = new DateTime(2000, 1, 1, 1, 0, 0) - new DateTime(2000, 1, 1, 0, 0, 0);
            Assert.Equal("1小时", span.Description());
            span = new DateTime(2000, 1, 2, 0, 0, 0) - new DateTime(2000, 1, 1, 0, 0, 0);
            Assert.Equal("1天", span.Description());
            span = new DateTime(2000, 1, 2, 0, 2, 0) - new DateTime(2000, 1, 1, 0, 0, 0);
            Assert.Equal("1天2分", span.Description());
            span = "2000-1-1 06:10:10.123".ToDate() - "2000-1-1 06:10:10.122".ToDate();
            Assert.Equal("1毫秒", span.Description());
            span = "2000-1-1 06:10:10.1000001".ToDate() - "2000-1-1 06:10:10.1000000".ToDate();
            Assert.Equal("0.0001毫秒", span.Description());
        }

        /// <summary>
        /// 获取格式化中文日期字符串
        /// </summary>
        [Fact]
        public void TestToChineseDateString()
        {
            var date = "2012-01-02";
            Assert.Equal("2012年1月2日", TypeConvert.ToDate(date).ToChineseDateString());
            Assert.Equal("2012年12月12日", TypeConvert.ToDate("2012-12-12").ToChineseDateString());
            Assert.Equal("", TypeConvert.ToDateOrNull("").ToChineseDateString());
            Assert.Equal("2012年1月2日", TypeConvert.ToDateOrNull(date).ToChineseDateString());
        }

        /// <summary>
        /// 获取格式化中文日期时间字符串
        /// </summary>
        [Fact]
        public void TestToChineseDateTimeString()
        {
            var date = "2012-01-02 11:11:11";
            Assert.Equal("2012年1月2日 11时11分11秒", TypeConvert.ToDate(date).ToChineseDateTimeString());
            Assert.Equal("2012年12月12日 11时11分11秒", TypeConvert.ToDate("2012-12-12 11:11:11").ToChineseDateTimeString());
            Assert.Equal("2012年1月2日 11时11分", TypeConvert.ToDate(date).ToChineseDateTimeString(true));
            Assert.Equal("", TypeConvert.ToDateOrNull("").ToChineseDateTimeString());
            Assert.Equal("2012年1月2日 11时11分11秒", TypeConvert.ToDateOrNull(date).ToChineseDateTimeString());
            Assert.Equal("2012年1月2日 11时11分", TypeConvert.ToDateOrNull(date).ToChineseDateTimeString(true));
        }

        /// <summary>
        /// 获取格式化日期字符串
        /// </summary>
        [Fact]
        public void TestToDateString()
        {
            var date = "2012-01-02";
            Assert.Equal(date, TypeConvert.ToDate(date).ToDateString());
            Assert.Equal("", TypeConvert.ToDateOrNull("").ToDateString());
            Assert.Equal(date, TypeConvert.ToDateOrNull(date).ToDateString());
        }

        /// <summary>
        /// 测试获取格式化日期时间字符串
        /// </summary>
        [Fact]
        public void TestToDateTimeString()
        {
            var date = "2012-01-02 11:11:11";
            Assert.Equal(date, TypeConvert.ToDate(date).ToDateTimeString());
            Assert.Equal("2012-01-02 11:11", TypeConvert.ToDate(date).ToDateTimeString(true));
            Assert.Equal("", TypeConvert.ToDateOrNull("").ToDateTimeString());
            Assert.Equal(date, TypeConvert.ToDateOrNull(date).ToDateTimeString());
        }

        /// <summary>
        /// 获取格式化毫秒字符串
        /// </summary>
        [Fact]
        public void TestToMillisecondString()
        {
            var date = "2012-01-02 11:11:11.123";
            Assert.Equal(date, TypeConvert.ToDate(date).ToMillisecondString());
            Assert.Equal("", TypeConvert.ToDateOrNull("").ToMillisecondString());
            Assert.Equal(date, TypeConvert.ToDateOrNull(date).ToMillisecondString());
        }

        /// <summary>
        /// 获取格式化时间字符串
        /// </summary>
        [Fact]
        public void TestToTimeString()
        {
            var date = "2012-01-02 11:11:11";
            Assert.Equal("11:11:11", TypeConvert.ToDate(date).ToTimeString());
            Assert.Equal("", TypeConvert.ToDateOrNull("").ToTimeString());
            Assert.Equal("11:11:11", TypeConvert.ToDateOrNull(date).ToTimeString());
        }
    }
}