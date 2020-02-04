using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KissU.Core.ProxyGenerator.FastReflection;

namespace KissU.Core.ProxyGenerator.Utilitys
{
    /// <summary>
    /// AttributeFactory.
    /// </summary>
    class AttributeFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeFactory"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public AttributeFactory(CustomAttributeData data)
        {
            this.Data = data;

            var ctorInvoker = new ConstructorInvoker(data.Constructor);
            var ctorArgs = data.ConstructorArguments.Select(a => a.Value).ToArray();
            this.m_attributeCreator = () => ctorInvoker.Invoke(ctorArgs);

            this.m_propertySetters = new List<Action<object>>();
            foreach (var arg in data.NamedArguments)
            {
                var property = (PropertyInfo)arg.MemberInfo;
                var propertyAccessor = new PropertyAccessor(property);
                var value = arg.TypedValue.Value;
                this.m_propertySetters.Add(o => propertyAccessor.SetValue(o, value));
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public CustomAttributeData Data { get; private set; }

        private Func<object> m_attributeCreator;
        private List<Action<object>> m_propertySetters;

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>Attribute.</returns>
        public Attribute Create()
        {
            var attribute = this.m_attributeCreator();

            foreach (var setter in this.m_propertySetters)
            {
                setter(attribute);
            }

            return (Attribute)attribute;
        }
    }
}
