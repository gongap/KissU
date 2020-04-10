using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Util.Tests.Samples;
using NSubstitute;
using Xunit;

namespace KissU.Util.Tests.Applications
{
    /// <summary>
    /// 查询服务测试
    /// </summary>
    public class QueryServiceTest
    {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public QueryServiceTest()
        {
            _id = Guid.NewGuid();
            _id2 = Guid.NewGuid();
            _entity = new EntitySample(_id) {Name = "A"};
            _entity2 = new EntitySample(_id2) {Name = "B"};
            _repository = Substitute.For<IRepositorySample>();
            _service = new QueryServiceSample(_repository);
        }

        /// <summary>
        /// Id
        /// </summary>
        private readonly Guid _id;

        /// <summary>
        /// Id2
        /// </summary>
        private readonly Guid _id2;

        /// <summary>
        /// 实体
        /// </summary>
        private readonly EntitySample _entity;

        /// <summary>
        /// 实体2
        /// </summary>
        private readonly EntitySample _entity2;

        /// <summary>
        /// 查询服务
        /// </summary>
        private readonly QueryServiceSample _service;

        /// <summary>
        /// 仓储
        /// </summary>
        private readonly IRepositorySample _repository;

        /// <summary>
        /// 获取实体集合
        /// </summary>
        private List<EntitySample> GetEntities()
        {
            return new List<EntitySample> {_entity, _entity2};
        }

        /// <summary>
        /// 测试获取全部
        /// </summary>
        [Fact]
        public void TestGetAll()
        {
            _repository.FindAll().Returns(GetEntities());
            var dtos = _service.GetAll();
            Assert.Equal(2, dtos.Count);
            Assert.Equal("A", dtos[0].Name);
            Assert.Equal("B", dtos[1].Name);
        }

        /// <summary>
        /// 测试获取全部
        /// </summary>
        [Fact]
        public async Task TestGetAllAsync()
        {
            _repository.FindAllAsync().Returns(GetEntities());
            var dtos = await _service.GetAllAsync();
            Assert.Equal(2, dtos.Count);
            Assert.Equal("A", dtos[0].Name);
            Assert.Equal("B", dtos[1].Name);
        }

        /// <summary>
        /// 测试通过标识获取
        /// </summary>
        [Fact]
        public void TestGetById()
        {
            _repository.Find(_id).Returns(_entity);
            var dto = _service.GetById(_id.ToString());
            Assert.Equal("A", dto.Name);
        }

        /// <summary>
        /// 测试通过标识获取
        /// </summary>
        [Fact]
        public async Task TestGetByIdAsync()
        {
            _repository.FindAsync(_id).Returns(_entity);
            var dto = await _service.GetByIdAsync(_id.ToString());
            Assert.Equal("A", dto.Name);
        }

        /// <summary>
        /// 测试通过标识列表获取
        /// </summary>
        [Fact]
        public void TestGetByIds()
        {
            var ids = $"{_id},{_id2}";
            _repository.FindByIds(ids).Returns(GetEntities());
            var dtos = _service.GetByIds(ids);
            Assert.Equal(2, dtos.Count);
            Assert.Equal("A", dtos[0].Name);
            Assert.Equal("B", dtos[1].Name);
        }

        /// <summary>
        /// 测试通过标识列表获取
        /// </summary>
        [Fact]
        public async Task TestGetByIdsAsync()
        {
            var ids = $"{_id},{_id2}";
            _repository.FindByIdsAsync(ids).Returns(GetEntities());
            var dtos = await _service.GetByIdsAsync(ids);
            Assert.Equal(2, dtos.Count);
            Assert.Equal("A", dtos[0].Name);
            Assert.Equal("B", dtos[1].Name);
        }

        /// <summary>
        /// 测试分页查询
        /// </summary>
        [Fact]
        public void TestPagerQuery_1()
        {
            var queryable = GetEntities().AsQueryable();
            _repository.Find().Returns(queryable);
            var parameter = new QueryParameterSample();
            parameter.Order = "Name";
            var result = _service.PagerQuery(parameter);
            Assert.Equal(2, result.TotalCount);
            Assert.Equal("A", result[0].Name);
            Assert.Equal("B", result[1].Name);
        }

        /// <summary>
        /// 测试分页查询
        /// </summary>
        [Fact]
        public void TestPagerQuery_2()
        {
            var queryable = GetEntities().AsQueryable();
            _repository.Find().Returns(queryable);
            var parameter = new QueryParameterSample();
            parameter.Name = "B";
            var result = _service.PagerQuery(parameter);
            Assert.Equal(1, result.TotalCount);
            Assert.Equal("B", result[0].Name);
        }

        /// <summary>
        /// 测试查询
        /// </summary>
        [Fact]
        public void TestQuery_1()
        {
            var queryable = GetEntities().AsQueryable();
            _repository.Find().Returns(queryable);
            var parameter = new QueryParameterSample();
            var dtos = _service.Query(parameter);
            Assert.Equal(2, dtos.Count);
            Assert.Equal("A", dtos[0].Name);
            Assert.Equal("B", dtos[1].Name);
        }

        /// <summary>
        /// 测试查询
        /// </summary>
        [Fact]
        public void TestQuery_2()
        {
            var queryable = GetEntities().AsQueryable();
            _repository.Find().Returns(queryable);
            var parameter = new QueryParameterSample();
            parameter.Name = "A";
            var dtos = _service.Query(parameter);
            Assert.Single(dtos);
            Assert.Equal("A", dtos[0].Name);
        }
    }
}