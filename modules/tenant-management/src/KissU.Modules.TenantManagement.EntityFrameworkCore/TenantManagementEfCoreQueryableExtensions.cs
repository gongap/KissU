using System.Linq;
using KissU.Modules.TenantManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace KissU.Modules.TenantManagement.EntityFrameworkCore
{
    public static class TenantManagementEfCoreQueryableExtensions
    {
        public static IQueryable<Tenant> IncludeDetails(this IQueryable<Tenant> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.ConnectionStrings);
        }
    }
}