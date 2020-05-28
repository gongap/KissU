using System;
using Volo.Abp;

namespace KissU.Modules.FeatureManagement
{
    [Serializable]
    public class FeatureNameValue : NameValue
    {
        public FeatureNameValue()
        {

        }

        public FeatureNameValue(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}