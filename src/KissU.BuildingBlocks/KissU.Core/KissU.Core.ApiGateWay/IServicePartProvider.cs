﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Core.ApiGateWay
{
   public interface IServicePartProvider
    {
        bool IsPart(string routhPath);

        Task<object> Merge(string routhPath, Dictionary<string, object> param);
    }
}
