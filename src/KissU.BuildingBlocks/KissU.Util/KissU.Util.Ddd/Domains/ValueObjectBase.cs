using System;
using System.Linq;
using System.Reflection;
using Convert = KissU.Core.Helpers.Convert;

namespace KissU.Util.Ddd.Domain.Domains
{
    /// <summary>
    /// 值对象
    /// </summary>
    /// <typeparam name="TValueObject">值对象类型</typeparam>
    public abstract class ValueObjectBase<TValueObject> : DomainBase<TValueObject>, IEquatable<TValueObject>
        where TValueObject : ValueObjectBase<TValueObject>
    {
        /// <summary>
        /// 相等性比较
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(TValueObject other)
        {
            return this == other;
        }

        /// <summary>
        /// 相等性比较
        /// </summary>
        /// <param name="other">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>
        /// .
        /// </returns>
        public override bool Equals(object other)
        {
            return Equals(other as TValueObject);
        }

        /// <summary>
        /// 相等性比较
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(ValueObjectBase<TValueObject> left, ValueObjectBase<TValueObject> right)
        {
            if ((object) left == null && (object) right == null)
                return true;
            if (!(left is TValueObject) || !(right is TValueObject))
                return false;
            var properties = left.GetType().GetTypeInfo().GetProperties();
            return properties.All(property => property.GetValue(left) == property.GetValue(right));
        }

        /// <summary>
        /// 不相等比较
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(ValueObjectBase<TValueObject> left, ValueObjectBase<TValueObject> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 获取哈希
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            var properties = GetType().GetTypeInfo().GetProperties();
            return properties.Select(property => property.GetValue(this))
                .Where(value => value != null)
                .Aggregate(0, (current, value) => current ^ value.GetHashCode());
        }

        /// <summary>
        /// 克隆副本
        /// </summary>
        /// <returns>TValueObject.</returns>
        public virtual TValueObject Clone()
        {
            return Convert.To<TValueObject>(MemberwiseClone());
        }
    }
}