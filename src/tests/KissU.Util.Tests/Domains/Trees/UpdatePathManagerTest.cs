﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core;
using KissU.Core.Exceptions;
using KissU.Core.Properties;
using KissU.Util.Ddd.Domains.Trees;
using KissU.Util.Tests.Samples;
using KissU.Util.Tests.XUnitHelpers;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace KissU.Util.Tests.Domains.Trees
{
    /// <summary>
    /// 树形更新路径服务测试
    /// </summary>
    public class UpdatePathManagerTest
    {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public UpdatePathManagerTest()
        {
            _mockRepository = Substitute.For<IRoleRepository>();
            _manager = new UpdatePathManager<Role, Guid, Guid?>(_mockRepository);
        }

        /// <summary>
        /// 树形服务
        /// </summary>
        private readonly UpdatePathManager<Role, Guid, Guid?> _manager;

        /// <summary>
        /// 角色仓储
        /// </summary>
        private readonly IRoleRepository _mockRepository;

        /// <summary>
        /// 编号
        /// </summary>
        private readonly Guid _id = "10000001-AAF2-4D03-9310-FEF2F47B9FE2".ToGuid();

        /// <summary>
        /// 编号2
        /// </summary>
        private readonly Guid _id2 = "10000002-AAF2-4D03-9310-FEF2F47B9FE2".ToGuid();

        /// <summary>
        /// 编号3
        /// </summary>
        private readonly Guid _id3 = "10000003-AAF2-4D03-9310-FEF2F47B9FE2".ToGuid();

        /// <summary>
        /// 编号4
        /// </summary>
        private readonly Guid _id4 = "10000004-AAF2-4D03-9310-FEF2F47B9FE2".ToGuid();

        /// <summary>
        /// 编号5
        /// </summary>
        private readonly Guid _id5 = "10000005-AAF2-4D03-9310-FEF2F47B9FE2".ToGuid();

        /// <summary>
        /// 修改父节点 - 数据库中未找到 - Path无变化
        /// </summary>
        [Fact]
        public async Task TestUpdatePathAsync_1()
        {
            //设置
            var path = $"{_id},";
            _mockRepository.FindAsync(_id).ReturnsNull();

            //执行
            var role = new Role(_id, path, 0) {ParentId = _id2};
            await _manager.UpdatePathAsync(role);

            //验证
            await _mockRepository.DidNotReceive().GetAllChildrenAsync(role);
            Assert.Equal(path, role.Path);
        }

        /// <summary>
        /// 修改父节点 - 父节点未修改 - Path无变化
        /// </summary>
        [Fact]
        public async Task TestUpdatePathAsync_2()
        {
            //设置
            var path = $"{_id2},{_id},";
            _mockRepository.FindAsync(_id).Returns(new Role(_id, path, 2) {ParentId = _id2});

            //执行
            var role = new Role(_id, path, 2) {ParentId = _id2};
            await _manager.UpdatePathAsync(role);

            //验证
            await _mockRepository.DidNotReceive().GetAllChildrenAsync(role);
            Assert.Equal(path, role.Path);
        }

        /// <summary>
        /// 修改父节点 - 父节点已修改 - 无下级子节点
        /// </summary>
        [Fact]
        public async Task TestUpdatePathAsync_3()
        {
            //设置
            var path = $"{_id2},{_id},";
            var old = new Role(_id, path, 2) {ParentId = _id2};
            _mockRepository.FindByIdNoTrackingAsync(_id).Returns(old);
            _mockRepository.FindAsync(_id3).Returns(new Role(_id3, $"{_id3},", 1));
            var list = new List<Role>();
            _mockRepository.GetAllChildrenAsync(old).Returns(list);

            //执行
            var role = new Role(_id, path, 2) {ParentId = _id3};
            await _manager.UpdatePathAsync(role);

            //验证
            Assert.Equal($"{_id3},{_id},", role.Path);
            Assert.Equal(2, role.Level);
        }

        /// <summary>
        /// 修改父节点 - 父节点已修改 - 下级1个子节点
        /// </summary>
        [Fact]
        public async Task TestUpdatePathAsync_4()
        {
            //设置
            var path = $"{_id2},{_id},";
            var old = new Role(_id, path, 2) {ParentId = _id2};
            var child = new Role(_id4, $"{path},{_id4}", 3) {ParentId = _id};
            _mockRepository.FindByIdNoTrackingAsync(_id).Returns(old);
            _mockRepository.FindAsync(_id3).Returns(new Role(_id3, $"{_id3},", 1));
            var list = new List<Role> {child};
            _mockRepository.GetAllChildrenAsync(old).Returns(list);

            //执行
            var role = new Role(_id, path, 2) {ParentId = _id3};
            await _manager.UpdatePathAsync(role);

            //验证
            Assert.Equal($"{_id3},{_id},", role.Path);
            Assert.Equal($"{_id3},{_id},{_id4},", list[0].Path);
        }

        /// <summary>
        /// 修改父节点 - 父节点已修改 - 直接下级2个子节点
        /// </summary>
        [Fact]
        public async Task TestUpdatePathAsync_5()
        {
            //设置
            var path = $"{_id2},{_id},";
            var old = new Role(_id, path, 2) {ParentId = _id2};
            var child1 = new Role(_id4, $"{path},{_id4}", 3) {ParentId = _id};
            var child2 = new Role(_id5, $"{path},{_id5}", 3) {ParentId = _id};
            _mockRepository.FindByIdNoTrackingAsync(_id).Returns(old);
            _mockRepository.FindAsync(_id3).Returns(new Role(_id3, $"{_id3},", 1));
            var list = new List<Role> {child1, child2};
            _mockRepository.GetAllChildrenAsync(old).Returns(list);

            //执行
            var role = new Role(_id, path, 2) {ParentId = _id3};
            await _manager.UpdatePathAsync(role);

            //验证
            Assert.Equal($"{_id3},{_id},", role.Path);
            Assert.Equal($"{_id3},{_id},{_id4},", list[0].Path);
            Assert.Equal($"{_id3},{_id},{_id5},", list[1].Path);
        }

        /// <summary>
        /// 修改父节点 - 父节点已修改 - 下级2层子节点
        /// </summary>
        [Fact]
        public async Task TestUpdatePathAsync_6()
        {
            //设置
            var path = $"{_id2},{_id},";
            var old = new Role(_id, path, 2) {ParentId = _id2};
            var child1 = new Role(_id4, $"{path},{_id4}", 3) {ParentId = _id};
            var child2 = new Role(_id5, $"{path},{_id4},{_id5}", 4) {ParentId = _id4};
            _mockRepository.FindByIdNoTrackingAsync(_id).Returns(old);
            _mockRepository.FindAsync(_id3).Returns(new Role(_id3, $"{_id3},", 1));
            var list = new List<Role> {child1, child2};
            _mockRepository.GetAllChildrenAsync(old).Returns(list);

            //执行
            var role = new Role(_id, path, 2) {ParentId = _id3};
            await _manager.UpdatePathAsync(role);

            //验证
            Assert.Equal($"{_id3},{_id},", role.Path);
            Assert.Equal($"{_id3},{_id},{_id4},", list[0].Path);
            Assert.Equal($"{_id3},{_id},{_id4},{_id5},", list[1].Path);
        }

        /// <summary>
        /// 修改父节点 - 将父节点移动到子节点下
        /// </summary>
        [Fact]
        public async Task TestUpdatePathAsync_7()
        {
            //设置
            var path = $"{_id},";
            var old = new Role(_id, path, 1);
            var child = new Role(_id2, $"{_id},{_id2},", 2) {ParentId = _id};
            _mockRepository.FindByIdNoTrackingAsync(_id).Returns(old);
            var list = new List<Role> {child};
            _mockRepository.GetAllChildrenAsync(old).Returns(list);

            //执行验证
            await AssertHelper.ThrowsAsync<Warning>(async () =>
            {
                var result = new Role(_id, path, 1) {ParentId = _id2};
                await _manager.UpdatePathAsync(result);
            }, LibraryResource.NotSupportMoveToChildren);
        }

        /// <summary>
        /// 修改父节点 - 将父节点设置为自己
        /// </summary>
        [Fact]
        public async Task TestUpdatePathAsync_8()
        {
            //设置
            var path = $"{_id},";
            var old = new Role(_id, path, 1);
            var child = new Role(_id2, $"{_id},{_id2},", 2) {ParentId = _id};
            _mockRepository.FindByIdNoTrackingAsync(_id).Returns(old);
            var list = new List<Role> {child};
            _mockRepository.GetAllChildrenAsync(old).Returns(list);

            //执行验证
            await AssertHelper.ThrowsAsync<Warning>(async () =>
            {
                var result = new Role(_id, path, 1) {ParentId = _id};
                await _manager.UpdatePathAsync(result);
            }, LibraryResource.NotSupportMoveToChildren);
        }
    }
}