using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Util.Maps;
using Microsoft.EntityFrameworkCore;

namespace KissU.Modules.IdentityServer.Stores
{
    /// <summary>
    /// 应用程序存储器
    /// </summary>
    public class ClientStore : IClientStore
    {
        /// <summary>
        /// 应用程序存储器
        /// </summary>
        private readonly IClientRepository _clientRepository;

        /// <summary>
        /// 初始化应用程序仓储
        /// </summary>
        /// <param name="clientRepository">应用程序仓储</param>
        public ClientStore(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        /// <summary>
        /// 通过ClientId查找应用
        /// </summary>
        /// <param name="clientId">The client id</param>
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var queryable = _clientRepository.Find(p => p.ClientId == clientId)
                .Include(x => x.ClientSecrets)
                .Include(x => x.Claims);

            var client = queryable.SingleOrDefault();

            var model = client?.MapTo<Client>();

            return Task.FromResult(model);
        }
    }
}