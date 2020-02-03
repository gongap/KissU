﻿using System;

namespace KissU.Core.CPlatform.Filters.Implementation
{
    /// <summary>
    /// 过滤器属性.
    /// Implements the <see cref="Attribute" />
    /// Implements the <see cref="IFilter" />
    /// </summary>
    /// <seealso cref="Attribute" />
    /// <seealso cref="IFilter" />
    public abstract class FilterAttribute : Attribute, IFilter
    {
        private readonly bool _filterAttribute;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterAttribute" /> class.
        /// </summary>
        protected FilterAttribute()
        {
            _filterAttribute = true;
        }

        /// <summary>
        /// 允许多重.
        /// </summary>
        public virtual bool AllowMultiple { get => _filterAttribute; }
    }
}