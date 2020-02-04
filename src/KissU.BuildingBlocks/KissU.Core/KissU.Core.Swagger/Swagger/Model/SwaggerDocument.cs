using System.Collections.Generic;
using Newtonsoft.Json;

namespace KissU.Core.Swagger.Swagger.Model
{
    /// <summary>
    /// SwaggerDocument.
    /// </summary>
    public class SwaggerDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerDocument"/> class.
        /// </summary>
        public SwaggerDocument()
        {
            Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets the swagger.
        /// </summary>
        public string Swagger
        {
            get { return "2.0"; }
        }

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        public Info Info { get; set; }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the base path.
        /// </summary>
        public string BasePath { get; set; }

        /// <summary>
        /// Gets or sets the schemes.
        /// </summary>
        public IList<string> Schemes { get; set; }

        /// <summary>
        /// Gets or sets the consumes.
        /// </summary>
        public IList<string> Consumes { get; set; }

        /// <summary>
        /// Gets or sets the produces.
        /// </summary>
        public IList<string> Produces { get; set; }

        /// <summary>
        /// Gets or sets the paths.
        /// </summary>
        public IDictionary<string, PathItem> Paths { get; set; }

        /// <summary>
        /// Gets or sets the definitions.
        /// </summary>
        public IDictionary<string, Schema> Definitions { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public IDictionary<string, IParameter> Parameters { get; set; }

        /// <summary>
        /// Gets or sets the responses.
        /// </summary>
        public IDictionary<string, Response> Responses { get; set; }

        /// <summary>
        /// Gets or sets the security definitions.
        /// </summary>
        public IDictionary<string, SecurityScheme> SecurityDefinitions { get; set; }

        /// <summary>
        /// Gets or sets the security.
        /// </summary>
        public IList<IDictionary<string, IEnumerable<string>>> Security { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public IList<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or sets the external docs.
        /// </summary>
        public ExternalDocs ExternalDocs { get; set; }

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; private set; }
    }

    /// <summary>
    /// DocumentConfiguration.
    /// </summary>
    public class DocumentConfiguration
    {
        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        public Info Info { get; set; } = null;

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        public DocumentOptions Options { get; set; } = null;
    }

    /// <summary>
    /// DocumentOptions.
    /// </summary>
    public class DocumentOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether [ignore fully qualified].
        /// </summary>
        public bool IgnoreFullyQualified { get; set; }

        /// <summary>
        /// Gets or sets the name of the ingress.
        /// </summary>
        public string IngressName { get; set; }

        /// <summary>
        /// Gets or sets the map route paths.
        /// </summary>
        public IEnumerable<MapRoutePath> MapRoutePaths { get; set; }
    }

    /// <summary>
    /// MapRoutePath.
    /// </summary>
    public class MapRoutePath
    {
        /// <summary>
        /// Gets or sets the source route path.
        /// </summary>
        public string SourceRoutePath { get; set; }

        /// <summary>
        /// Gets or sets the target route path.
        /// </summary>
        public string TargetRoutePath { get; set; }
    }

