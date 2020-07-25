using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Volo.Abp.ObjectExtending;

namespace KissU.Modules.Application.ObjectExtending
{
    public static class ObjectExtensionPropertyInfoAspNetCoreMvcExtensions
    {
        private static readonly Type[] DateTimeTypes =
        {
            typeof(DateTime),
            typeof(DateTimeOffset)
        };

        public static bool IsDate(this IBasicObjectExtensionPropertyInfo property)
        {
            return DateTimeTypes.Contains(property.Type) &&
                   property.GetDataTypeOrNull() == DataType.Date;
        }

        public static bool IsDateTime(this IBasicObjectExtensionPropertyInfo property)
        {
            return DateTimeTypes.Contains(property.Type) &&
                   !property.IsDate();
        }

        public static DataType? GetDataTypeOrNull(this IBasicObjectExtensionPropertyInfo property)
        {
            return property
                .Attributes
                .OfType<DataTypeAttribute>()
                .FirstOrDefault()?.DataType;
        }
    }
}
