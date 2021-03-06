﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;
using KissU.AspNetCore.Swagger.Swagger.Model;
using KissU.AspNetCore.Swagger.SwaggerGen.Generator;
using KissU.CPlatform.Runtime.Server;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace KissU.AspNetCore.Swagger.SwaggerGen.XmlComments
{
    /// <summary>
    /// XmlCommentsDocumentFilter.
    /// Implements the <see cref="IDocumentFilter" />
    /// </summary>
    /// <seealso cref="IDocumentFilter" />
    public class XmlCommentsDocumentFilter : IDocumentFilter
    {
        private const string MemberXPath = "/doc/members/member[@name='{0}']";
        private const string SummaryTag = "summary";

        private readonly XPathNavigator _xmlNavigator;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlCommentsDocumentFilter" /> class.
        /// </summary>
        /// <param name="xmlDoc">The XML document.</param>
        public XmlCommentsDocumentFilter(XPathDocument xmlDoc)
        {
            _xmlNavigator = xmlDoc.CreateNavigator();
        }

        /// <summary>
        /// Applies the specified swagger document.
        /// </summary>
        /// <param name="swaggerDoc">The swagger document.</param>
        /// <param name="context">The context.</param>
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            if (context.ApiDescriptions != null)
                ApplyControllersXmlToController(swaggerDoc, context.ApiDescriptions);
            else
                ApplyControllersXmlToController(swaggerDoc, context.ServiceEntries);
        }

        private void ApplyControllersXmlToController(SwaggerDocument swaggerDoc, IEnumerable<ApiDescription> apiDescriptions)
        {
            // Collect (unique) controller names and types in a dictionary
            var controllerNamesAndTypes = apiDescriptions
                .Select(apiDesc => apiDesc.ActionDescriptor as ControllerActionDescriptor)
                .SkipWhile(actionDesc => actionDesc == null)
                .GroupBy(actionDesc => actionDesc.ControllerName)
                .ToDictionary(grp => grp.Key, grp => grp.Last().ControllerTypeInfo.AsType());

            foreach (var nameAndType in controllerNamesAndTypes)
            {
                var memberName = XmlCommentsMemberNameHelper.GetMemberNameForType(nameAndType.Value);
                var typeNode = _xmlNavigator.SelectSingleNode(string.Format(MemberXPath, memberName));

                if (typeNode != null)
                {
                    var summaryNode = typeNode.SelectSingleNode(SummaryTag);
                    if (summaryNode != null)
                    {
                        if (swaggerDoc.Tags == null)
                            swaggerDoc.Tags = new List<Tag>();

                        swaggerDoc.Tags.Add(new Tag
                        {
                            Name = nameAndType.Key,
                            Description = XmlCommentsTextHelper.Humanize(summaryNode.InnerXml)
                        });
                    }
                }
            }
        }

        private void ApplyControllersXmlToController(SwaggerDocument swaggerDoc, IEnumerable<ServiceEntry> apiDescriptions)
        {
            foreach (var serviceEntry in apiDescriptions)
            {
                var memberName = XmlCommentsMemberNameHelper.GetMemberNameForType(serviceEntry.Type);
                var typeNode = _xmlNavigator.SelectSingleNode(string.Format(MemberXPath, memberName));

                if (typeNode != null)
                {
                    var summaryNode = typeNode.SelectSingleNode(SummaryTag);
                    if (summaryNode != null)
                    {
                        if (swaggerDoc.Tags == null)
                            swaggerDoc.Tags = new List<Tag>();

                        swaggerDoc.Tags.Add(new Tag
                        {
                            Name = serviceEntry.Type.Name,
                            Description = XmlCommentsTextHelper.Humanize(summaryNode.InnerXml)
                        });
                    }
                }
            }
        }
    }
}