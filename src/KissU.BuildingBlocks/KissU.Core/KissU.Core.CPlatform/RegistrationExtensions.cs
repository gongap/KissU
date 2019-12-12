using System;
using KissU.Core.CPlatform.Filters;
using KissU.Core.CPlatform.Module;

namespace KissU.Core.CPlatform
{
    public static class RegistrationExtensions
    { 
        public static void AddFilter(this ContainerBuilderWrapper builder, Type filter)
        {
           
            if (typeof(IExceptionFilter).IsAssignableFrom(filter))
            {
                builder.RegisterType(filter).As<IExceptionFilter>().SingleInstance();
            }
            else if (typeof(IAuthorizationFilter).IsAssignableFrom(filter))
            {
                builder.RegisterType(filter).As<IAuthorizationFilter>().SingleInstance();
            }
        }

       
    }
}
