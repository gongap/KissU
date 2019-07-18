using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Surging.Core.CPlatform.Support;
using Surging.Core.CPlatform.Support.Attributes;
using Surging.Core.Caching;
using Surging.Core.System.Intercept;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Domains.Repositories;
using KissU.IModuleServices.QuickStart.Dtos;
using KissU.IModuleServices.QuickStart.Queries;
using GreatWall.Service.Dtos;
using GreatWall.Service.Queries;
using GreatWall.Service.Dtos.Requests;

namespace KissU.IModuleServices.QuickStart
{

    [ServiceBundle("api/{Service}")]
    public interface IUserManageService : IServiceKey
    {
        Task<List<UserDto>> GetAll();
    }
}
