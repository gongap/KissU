using System;
using System.Collections.Generic;

namespace KissU.Modules.Application.Configurations
{
    [Serializable]
    public class ApplicationSettingConfigurationDto
    {
        public Dictionary<string, string> Values { get; set; }
    }
}