using System;
using System.Security.Cryptography;
using System.Text;

namespace KissU.AspNetCore.Stage.Module.Implementation;

[Serializable]
public class IdentityModelDiscoveryDocumentCacheItem
{
    public string TokenEndpoint { get; set; }
    public string RevocationEndpoint { get; set; }

    public IdentityModelDiscoveryDocumentCacheItem()
    {
    }

    public IdentityModelDiscoveryDocumentCacheItem(string tokenEndpoint,string revocationEndpoint)
    {
        TokenEndpoint = tokenEndpoint;
        RevocationEndpoint = revocationEndpoint;
    }

    public static string CalculateCacheKey()
    {
        var str =AppConfig.Options.AuthServer.Authority.ToLower();
        using (var md5 = MD5.Create())
        {
            var inputBytes = Encoding.UTF8.GetBytes(str);
            var hashBytes = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                sb.Append(hashByte.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
