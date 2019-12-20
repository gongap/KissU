using System;
using System.Collections.Generic;
using System.Text;
using KissU.Util.Domains;

namespace KissU.Modules.IdentityServer.Domain.Models.ClientAggregate
{
    /// <summary>
    /// 授权类型
    /// </summary>
    public class ClientGrantType : ValueObjectBase<ClientGrantType>
    {
        public ClientGrantType(string grantType)
        {
            GrantType = grantType;
        }

        /// <summary>
        /// 授权类型
        /// </summary>
        public string GrantType { get; set; }
    }
}
