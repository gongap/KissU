using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Core;
using KissU.Util.Ddd.Domain.Datas.Repositories;
using KissU.Util.Ddd.Domain.Datas.Trees;
using KissU.Util.Ddd.Domain.Trees;

namespace KissU.Util.Ddd.Domain.Datas
{
    /// <summary>
    /// 树形扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 更新实体及所有下级节点路径
        /// </summary>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <typeparam name="TParentId">The type of the t parent identifier.</typeparam>
        /// <param name="repository">仓储</param>
        /// <param name="entity">实体</param>
        public static async Task UpdatePathAsync<TEntity, TKey, TParentId>(
            this ITreeCompactRepository<TEntity, TKey, TParentId> repository, TEntity entity)
            where TEntity : class, ITreeEntity<TEntity, TKey, TParentId>
        {
            var manager = new UpdatePathManager<TEntity, TKey, TParentId>(repository);
            await manager.UpdatePathAsync(entity);
        }

        /// <summary>
        /// 交换排序
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="swapEntity">交换实体</param>
        public static void SwapSort(this ISortId entity, ISortId swapEntity)
        {
            var sortId = entity.SortId;
            entity.SortId = swapEntity.SortId;
            swapEntity.SortId = sortId;
        }

        /// <summary>
        /// 获取缺失的父标识列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">标识类型</typeparam>
        /// <typeparam name="TParentId">父标识类型</typeparam>
        /// <param name="entities">实体列表</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> GetMissingParentIds<TEntity, TKey, TParentId>(this IEnumerable<TEntity> entities)
            where TEntity : class, ITreeEntity<TEntity, TKey, TParentId>
        {
            var result = new List<string>();
            if (entities == null)
                return result;
            var list = entities.ToList();
            list.ForEach(entity =>
            {
                if (entity == null)
                    return;
                result.AddRange(entity.GetParentIdsFromPath().Select(t => t.SafeString()));
            });
            var ids = list.Select(t => t?.Id.SafeString());
            return result.Except(ids).ToList();
        }
    }
}