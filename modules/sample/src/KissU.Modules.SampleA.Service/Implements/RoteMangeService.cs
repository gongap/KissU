using System.Threading.Tasks;
using KissU.Modules.SampleA.Service.Contracts;
using KissU.Modules.SampleA.Service.Contracts.Dtos;
using KissU.ServiceProxy;

namespace KissU.Modules.SampleA.Service.Implements
{
    /// <summary>
    /// RoteMangeService.
    /// Implements the <see cref="ProxyServiceBase" />
    /// Implements the <see cref="IRoteMangeService" />
    /// </summary>
    /// <seealso cref="ProxyServiceBase" />
    /// <seealso cref="IRoteMangeService" />
    public class RoteMangeService : ProxyServiceBase, IRoteMangeService
    {
        /// <summary>
        /// Gets the service by identifier.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>Task&lt;UserModel&gt;.</returns>
        public Task<UserModel> GetServiceById(string serviceId)
        {
            return Task.FromResult(new UserModel());
        }

        /// <summary>
        /// Sets the rote.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public Task<bool> SetRote(RoteModel model)
        {
            return Task.FromResult(true);
        }
    }
}