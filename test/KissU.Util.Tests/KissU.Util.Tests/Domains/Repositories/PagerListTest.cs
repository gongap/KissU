﻿using KissU.Util.Domains.Repositories;
using KissU.Util.Helpers;
using KissU.Util.Tests.Samples;
using Xunit;

namespace KissU.Util.Tests.Domains.Repositories
{
    /// <summary>
    /// 分页集合测试
    /// </summary>
    public class PagerListTest
    {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public PagerListTest()
        {
            _list = new PagerList<AggregateRootSample>(1, 2, 3, "Name");
            _list.Add(AggregateRootSample.CreateSample());
            _list.Add(AggregateRootSample.CreateSample2());
        }

        /// <summary>
        /// 分页集合
        /// </summary>
        private readonly PagerList<AggregateRootSample> _list;

        /// <summary>
        /// 测试转换类型
        /// </summary>
        [Fact]
        public void TestConvert()
        {
            var result = _list.Convert(t => new AggregateRootSample());
            Assert.Equal(2, result.Data.Count);
            Assert.Equal(1, result.Page);
            Assert.Equal(2, result.PageSize);
            Assert.Equal(3, result.TotalCount);
            Assert.Equal(2, result.PageCount);
            Assert.Equal("Name", result.Order);
        }

        /// <summary>
        /// 测试集合
        /// </summary>
        [Fact]
        public void TestList()
        {
            Assert.Equal(2, _list.Data.Count);
            Assert.Equal("TestName2", _list[1].Name);
        }

        /// <summary>
        /// 测试json序列化
        /// </summary>
        [Fact]
        public void TestToJson()
        {
            var list = new PagerList<Sample>();
            list.Add(new Sample());
            Assert.Contains("PageCount", Json.ToJson(list));
        }
    }
}