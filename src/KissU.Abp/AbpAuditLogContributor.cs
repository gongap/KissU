using Volo.Abp.AspNetCore.WebClientInfo;
using Volo.Abp.Auditing;
using Volo.Abp.DependencyInjection;
using KissU.AspNetCore;
using KissU.CPlatform.Transport.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Linq;
using KissUtil.Extensions;

namespace KissU.Abp;

public class AbpAuditLogContributor : AuditLogContributor, ITransientDependency
{
    public ILogger<AbpAuditLogContributor> Logger { get; set; }

    public AbpAuditLogContributor()
    {
        Logger = NullLogger<AbpAuditLogContributor>.Instance;
    }

    public override void PreContribute(AuditLogContributionContext context)
    {
        if (context.AuditInfo.HttpMethod == null)
        {
            context.AuditInfo.HttpMethod = RpcContext.GetContext().GetAttachment("HttpRequestMethod")?.SafeString();
        }

        if (context.AuditInfo.Url == null)
        {
            context.AuditInfo.Url = BuildUrl();
        }

        var clientInfoProvider = context.ServiceProvider.GetRequiredService<IWebClientInfoProvider>();
        if (context.AuditInfo.ClientIpAddress == null)
        {
            context.AuditInfo.ClientIpAddress = clientInfoProvider.ClientIpAddress;
        }

        if (context.AuditInfo.BrowserInfo == null)
        {
            context.AuditInfo.BrowserInfo = clientInfoProvider.BrowserInfo;
        }

        context.AuditInfo.ApplicationName = CPlatform.AppConfig.ServerOptions.Name;
    }

    public override void PostContribute(AuditLogContributionContext context)
    {
        var firstAction = context.AuditInfo.Actions.FirstOrDefault();
        context.AuditInfo.Comments.Add( firstAction?.ServiceName + "." + firstAction?.MethodName);
        context.AuditInfo.Url = RpcContext.GetContext().GetAttachment("HttpRoutePath")?.SafeString();
        if (context.AuditInfo.HttpStatusCode == null)
        {
            context.AuditInfo.HttpStatusCode = context.AuditInfo.Exceptions.Any() ? (int)StatusCode.ServerError : (int)StatusCode.Success;
        }
    }

    protected virtual string BuildUrl()
    {
        var uriBuilder = new UriBuilder();
        uriBuilder.Scheme = RpcContext.GetContext().GetAttachment("HttpRequestScheme")?.SafeString();
        uriBuilder.Host = RpcContext.GetContext().GetAttachment("HttpRequestHost")?.SafeString();
        uriBuilder.Path = RpcContext.GetContext().GetAttachment("HttpRequestPath")?.SafeString();
        uriBuilder.Query = RpcContext.GetContext().GetAttachment("HttpQueryString")?.SafeString();

        return uriBuilder.Uri.AbsolutePath;
    }
}
