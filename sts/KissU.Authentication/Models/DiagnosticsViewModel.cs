using System.Collections.Generic;
using System.Text;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;

namespace KissU.Authentication.Models
{
    /// <summary>
    /// 诊断视图模型
    /// </summary>
    public class DiagnosticsViewModel
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="result"></param>
        public DiagnosticsViewModel(AuthenticateResult result)
        {
            AuthenticateResult = result;

            if (result?.Properties != null && result.Properties.Items.ContainsKey("client_list"))
            {
                var encoded = result.Properties.Items["client_list"];
                var bytes = Base64Url.Decode(encoded);
                var value = Encoding.UTF8.GetString(bytes);

                var clientCodes = JsonConvert.DeserializeObject<string[]>(value);
                Clients.AddRange(clientCodes);
            }
        }

        /// <summary>
        /// 认证结果
        /// </summary>
        public AuthenticateResult AuthenticateResult { get; }

        /// <summary>
        /// 应用列表
        /// </summary>
        public List<string> Clients { get; } = new List<string>();
    }
}
