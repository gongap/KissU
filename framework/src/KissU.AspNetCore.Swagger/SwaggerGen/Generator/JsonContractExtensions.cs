using Newtonsoft.Json.Serialization;

namespace KissU.Kestrel.Swagger.SwaggerGen.Generator
{
    /// <summary>
    /// JsonContractExtensions.
    /// </summary>
    internal static class JsonContractExtensions
    {
        /// <summary>
        /// Determines whether [is self referencing array or dictionary] [the specified json contract].
        /// </summary>
        /// <param name="jsonContract">The json contract.</param>
        /// <returns>
        /// <c>true</c> if [is self referencing array or dictionary] [the specified json contract]; otherwise,
        /// <c>false</c>.
        /// </returns>
        internal static bool IsSelfReferencingArrayOrDictionary(this JsonContract jsonContract)
        {
            if (jsonContract is JsonArrayContract arrayContract)
                return arrayContract.UnderlyingType == arrayContract.CollectionItemType;

            if (jsonContract is JsonDictionaryContract dictionaryContract)
                return dictionaryContract.UnderlyingType == dictionaryContract.DictionaryValueType;

            return false;
        }
    }
}