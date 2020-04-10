﻿using System;
using System.Linq.Expressions;

namespace KissU.Util.Ddd.Domain.Datas.Queries.Criterias
{
    /// <summary>
    /// 整数范围过滤条件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    public class IntSegmentCriteria<TEntity, TProperty> : SegmentCriteriaBase<TEntity, TProperty, int>
        where TEntity : class
    {
        /// <summary>
        /// 初始化整数范围过滤条件
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public IntSegmentCriteria(Expression<Func<TEntity, TProperty>> propertyExpression, int? min, int? max,
            Boundary boundary = Boundary.Both)
            : base(propertyExpression, min, max, boundary)
        {
        }

        /// <summary>
        /// 最小值是否大于最大值
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns><c>true</c> if [is minimum greater maximum] [the specified minimum]; otherwise, <c>false</c>.</returns>
        protected override bool IsMinGreaterMax(int? min, int? max)
        {
            return min > max;
        }
    }
}