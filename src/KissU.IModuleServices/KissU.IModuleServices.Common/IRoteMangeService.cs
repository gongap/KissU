using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.IModuleServices.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KissU.IModuleServices.Common
{
    [ServiceBundle("Api/{Service}")]
    public interface IRoteMangeService
    {
        Task<UserModel> GetServiceById(string serviceId);

        Task<bool> SetRote(RoteModel model);
    }
}
