using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Stores;
using KissU.Modules.IdentityServer.Domain.Models.ClientAggregate;
using KissU.Modules.IdentityServer.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Util.Maps;
using Client = IdentityServer4.Models.Client;

namespace KissU.Modules.IdentityServer.Data.Stores
{
    /// <summary>
    /// 应用程序存储器
    /// </summary>
    public class ClientStore : IClientStore
    {
        /// <summary>
        /// 初始化应用程序仓储
        /// </summary>
        /// <param name="clientRepository">应用程序仓储</param>
        public ClientStore(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        /// <summary>
        /// 应用程序存储器
        /// </summary>
        private readonly IClientRepository _clientRepository;

        /// <summary>
        /// 通过ClientId查找应用
        /// </summary>
        /// <param name="clientId">The client id</param>
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var queryable = _clientRepository.Find(p => p.ClientCode == clientId)
                .Include(x => x.ClientSecrets)
                .Include(x=>x.Claims);

            var client = queryable.SingleOrDefault();
            if (client != null)
            {
                if (!client.Claims.Any(x => x.Type == "id"))
                {
                    client.Claims.Add(new ClientClaim { Type = "id", Value = client.Id.ToString() });
                }
            }

            var model = client?.MapTo<Client>();

            model.ClientId = clientId;

            return Task.FromResult(model);
        }
    }
}
