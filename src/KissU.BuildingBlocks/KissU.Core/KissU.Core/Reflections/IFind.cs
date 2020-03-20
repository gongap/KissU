﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace KissU.Util.Reflections
{
    /// <summary>
    /// 类型查找器
    /// </summary>
    public interface IFind
    {
        /// <summary>
        /// 获取程序集列表
        /// </summary>
        /// <returns>List&lt;Assembly&gt;.</returns>
        List<Assembly> GetAssemblies();

        /// <summary>
        /// 查找类型列表
        /// </summary>
        /// <typeparam name="T">查找类型</typeparam>
        /// <param name="assemblies">在指定的程序集列表中查找</param>
        /// <returns>List&lt;Type&gt;.</returns>
        List<Type> Find<T>(List<Assembly> assemblies = null);

        /// <summary>
        /// 查找类型列表
        /// </summary>
        /// <param name="findType">查找类型</param>
        /// <param name="assemblies">在指定的程序集列表中查找</param>
        /// <returns>List&lt;Type&gt;.</returns>
        List<Type> Find(Type findType, List<Assembly> assemblies = null);
    }
}