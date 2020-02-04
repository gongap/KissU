using System.Reflection;
using System.Xml.XPath;
using KissU.Core.Swagger.Swagger.Model;
using KissU.Core.Swagger.SwaggerGen.Generator;
using Newtonsoft.Json.Serialization;

namespace KissU.Core.Swagger.SwaggerGen.XmlComments
{
    /// <summary>
    /// XmlCommentsSchemaFilter.
    /// Implements the <see cref="KissU.Core.Swagger.SwaggerGen.Generator.ISchemaFilter" />
    /// </summary>
    /// <seealso cref="KissU.Core.Swagger.SwaggerGen.Generator.ISchemaFilter" />
    public class XmlCommentsSchemaFilter : ISchemaFilter
    {
        private const string MemberXPath = "/doc/members/member[@name='{0}']";
        private const string SummaryTag = "summary";
        private const string ExampleXPath = "example";

        private readonly XPathNavigator _xmlNavigator;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlCommentsSchemaFilter"/> class.
        /// </summary>
        /// <param name="xmlDoc">The XML document.</param>
        public XmlCommentsSchemaFilter(XPathDocument xmlDoc)
        {
            _xmlNavigator = xmlDoc.CreateNavigator();
        }

        /// <summary>
        /// Applies the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="context">The context.</param>
        public void Apply(Schema schema, SchemaFilterContext context)
        {
            var jsonObjectContract = context.JsonContract as JsonObjectContract;
            if (jsonObjectContract == null) return;

            var memberName = XmlCommentsMemberNameHelper.GetMemberNameForType(context.SystemType);
            var typeNode = _xmlNavigator.SelectSingleNode(string.Format(MemberXPath, memberName));

            if (typeNode != null)
            {
                var summaryNode = typeNode.SelectSingleNode(SummaryTag);
                if (summaryNode != null)
                    schema.Description = XmlCommentsTextHelper.Humanize(summaryNode.InnerXml);
            }

            if (schema.Properties == null) return;
            foreach (var entry in schema.Properties)
            {
                var jsonProperty = jsonObjectContract.Properties[entry.Key];
                if (jsonProperty == null) continue;

                if (jsonProperty.TryGetMemberInfo(out MemberInfo memberInfo))
                {
                    ApplyPropertyComments(entry.Value, memberInfo);
                }
            }
        }

        private void ApplyPropertyComments(Schema propertySchema, MemberInfo memberInfo)
        {
            var memberName = XmlCommentsMemberNameHelper.GetMemberNameForMember(memberInfo);
            var memberNode = _xmlNavigator.SelectSingleNode(string.Format(MemberXPath, memberName));
            if (memberNode == null) return;

            var summaryNode = memberNode.SelectSingleNode(SummaryTag);
            if (summaryNode != null)
            {
                propertySchema.Description = XmlCommentsTextHelper.Humanize(summaryNode.InnerXml);
            }

            var exampleNode = memberNode.SelectSingleNode(ExampleXPath);
            if (exampleNode != null)
                propertySchema.Example = XmlCommentsTextHelper.Humanize(exampleNode.InnerXml);
        }
    }
}
