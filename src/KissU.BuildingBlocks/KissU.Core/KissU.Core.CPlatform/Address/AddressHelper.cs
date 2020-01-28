using System.Net;
using System.Text.RegularExpressions;

namespace KissU.Core.CPlatform.Address
{
    /// <summary>
    /// 地址帮助类
    /// </summary>
    public class AddressHelper
    {
        /// <summary>
        /// 获取Ip地址
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns>Ip地址</returns>
        public static string GetIpFromAddress(string address)
        {
            if (IsValidIp(address))
            {
                return address;
            }

            var ips = Dns.GetHostAddresses(address);
            return ips[0].ToString();
        }

        /// <summary>
        /// 校验是否为Ip地址
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns>是否为Ip地址</returns>
        public static bool IsValidIp(string address)
        {
            if (Regex.IsMatch(address, "[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}"))
            {
                string[] ips = address.Split('.');
                if (ips.Length == 4 || ips.Length == 6)
                {
                    if (int.Parse(ips[0]) < 256 && int.Parse(ips[1]) < 256 && int.Parse(ips[2]) < 256 && int.Parse(ips[3]) < 256)
                    {
                        return true;
                    }
                }

                return false;
            }

            return false;
        }
    }
}
