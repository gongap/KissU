using System;
using System.Linq.Expressions;
using System.Reflection;

namespace KissU.Core.ProxyGenerator.FastReflection
{
    /// <summary>
    /// Interface IPropertyAccessor
    /// </summary>
    public interface IPropertyAccessor
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>System.Object.</returns>
        object GetValue(object instance);

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value.</param>
        void SetValue(object instance, object value);
    }

    /// <summary>
    /// PropertyAccessor.
    /// Implements the <see cref="KissU.Core.ProxyGenerator.FastReflection.IPropertyAccessor" />
    /// </summary>
    /// <seealso cref="KissU.Core.ProxyGenerator.FastReflection.IPropertyAccessor" />
    public class PropertyAccessor : IPropertyAccessor
    {
        private Func<object, object> m_getter;
        private MethodInvoker m_setMethodInvoker;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyAccessor" /> class.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        public PropertyAccessor(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
            InitializeGet(propertyInfo);
            InitializeSet(propertyInfo);
        }

        /// <summary>
        /// Gets the property information.
        /// </summary>
        public PropertyInfo PropertyInfo { get; }

        private void InitializeGet(PropertyInfo propertyInfo)
        {
            if (!propertyInfo.CanRead) return;

            // Target: (object)(((TInstance)instance).Property)

            // preparing parameter, object type
            var instance = Expression.Parameter(typeof(object), "instance");

            // non-instance for static method, or ((TInstance)instance)
            var instanceCast = propertyInfo.GetGetMethod(true).IsStatic
                ? null
                : Expression.Convert(instance, propertyInfo.ReflectedType);

            // ((TInstance)instance).Property
            var propertyAccess = Expression.Property(instanceCast, propertyInfo);

            // (object)(((TInstance)instance).Property)
            var castPropertyValue = Expression.Convert(propertyAccess, typeof(object));

            // Lambda expression
            var lambda = Expression.Lambda<Func<object, object>>(castPropertyValue, instance);

            m_getter = lambda.Compile();
        }

        private void InitializeSet(PropertyInfo propertyInfo)
        {
            if (!propertyInfo.CanWrite) return;
            m_setMethodInvoker = new MethodInvoker(propertyInfo.GetSetMethod(true));
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="NotSupportedException">Get method is not defined for this property.</exception>
        public object GetValue(object o)
        {
            if (m_getter == null)
            {
                throw new NotSupportedException("Get method is not defined for this property.");
            }

            return m_getter(o);
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="NotSupportedException">Set method is not defined for this property.</exception>
        public void SetValue(object o, object value)
        {
            if (m_setMethodInvoker == null)
            {
                throw new NotSupportedException("Set method is not defined for this property.");
            }

            m_setMethodInvoker.Invoke(o, value);
        }

        #region IPropertyAccessor Members

        object IPropertyAccessor.GetValue(object instance)
        {
            return GetValue(instance);
        }

        void IPropertyAccessor.SetValue(object instance, object value)
        {
            SetValue(instance, value);
        }

        #endregion
    }
}