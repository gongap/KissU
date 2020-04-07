﻿using System;

namespace KissU.Util.Ddd.Data.Sql.Matedatas
{
    /// <summary>
    /// 实体元数据
    /// </summary>
    public class DefaultEntityMatedata : IEntityMatedata
    {
        /// <summary>
        /// 获取表名
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <returns>System.String.</returns>
        public string GetTable(Type type)
        {
            return type?.Name;
        }

        /// <summary>
        /// 获取架构
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <returns>System.String.</returns>
        public string GetSchema(Type type)
        {
            return string.Empty;
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <param name="property">属性名</param>
        /// <returns>System.String.</returns>
        public string GetColumn(Type type, string property)
        {
            return property;
        }
    }
}