    /// <summary>
    /// Info.
    /// </summary>
    public class Info
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Info"/> class.
        /// </summary>
        public Info()
        {
            Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the terms of service.
        /// </summary>
        public string TermsOfService { get; set; }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Gets or sets the license.
        /// </summary>
        public License License { get; set; }

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; private set; }
    }

    /// <summary>
    /// Contact.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }
    }

    /// <summary>
    /// License.
    /// </summary>
    public class License
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        public string Url { get; set; }
    }

    /// <summary>
    /// PathItem.
    /// </summary>
    public class PathItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PathItem"/> class.
        /// </summary>
        public PathItem()
        {
            Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        [JsonProperty("$ref")]
        public string Ref { get; set; }

        /// <summary>
        /// Gets or sets the get.
        /// </summary>
        public Operation Get { get; set; }

        /// <summary>
        /// Gets or sets the put.
        /// </summary>
        public Operation Put { get; set; }

        /// <summary>
        /// Gets or sets the post.
        /// </summary>
        public Operation Post { get; set; }

        /// <summary>
        /// Gets or sets the delete.
        /// </summary>
        public Operation Delete { get; set; }

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        public Operation Options { get; set; }

        /// <summary>
        /// Gets or sets the head.
        /// </summary>
        public Operation Head { get; set; }

        /// <summary>
        /// Gets or sets the patch.
        /// </summary>
        public Operation Patch { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public IList<IParameter> Parameters { get; set; }

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; private set; }
    }

    /// <summary>
    /// Operation.
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Operation"/> class.
        /// </summary>
        public Operation()
        {
            Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public IList<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the external docs.
        /// </summary>
        public ExternalDocs ExternalDocs { get; set; }

        /// <summary>
        /// Gets or sets the operation identifier.
        /// </summary>
        public string OperationId { get; set; }

        /// <summary>
        /// Gets or sets the consumes.
        /// </summary>
        public IList<string> Consumes { get; set; }

        /// <summary>
        /// Gets or sets the produces.
        /// </summary>
        public IList<string> Produces { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public IList<IParameter> Parameters { get; set; }

        /// <summary>
        /// Gets or sets the responses.
        /// </summary>
        public IDictionary<string, Response> Responses { get; set; }

        /// <summary>
        /// Gets or sets the schemes.
        /// </summary>
        public IList<string> Schemes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Operation"/> is deprecated.
        /// </summary>
        public bool? Deprecated { get; set; }

        /// <summary>
        /// Gets or sets the security.
        /// </summary>
        public IList<IDictionary<string, IEnumerable<string>>> Security { get; set; }

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; private set; }
    }

    /// <summary>
    /// Tag.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tag"/> class.
        /// </summary>
        public Tag()
        {
            Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the external docs.
        /// </summary>
        public ExternalDocs ExternalDocs { get; set; }

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; private set; }
    }

    /// <summary>
    /// ExternalDocs.
    /// </summary>
    public class ExternalDocs
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        public string Url { get; set; }
    }


    /// <summary>
    /// Interface IParameter
    /// </summary>
    public interface IParameter
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the in.
        /// </summary>
        string In { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IParameter"/> is required.
        /// </summary>
        bool Required { get; set; }

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        Dictionary<string, object> Extensions { get; }
    }

    /// <summary>
    /// BodyParameter.
    /// Implements the <see cref="KissU.Core.Swagger.Swagger.Model.IParameter" />
    /// </summary>
    /// <seealso cref="KissU.Core.Swagger.Swagger.Model.IParameter" />
    public class BodyParameter : IParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodyParameter"/> class.
        /// </summary>
        public BodyParameter()
        {
            In = "body";
            Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the in.
        /// </summary>
        public string In { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BodyParameter"/> is required.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; private set; }

        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        public Schema Schema { get; set; }
    }

    /// <summary>
    /// NonBodyParameter.
    /// Implements the <see cref="KissU.Core.Swagger.Swagger.Model.PartialSchema" />
    /// Implements the <see cref="KissU.Core.Swagger.Swagger.Model.IParameter" />
    /// </summary>
    /// <seealso cref="KissU.Core.Swagger.Swagger.Model.PartialSchema" />
    /// <seealso cref="KissU.Core.Swagger.Swagger.Model.IParameter" />
    public class NonBodyParameter : PartialSchema, IParameter
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the in.
        /// </summary>
        public string In { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NonBodyParameter"/> is required.
        /// </summary>
        public bool Required { get; set; }
    }

    /// <summary>
    /// Schema.
    /// </summary>
    public class Schema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> class.
        /// </summary>
        public Schema()
        {
            Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        [JsonProperty("$ref")]
        public string Ref { get; set; }

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the default.
        /// </summary>
        public object Default { get; set; }

        /// <summary>
        /// Gets or sets the multiple of.
        /// </summary>
        public int? MultipleOf { get; set; }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        public double? Maximum { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [exclusive maximum].
        /// </summary>
        public bool? ExclusiveMaximum { get; set; }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        public double? Minimum { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [exclusive minimum].
        /// </summary>
        public bool? ExclusiveMinimum { get; set; }

        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// Gets or sets the minimum length.
        /// </summary>
        public int? MinLength { get; set; }

        /// <summary>
        /// Gets or sets the pattern.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Gets or sets the maximum items.
        /// </summary>
        public int? MaxItems { get; set; }

        /// <summary>
        /// Gets or sets the minimum items.
        /// </summary>
        public int? MinItems { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [unique items].
        /// </summary>
        public bool? UniqueItems { get; set; }

        /// <summary>
        /// Gets or sets the maximum properties.
        /// </summary>
        public int? MaxProperties { get; set; }

        /// <summary>
        /// Gets or sets the minimum properties.
        /// </summary>
        public int? MinProperties { get; set; }

        /// <summary>
        /// Gets or sets the required.
        /// </summary>
        public IList<string> Required { get; set; }

        /// <summary>
        /// Gets or sets the enum.
        /// </summary>
        public IList<object> Enum { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public Schema Items { get; set; }

        /// <summary>
        /// Gets or sets all of.
        /// </summary>
        public IList<Schema> AllOf { get; set; }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        public IDictionary<string, Schema> Properties { get; set; }

        /// <summary>
        /// Gets or sets the additional properties.
        /// </summary>
        public Schema AdditionalProperties { get; set; }

        /// <summary>
        /// Gets or sets the discriminator.
        /// </summary>
        public string Discriminator { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [read only].
        /// </summary>
        public bool? ReadOnly { get; set; }

        /// <summary>
        /// Gets or sets the XML.
        /// </summary>
        public Xml Xml { get; set; }

        /// <summary>
        /// Gets or sets the external docs.
        /// </summary>
        public ExternalDocs ExternalDocs { get; set; }

        /// <summary>
        /// Gets or sets the example.
        /// </summary>
        public object Example { get; set; }

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; private set; }
    }

    /// <summary>
    /// PartialSchema.
    /// </summary>
    public class PartialSchema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartialSchema"/> class.
        /// </summary>
        public PartialSchema()
        {
            Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public PartialSchema Items { get; set; }

        /// <summary>
        /// Gets or sets the collection format.
        /// </summary>
        public string CollectionFormat { get; set; }

        /// <summary>
        /// Gets or sets the default.
        /// </summary>
        public object Default { get; set; }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        public double? Maximum { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [exclusive maximum].
        /// </summary>
        public bool? ExclusiveMaximum { get; set; }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        public double? Minimum { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [exclusive minimum].
        /// </summary>
        public bool? ExclusiveMinimum { get; set; }

        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// Gets or sets the minimum length.
        /// </summary>
        public int? MinLength { get; set; }

        /// <summary>
        /// Gets or sets the pattern.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Gets or sets the maximum items.
        /// </summary>
        public int? MaxItems { get; set; }

        /// <summary>
        /// Gets or sets the minimum items.
        /// </summary>
        public int? MinItems { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [unique items].
        /// </summary>
        public bool? UniqueItems { get; set; }

        /// <summary>
        /// Gets or sets the enum.
        /// </summary>
        public IList<object> Enum { get; set; }

        /// <summary>
        /// Gets or sets the multiple of.
        /// </summary>
        public int? MultipleOf { get; set; }

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; private set; }
    }

    /// <summary>
    /// Response.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class.
        /// </summary>
        public Response()
        {
            Extensions = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        public Schema Schema { get; set; }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        public IDictionary<string, Header> Headers { get; set; }

        /// <summary>
        /// Gets or sets the examples.
        /// </summary>
        public object Examples { get; set; }

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; private set; }
    }

    /// <summary>
    /// Header.
    /// Implements the <see cref="KissU.Core.Swagger.Swagger.Model.PartialSchema" />
    /// </summary>
    /// <seealso cref="KissU.Core.Swagger.Swagger.Model.PartialSchema" />
    public class Header : PartialSchema
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// Xml.
    /// </summary>
    public class Xml
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Xml"/> is attribute.
        /// </summary>
        public bool? Attribute { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Xml"/> is wrapped.
        /// </summary>
        public bool? Wrapped { get; set; }
    }
}
