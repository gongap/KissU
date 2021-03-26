using System.Threading.Tasks;
using KissU.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.CPlatform.Support.Attributes;
using KissU.Dependency;
using KissU.WebSocket.Attributes;

namespace KissU.Modules.Account.Service.Contracts
{
    /// <summary>
    /// 位置服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    [BehaviorContract(IgnoreExtensions = true)]
    public interface ILocationService : IServiceKey
    {
        /// <summary>
        /// 上报位置
        /// </summary>
        /// <param name="teamId">用户标识</param>
        /// <param name="location">位置信息</param>
        /// <returns>Task.</returns>
        [Command(ShuntStrategy = AddressSelectorMode.HashAlgorithm)]
        Task Reprot(string userId, string teamId, string location);
    }
}