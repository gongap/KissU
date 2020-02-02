using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using KissU.Core.CPlatform.Utilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KissU.Core.CPlatform.Configurations.Remote
{
    /// <summary>
    /// Json配置解析器.
    /// Implements the <see cref="IConfigurationParser" />
    /// </summary>
    /// <seealso cref="IConfigurationParser" />
    public class JsonConfigurationParser : IConfigurationParser
    {
        private readonly IDictionary<string, string> _data = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private readonly Stack<string> _context = new Stack<string>();
        private string _currentPath;
        private JsonTextReader _reader;

        /// <summary>
        /// 解析.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="initialContext">The initial context.</param>
        /// <returns>IDictionary&lt;System.String, System.String&gt;.</returns>
        /// <exception cref="FormatException"></exception>
        public IDictionary<string, string> Parse(Stream input, string initialContext)
        {
            try
            {
                _data.Clear();
                _reader = new JsonTextReader(new StreamReader(input))
                {
                    DateParseHandling = DateParseHandling.None,
                };
                JObject jsonConfig = JObject.Load(_reader);
                if (!string.IsNullOrEmpty(initialContext))
                {
                    EnterContext(initialContext);
                }

                VisitJObject(jsonConfig);
                if (!string.IsNullOrEmpty(initialContext))
                {
                    ExitContext();
                }

                return _data;
            }
            catch (JsonReaderException e)
            {
                string errorLine = string.Empty;
                if (input.CanSeek)
                {
                    input.Seek(0, SeekOrigin.Begin);

                    IEnumerable<string> fileContent;
                    using (StreamReader streamReader = new StreamReader(input))
                    {
                        fileContent = ReadLines(streamReader);
                        errorLine = RetrieveErrorContext(e, fileContent);
                    }
                }

                throw new FormatException(
                    string.Format(
                        CPlatformResource.JSONParseException,
                        e.LineNumber,
                        errorLine),
                    e);
            }
        }

        /// <summary>
        /// Visit the jobject.
        /// </summary>
        /// <param name="jObject">The j object.</param>
        private void VisitJObject(JObject jObject)
        {
            foreach (JProperty property in jObject.Properties())
            {
                EnterContext(property.Name);
                VisitProperty(property);
                ExitContext();
            }
        }

        /// <summary>
        /// Visits the property.
        /// </summary>
        /// <param name="property">The property.</param>
        private void VisitProperty(JProperty property)
        {
            VisitToken(property.Value);
        }

        /// <summary>
        /// Visits the token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <exception cref="FormatException">格式异常</exception>
        private void VisitToken(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    VisitJObject(token.Value<JObject>());
                    break;

                case JTokenType.Array:
                    VisitArray(token.Value<JArray>());
                    break;

                case JTokenType.Integer:
                case JTokenType.Float:
                case JTokenType.String:
                case JTokenType.Boolean:
                case JTokenType.Bytes:
                case JTokenType.Raw:
                case JTokenType.Null:
                    VisitPrimitive(token);
                    break;

                default:
                    throw new FormatException(string.Format(
                       CPlatformResource.UnsupportedJSONToken,
                       _reader.TokenType,
                       _reader.Path,
                       _reader.LineNumber,
                       _reader.LinePosition));
            }
        }

        /// <summary>
        /// Visit the array.
        /// </summary>
        /// <param name="array">The array.</param>
        private void VisitArray(JArray array)
        {
            for (int index = 0; index < array.Count; index++)
            {
                EnterContext(index.ToString());
                VisitToken(array[index]);
                ExitContext();
            }
        }

        /// <summary>
        /// Visit the primitive.
        /// </summary>
        /// <param name="data">The data.</param>
        private void VisitPrimitive(JToken data)
        {
            string key = _currentPath;
            Check.CheckCondition(() => _data.ContainsKey(key), "key");
            _data[key] = EnvironmentHelper.GetEnvironmentVariable(data.ToString());
        }

        /// <summary>
        /// Enter the context.
        /// </summary>
        /// <param name="context">The context.</param>
        private void EnterContext(string context)
        {
            _context.Push(context);
            _currentPath = ConfigurationPath.Combine(_context.Reverse());
        }

        /// <summary>
        /// Exit the context.
        /// </summary>
        private void ExitContext()
        {
            _context.Pop();
            _currentPath = ConfigurationPath.Combine(_context.Reverse());
        }

        /// <summary>
        /// Read the lines.
        /// </summary>
        /// <param name="streamReader">The stream reader.</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        private static IEnumerable<string> ReadLines(StreamReader streamReader)
        {
            string line;
            do
            {
                line = streamReader.ReadLine();
                yield return line;
            }
            while (line != null);
        }

        /// <summary>
        /// Retrieves the error context.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="fileContent">Content of the file.</param>
        /// <returns>System.String.</returns>
        private static string RetrieveErrorContext(JsonReaderException e, IEnumerable<string> fileContent)
        {
            string errorLine;
            if (e.LineNumber >= 2)
            {
                List<string> errorContext = fileContent.Skip(e.LineNumber - 2).Take(2).ToList();
                errorLine = errorContext[0].Trim() + Environment.NewLine + errorContext[1].Trim();
            }
            else
            {
                string possibleLineContent = fileContent.Skip(e.LineNumber - 1).FirstOrDefault();
                errorLine = possibleLineContent ?? string.Empty;
            }

            return errorLine;
        }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        private static List<string> GetParameters(string text)
        {
            var matchVale = new List<string>();
            var reg = @"(?<=\${)[^\${}]*(?=})";
            foreach (Match m in Regex.Matches(text, reg))
            {
                matchVale.Add(m.Value);
            }

            return matchVale;
        }
    }
}
