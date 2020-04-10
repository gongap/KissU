using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Consul;

namespace KissU.Surging.Consul.Utilitys
{
    /// <summary>
    /// ConsulClientExtensions.
    /// </summary>
    public static class ConsulClientExtensions
    {
        /// <summary>
        /// get children as an asynchronous operation.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="path">The path.</param>
        /// <returns>Task&lt;System.String[]&gt;.</returns>
        public static async Task<string[]> GetChildrenAsync(this ConsulClient client, string path)
        {
            try
            {
                var queryResult = await client.KV.List(path);
                return queryResult.Response?.Select(p => Encoding.UTF8.GetString(p.Value)).ToArray();
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        /// <summary>
        /// get data as an asynchronous operation.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="path">The path.</param>
        /// <returns>Task&lt;System.Byte[]&gt;.</returns>
        public static async Task<byte[]> GetDataAsync(this ConsulClient client, string path)
        {
            try
            {
                var queryResult = await client.KV.Get(path);
                return queryResult.Response?.Value;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}