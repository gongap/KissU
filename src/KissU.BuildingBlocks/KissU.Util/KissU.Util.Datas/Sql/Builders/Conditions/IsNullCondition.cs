﻿using KissU.Util.Ddd.Domain.Datas.Sql.Builders;

namespace KissU.Util.Datas.Sql.Builders.Conditions
{
    /// <summary>
    /// Is Null查询条件
    /// </summary>
    public class IsNullCondition : ICondition
    {
        /// <summary>
        /// 列名
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// 初始化Is Null查询条件
        /// </summary>
        /// <param name="name">列名</param>
        public IsNullCondition(string name)
        {
            _name = name;
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetCondition()
        {
            return string.IsNullOrWhiteSpace(_name) ? null : $"{_name} Is Null";
        }
    }
}