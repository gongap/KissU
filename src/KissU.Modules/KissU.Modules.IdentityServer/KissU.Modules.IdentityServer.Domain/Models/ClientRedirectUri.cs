using System;
using System.Collections.Generic;
using System.Text;
using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models.ClientAggregate
{
    /// <summary>
    /// 令牌或授权码的URI
    /// </summary>
    public class ClientRedirectUri : ValueObjectBase<ClientRedirectUri>
    {
        /// <summary>
        /// 令牌或授权码的URI
        /// </summary>
        public string RedirectUri { get; set; }
    }
}
