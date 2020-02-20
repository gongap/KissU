using System.Threading.Tasks;
using KissU.Core.CPlatform.Ioc;
using KissU.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;
using KissU.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Core.CPlatform.Support.Attributes;
using KissU.Core.Protocol.WS.Attributes;

namespace KissU.Modules.SampleA.Service.Contracts
{
    /// <summary>
    /// Interface IChatService
    /// Implements the <see cref="KissU.Core.CPlatform.Ioc.IServiceKey" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Ioc.IServiceKey" />
    [ServiceBundle("Api/{Service}")]
    [BehaviorContract(IgnoreExtensions = true)]
    public interface IChatService : IServiceKey
    {
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="data">The data.</param>
        /// <returns>Task.</returns>
        [Command(ShuntStrategy = AddressSelectorMode.HashAlgorithm)]
        Task SendMessage(string name, string data);
    }
}