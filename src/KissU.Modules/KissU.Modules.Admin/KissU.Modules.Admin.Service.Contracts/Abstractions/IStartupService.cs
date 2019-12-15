// <copyright file="IStartupService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Core.CPlatform.Support;
using KissU.Core.CPlatform.Support.Attributes;

namespace KissU.Modules.Admin.Service.Contracts.Abstractions
{
    using System.Threading.Tasks;
    using KissU.Modules.Admin.Service.Contracts.Dtos.NgAlain;
    using Util.Applications;

    [ServiceBundle("api/{Service}")]
    public interface IStartupService : IService
    {
        /// <summary>
        /// 获取应用程序数据
        /// </summary>
        /// <returns></returns>
        [Command(Strategy = StrategyType.Injection, ShuntStrategy = AddressSelectorMode.HashAlgorithm,
            ExecutionTimeoutInMilliseconds = 2500, BreakerRequestVolumeThreshold = 3, Injection = @"return 1;",
            RequestCacheEnabled = false)]
        [HttpGet(true)]
        //[Authorization(AuthType = AuthorizationType.JWTBearer)]
        Task<AppData> GetAppDataAsync();
    }
}
