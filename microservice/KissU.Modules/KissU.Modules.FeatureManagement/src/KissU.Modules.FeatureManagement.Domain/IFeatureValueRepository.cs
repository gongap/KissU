using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace KissU.Modules.FeatureManagement.Domain
{
    public interface IFeatureValueRepository : IBasicRepository<FeatureValue, Guid>
    {
        Task<FeatureValue> FindAsync(string name, string providerName, string providerKey);

        Task<List<FeatureValue>> GetListAsync(string providerName, string providerKey);
    }
}
