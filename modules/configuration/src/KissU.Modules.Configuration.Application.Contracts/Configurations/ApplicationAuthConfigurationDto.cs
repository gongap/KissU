﻿using System;
using System.Collections.Generic;

namespace KissU.Modules.Application.Configurations
{
    [Serializable]
    public class ApplicationAuthConfigurationDto
    {
        public Dictionary<string, bool> Policies { get; set; }

        public Dictionary<string, bool> GrantedPolicies { get; set; }

        public ApplicationAuthConfigurationDto()
        {
            Policies = new Dictionary<string, bool>();
            GrantedPolicies = new Dictionary<string, bool>();
        }
    }
}