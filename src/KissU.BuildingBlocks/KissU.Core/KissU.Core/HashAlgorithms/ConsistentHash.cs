using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace KissU.Core.HashAlgorithms
{
    /// <summary>
    /// 针对<see cref="T" />哈希算法实现
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class ConsistentHash<T>
    {
        private readonly IHashAlgorithm _hashAlgorithm;
        private readonly SortedDictionary<int, T> _ring = new SortedDictionary<int, T>();
        private int[] _nodeKeysInRing;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsistentHash{T}" /> class.
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        public ConsistentHash(IHashAlgorithm hashAlgorithm)
        {
            _hashAlgorithm = hashAlgorithm;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsistentHash{T}" /> class.
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <param name="virtualNodeReplicationFactor">The virtual node replication factor.</param>
        public ConsistentHash(IHashAlgorithm hashAlgorithm, int virtualNodeReplicationFactor)
            : this(hashAlgorithm)
        {
            VirtualNodeReplicationFactor = virtualNodeReplicationFactor;
        }

        /// <summary>
        /// 复制哈希节点数
        /// </summary>
        public int VirtualNodeReplicationFactor { get; } = 1000;

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="value">The value.</param>
        public void Add(T node, string value)
        {
            AddNode(node, value);
            _nodeKeysInRing = _ring.Keys.ToArray();
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="node">节点</param>
        public void Remove(string node)
        {
            RemoveNode(node);
            _nodeKeysInRing = _ring.Keys.ToArray();
        }

        /// <summary>
        /// 通过哈希算法计算出对应的节点
        /// </summary>
        /// <param name="item">值</param>
        /// <returns>返回节点</returns>
        public T GetItemNode(string item)
        {
            var hashOfItem = _hashAlgorithm.Hash(item);
            var nearestNodePosition = GetClockwiseNearestNode(_nodeKeysInRing, hashOfItem);
            return _ring[_nodeKeysInRing[nearestNodePosition]];
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="node">节点</param>
        private void AddNode(T node, string value)
        {
            for (var i = 0; i < VirtualNodeReplicationFactor; i++)
            {
                var hashOfVirtualNode = _hashAlgorithm.Hash(value.ToString(CultureInfo.InvariantCulture) + i);
                _ring[hashOfVirtualNode] = node;
            }
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="value">节点.</param>
        private void RemoveNode(string value)
        {
            for (var i = 0; i < VirtualNodeReplicationFactor; i++)
            {
                var hashOfVirtualNode = _hashAlgorithm.Hash(value + i);
                _ring.Remove(hashOfVirtualNode);
            }
        }

        /// <summary>
        /// 顺时针查找对应哈希的位置
        /// </summary>
        /// <param name="keys">键集合数</param>
        /// <param name="hashOfItem">哈希值</param>
        /// <returns>返回哈希的位置</returns>
        private int GetClockwiseNearestNode(int[] keys, int hashOfItem)
        {
            var begin = 0;
            var end = keys.Length - 1;
            if (keys[end] < hashOfItem || keys[0] > hashOfItem)
            {
                return 0;
            }

            var mid = begin;
            while (end - begin > 1)
            {
                mid = (end + begin) / 2;
                if (keys[mid] >= hashOfItem)
                {
                    end = mid;
                }
                else
                {
                    begin = mid;
                }
            }

            return end;
        }
    }
}