using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KissU.ProxyGenerator.FastReflection;

namespace KissU.ProxyGenerator.Utilitys
{
    /// <summary>
    /// AttributeFactory.
    /// </summary>
    internal class AttributeFactory
    {
        private readonly Func<object> m_attributeCreator;
        private readonly List<Action<object>> m_propertySetters;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeFactory" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public AttributeFactory(CustomAttributeData data)
        {
            Data = data;

            var ctorInvoker = new ConstructorInvoker(data.Constructor);
            var ctorArgs = data.ConstructorArguments.Select(a => a.Value).ToArray();
            m_attributeCreator = () => ctorInvoker.Invoke(ctorArgs);

            m_propertySetters = new List<Action<object>>();
            foreach (var arg in data.NamedArguments)
            {
                var property = (PropertyInfo) arg.MemberInfo;
                var propertyAccessor = new PropertyAccessor(property);
                var value = arg.TypedValue.Value;
                m_propertySetters.Add(o => propertyAccessor.SetValue(o, value));
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public CustomAttributeData Data { get; }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>Attribute.</returns>
        public Attribute Create()
        {
            var attribute = m_attributeCreator();

            foreach (var setter in m_propertySetters)
            {
                setter(attribute);
            }

            return (Attribute) attribute;
        }
    }
}