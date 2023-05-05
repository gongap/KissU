using Volo.Abp.AspNetCore.WebClientInfo;
using Volo.Abp.DependencyInjection;
using KissU.CPlatform.Transport.Implementation;
using KissUtil.Extensions;

namespace KissU.Abp
{
    public class AbpWebClientInfoProvider : IWebClientInfoProvider, ITransientDependency
    {
        public string BrowserInfo => GetBrowserInfo();

        public string ClientIpAddress => GetClientIpAddress();

        protected virtual string GetBrowserInfo()
        {
            return RpcContext.GetContext().GetAttachment("User-Agent")?.SafeString();
        }

        protected virtual string GetClientIpAddress()
        {
          return RpcContext.GetContext().GetAttachment("RemoteIpAddress")?.SafeString();
        }
    }
}
