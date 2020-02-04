﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KissU.Core.Swagger.Swagger.Model;

namespace KissU.Core.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// SchemaExtensions.
    /// </summary>
    internal static class SchemaExtensions
    {
        /// <summary>
        /// Assigns the attribute metadata.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="attributes">The attributes.</param>
        /// <returns>Schema.</returns>
        internal static Schema AssignAttributeMetadata(this Schema schema, IEnumerable<object> attributes)
        {
            foreach (var attribute in attributes)
            {
                if (attribute is DefaultValueAttribute defaultValue)
                    schema.Default = defaultValue.Value;

                if (attribute is RegularExpressionAttribute regex)
                    schema.Pattern = regex.Pattern;

                if (attribute is RangeAttribute range)
                {
                    if (Double.TryParse(range.Maximum.ToString(), out double maximum))
                        schema.Maximum = maximum;

                    if (Double.TryParse(range.Minimum.ToString(), out double minimum))
                        schema.Minimum = minimum;
                }

                if (attribute is MinLengthAttribute minLength)
                    schema.MinLength = minLength.Length;

                if (attribute is MaxLengthAttribute maxLength)
                    schema.MaxLength = maxLength.Length;

                if (attribute is StringLengthAttribute stringLength)
                {
                    schema.MinLength = stringLength.MinimumLength;
                    schema.MaxLength = stringLength.MaximumLength;
                }

                if (attribute is DataTypeAttribute dataTypeAttribute && schema.Type == "string")
                {
                    if (DataTypeFormatMap.TryGetValue(dataTypeAttribute.DataType, out string format))
                        schema.Format = format;
                }
            }

            return schema;
        }

        /// <summary>
        /// Populates from.
        /// </summary>
        /// <param name="partialSchema">The partial schema.</param>
        /// <param name="schema">The schema.</param>
        internal static void PopulateFrom(this PartialSchema partialSchema, Schema schema)
        {
            if (schema == null) return;

            partialSchema.Type = schema.Type;
            partialSchema.Format = schema.Format;

            if (schema.Items != null)
            {
                // TODO: Handle jagged primitive array and error on jagged object array
                partialSchema.Items = new PartialSchema();
                partialSchema.Items.PopulateFrom(schema.Items);
                partialSchema.CollectionFormat = "multi";
            }

            partialSchema.Default = schema.Default;
            partialSchema.Maximum = schema.Maximum;
            partialSchema.ExclusiveMaximum = schema.ExclusiveMaximum;
            partialSchema.Minimum = schema.Minimum;
            partialSchema.ExclusiveMinimum = schema.ExclusiveMinimum;
            partialSchema.MaxLength = schema.MaxLength;
            partialSchema.MinLength = schema.MinLength;
            partialSchema.Pattern = schema.Pattern;
            partialSchema.MaxItems = schema.MaxItems;
            partialSchema.MinItems = schema.MinItems;
            partialSchema.UniqueItems = schema.UniqueItems;
            partialSchema.Enum = schema.Enum;
            partialSchema.MultipleOf = schema.MultipleOf;
        }

        private static readonly Dictionary<DataType, string> DataTypeFormatMap = new Dictionary<DataType, string>
        {
            { DataType.Date, "date" },
            { DataType.DateTime, "date-time" },
            { DataType.Password, "password" }
        };
    }
}
