using Volo.Abp.MultiTenancy;
using KissU.CPlatform.Transport.Implementation;
using System.Threading.Tasks;
using KissUtil.Extensions;

namespace KissU.Abp;

public class AbpTenantResolveContributor : TenantResolveContributorBase
{
    public const string ContributorName = "Rpc";

    public override string Name => ContributorName;

    public override Task ResolveAsync(ITenantResolveContext context)
    {
        var tenantKey = TenantResolverConsts.DefaultTenantKey;
        var tenantIdOrName = RpcContext.GetContext().GetAttachment(tenantKey)?.SafeString();
        if (!string.IsNullOrWhiteSpace(tenantIdOrName))
        {
            context.Handled = true;
            context.TenantIdOrName = tenantIdOrName;
        }

        return Task.CompletedTask;
    }
}
