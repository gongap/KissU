using System;

namespace KissU.Core.CPlatform.Diagnostics
{
    public abstract class ParameterBinder : Attribute, IParameterResolver
    {
        public abstract object Resolve(object value);
    }
}
