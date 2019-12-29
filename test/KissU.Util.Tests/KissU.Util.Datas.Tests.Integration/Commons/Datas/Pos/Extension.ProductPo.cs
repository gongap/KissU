using KissU.Util.Datas.Tests.Integration.Commons.Domains.Models;
using KissU.Util.Helpers;
using KissU.Util.Maps;

namespace KissU.Util.Datas.Tests.Integration.Commons.Datas.Pos
{
    /// <summary>
    /// 商品持久化对象扩展
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// 转换为商品实体
        /// </summary>
        /// <param name="po">商品持久化对象</param>
        public static Product ToEntity(this ProductPo po)
        {
            if (po == null)
                return null;
            var entity = po.MapTo(new Product(po.Id));
            entity.ProductType = Json.ToObject<ProductType>(po.Extends);
            return entity;
        }

        /// <summary>
        /// 转换为商品持久化对象
        /// </summary>
        /// <param name="entity">商品实体</param>
        public static ProductPo ToPo(this Product entity)
        {
            if (entity == null)
                return null;
            var po = entity.MapTo<ProductPo>();
            po.Extends = Json.ToJson(entity.ProductType);
            return po;
        }
    }
}