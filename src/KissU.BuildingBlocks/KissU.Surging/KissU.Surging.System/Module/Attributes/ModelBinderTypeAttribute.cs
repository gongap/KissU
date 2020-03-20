﻿using System;
using System.Collections.Generic;

namespace KissU.Surging.System.Module.Attributes
{
    /// <summary>
    /// ModelBinderTypeAttribute 自定义特性类
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class ModelBinderTypeAttribute : Attribute
    {
        /// <summary>
        /// 初始化一个新的 <see cref="ModelBinderTypeAttribute" /> 类实例。
        /// </summary>
        /// <param name="targetTypes">目标类型列表</param>
        /// <exception cref="ArgumentNullException">targetTypes</exception>
        public ModelBinderTypeAttribute(params Type[] targetTypes)
        {
            if (targetTypes == null) throw new ArgumentNullException("targetTypes");
            TargetTypes = targetTypes;
        }

        /// <summary>
        /// 初始化一个新的 <see cref="ModelBinderTypeAttribute" /> 类实例。
        /// </summary>
        /// <param name="targetType">目标类型</param>
        /// <exception cref="ArgumentNullException">targetType</exception>
        public ModelBinderTypeAttribute(Type targetType)
        {
            if (targetType == null) throw new ArgumentNullException("targetType");
            TargetTypes = new[] {targetType};
        }

        /// <summary>
        /// 目标类型
        /// </summary>
        public IEnumerable<Type> TargetTypes { get; }
    }
}