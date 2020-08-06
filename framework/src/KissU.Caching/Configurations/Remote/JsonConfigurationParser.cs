using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KissU.Caching.Utilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KissU.Caching.Configurations.Remote
{
    /// <summary>
    /// JsonConfigurationParser.
    /// Implements the <see cref="KissU.Caching.Configurations.Remote.IConfigurationParser" />
    /// </summary>
    /// <seealso cref="KissU.Caching.Configurations.Remote.IConfigurationParser" />
    public class JsonConfigurationParser : IConfigurationParser
    {
        private readonly Stack<string> _context = new Stack<string>();

        private readonly IDictionary<string, string> _data =
            new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        private string _currentPath;

        private JsonTextReader _reader;

        /// <summary>
        /// Parses the specified input.
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
                _reader = new JsonTextReader(new StreamReader(input));
                _reader.DateParseHandling = DateParseHandling.None;
                var jsonConfig = JObject.Load(_reader);
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
                var errorLine = string.Empty;
                if (input.CanSeek)
                {
                    input.Seek(0, SeekOrigin.Begin);
                    IEnumerable<string> fileContent;
                    using (var streamReader = new StreamReader(input))
                    {
                        fileContent = ReadLines(streamReader);
                        errorLine = RetrieveErrorContext(e, fileContent);
                    }
                }

                throw new FormatException(string.Format(
                        CachingResources.JSONParseException,
                        e.LineNumber,
                        errorLine),
                    e);
            }
        }

        private void VisitJObject(JObject jObject)
        {
            foreach (var property in jObject.Properties())
            {
                EnterContext(property.Name);
                VisitProperty(property);
                ExitContext();
            }
        }

        private void VisitProperty(JProperty property)
        {
            VisitToken(property.Value);
        }

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
                        CachingResources.UnsupportedJSONToken,
                        _reader.TokenType,
                        _reader.Path,
                        _reader.LineNumber,
                        _reader.LinePosition));
            }
        }

        private void VisitArray(JArray array)
        {
            for (var index = 0; index < array.Count; index++)
            {
                EnterContext(index.ToString());
                VisitToken(array[index]);
                ExitContext();
            }
        }

        private void VisitPrimitive(JToken data)
        {
            var key = _currentPath;
            Check.CheckCondition(() => _data.ContainsKey(key), "key");
            _data[key] = data.ToString();
        }

        private void EnterContext(string context)
        {
            _context.Push(context);
            _currentPath = ConfigurationPath.Combine(_context.Reverse());
        }

        private void ExitContext()
        {
            _context.Pop();
            _currentPath = ConfigurationPath.Combine(_context.Reverse());
        }

        private static IEnumerable<string> ReadLines(StreamReader streamReader)
        {
            string line;
            do
            {
                line = streamReader.ReadLine();
                yield return line;
            } while (line != null);
        }

        private static string RetrieveErrorContext(JsonReaderException e, IEnumerable<string> fileContent)
        {
            string errorLine;
            if (e.LineNumber >= 2)
            {
                var errorContext = fileContent.Skip(e.LineNumber - 2).Take(2).ToList();
                errorLine = errorContext[0].Trim() + Environment.NewLine + errorContext[1].Trim();
            }
            else
            {
                var possibleLineContent = fileContent.Skip(e.LineNumber - 1).FirstOrDefault();
                errorLine = possibleLineContent ?? string.Empty;
            }

            return errorLine;
        }
    }
}