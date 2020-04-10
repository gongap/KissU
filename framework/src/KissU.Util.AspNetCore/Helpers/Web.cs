using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using KissU.Core;
using KissU.Core.Clients;
using KissU.Core.Helpers;
using KissU.Core.Security.Principals;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using File = KissU.Core.Helpers.File;
using HttpRequest = Microsoft.AspNetCore.Http.HttpRequest;
using WebClient = KissU.Core.Clients.WebClient;

namespace KissU.Util.AspNetCore.Helpers
{
    /// <summary>
    /// Web操作
    /// </summary>
    public static class Web
    {
        #region 静态构造方法

        /// <summary>
        /// 初始化Web操作
        /// </summary>
        static Web()
        {
            try
            {
                HttpContextAccessor = Ioc.Create<IHttpContextAccessor>();
                Environment = Ioc.Create<IWebHostEnvironment>();
            }
            catch
            {
                // ignored
            }
        }

        #endregion

        #region 属性

        /// <summary>
        /// Http上下文访问器
        /// </summary>
        public static IHttpContextAccessor HttpContextAccessor { get; set; }

        /// <summary>
        /// 当前Http上下文
        /// </summary>
        public static HttpContext HttpContext => HttpContextAccessor?.HttpContext;

        /// <summary>
        /// 当前Http请求
        /// </summary>
        public static HttpRequest Request => HttpContext?.Request;

        /// <summary>
        /// 当前Http响应
        /// </summary>
        public static HttpResponse Response => HttpContext?.Response;

        /// <summary>
        /// 宿主环境
        /// </summary>
        public static IWebHostEnvironment Environment { get; set; }

        #endregion

        #region User(当前用户安全主体)

        /// <summary>
        /// 当前用户安全主体
        /// </summary>
        public static ClaimsPrincipal User
        {
            get
            {
                var principal = HttpContext?.User;
                return principal ?? UnauthenticatedPrincipal.Instance;
            }
        }

        #endregion

        #region Identity(当前用户身份)

        /// <summary>
        /// 当前用户身份
        /// </summary>
        public static ClaimsIdentity Identity
        {
            get
            {
                if (User.Identity is ClaimsIdentity identity)
                    return identity;
                return UnauthenticatedIdentity.Instance;
            }
        }

        #endregion

        #region AccessToken(获取访问令牌)

        /// <summary>
        /// 获取访问令牌
        /// </summary>
        public static string AccessToken
        {
            get
            {
                var authorization = Request?.Headers["Authorization"].SafeString();
                if (string.IsNullOrWhiteSpace(authorization))
                    return null;
                var list = authorization.Split(' ');
                if (list.Length == 2)
                    return list[1];
                return null;
            }
        }

        #endregion

        #region Body(请求正文)

        /// <summary>
        /// 请求正文
        /// </summary>
        public static string Body
        {
            get
            {
                Request.EnableBuffering();
                return File.ToString(Request.Body, isCloseStream: false);
            }
        }

        #endregion

        #region RequestUrl(请求地址)

        /// <summary>
        /// 请求地址
        /// </summary>
        public static string RequestUrl => Request?.GetDisplayUrl();

        #endregion

        #region Browser(浏览器)

        /// <summary>
        /// 浏览器
        /// </summary>
        public static string Browser => Request?.Headers["User-Agent"];

        #endregion

        #region RootPath(根路径)

        /// <summary>
        /// 根路径
        /// </summary>
        public static string RootPath => Environment?.ContentRootPath;

        #endregion

        #region WebRootPath(Web根路径)

        /// <summary>
        /// Web根路径，即wwwroot
        /// </summary>
        public static string WebRootPath => Environment?.WebRootPath;

        /// <summary>
        /// 获取wwwroot路径
        /// </summary>
        /// <param name="relativePath">相对路径</param>
        /// <returns>System.String.</returns>
        public static string GetWebRootPath(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return string.Empty;
            var rootPath = WebRootPath;
            if (string.IsNullOrWhiteSpace(rootPath))
                return Path.GetFullPath(relativePath);
            return $"{WebRootPath}\\{relativePath.Replace("/", "\\").TrimStart('\\')}";
        }

        #endregion

        #region Host(主机)

        /// <summary>
        /// 主机
        /// </summary>
        public static string Host => HttpContext == null ? Dns.GetHostName() : GetClientHostName();

        /// <summary>
        /// 获取Web客户端主机名
        /// </summary>
        private static string GetClientHostName()
        {
            var address = GetRemoteAddress();
            if (string.IsNullOrWhiteSpace(address))
                return Dns.GetHostName();
            var result = Dns.GetHostEntry(IPAddress.Parse(address)).HostName;
            if (result == "localhost.localdomain")
                result = Dns.GetHostName();
            return result;
        }

        /// <summary>
        /// 获取远程地址
        /// </summary>
        private static string GetRemoteAddress()
        {
            return Request?.Headers["HTTP_X_FORWARDED_FOR"] ?? Request?.Headers["REMOTE_ADDR"];
        }

        #endregion

        #region Client( Web客户端 )

        /// <summary>
        /// Web客户端，用于发送Http请求
        /// </summary>
        /// <returns>Clients.WebClient.</returns>
        public static WebClient Client()
        {
            return new WebClient();
        }

        /// <summary>
        /// Web客户端，用于发送Http请求
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <returns>Clients.WebClient&lt;TResult&gt;.</returns>
        public static WebClient<TResult> Client<TResult>() where TResult : class
        {
            return new WebClient<TResult>();
        }

        #endregion

        #region Ip(客户端Ip地址)

        /// <summary>
        /// Ip地址
        /// </summary>
        private static string _ip;

        /// <summary>
        /// 设置Ip地址
        /// </summary>
        /// <param name="ip">Ip地址</param>
        public static void SetIp(string ip)
        {
            _ip = ip;
        }

        /// <summary>
        /// 重置Ip地址
        /// </summary>
        public static void ResetIp()
        {
            _ip = null;
        }

        /// <summary>
        /// 客户端Ip地址
        /// </summary>
        public static string Ip
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_ip) == false)
                    return _ip;
                var list = new[] { "127.0.0.1", "::1" };
                var result = HttpContext?.Connection?.RemoteIpAddress.SafeString();
                if (string.IsNullOrWhiteSpace(result) || list.Contains(result))
                    result = Common.IsWindows ? GetLanIp() : GetLanIp(NetworkInterfaceType.Ethernet);
                return result;
            }
        }

        /// <summary>
        /// 获取局域网IP
        /// </summary>
        private static string GetLanIp()
        {
            foreach (var hostAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork)
                    return hostAddress.ToString();
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取局域网IP
        /// </summary>
        /// <param name="type">网络接口类型</param>
        private static string GetLanIp(NetworkInterfaceType type)
        {
            try
            {
                foreach (var item in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (item.NetworkInterfaceType != type || item.OperationalStatus != OperationalStatus.Up)
                        continue;
                    var ipProperties = item.GetIPProperties();
                    if (ipProperties.GatewayAddresses.FirstOrDefault() == null)
                        continue;
                    foreach (var ip in ipProperties.UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            return ip.Address.ToString();
                    }
                }
            }
            catch
            {
                return string.Empty;
            }

            return string.Empty;
        }

        #endregion

        #region GetBodyAsync(获取请求正文)

        /// <summary>
        /// 获取请求正文
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public static async Task<string> GetBodyAsync()
        {
            Request.EnableBuffering();
            return await File.ToStringAsync(Request.Body, isCloseStream: false);
        }

        #endregion

        #region GetFiles(获取客户端文件集合)

        /// <summary>
        /// 获取客户端文件集合
        /// </summary>
        /// <returns>List&lt;IFormFile&gt;.</returns>
        public static List<IFormFile> GetFiles()
        {
            var result = new List<IFormFile>();
            var files = Request.Form.Files;
            if (files == null || files.Count == 0)
                return result;
            result.AddRange(files.Where(file => file?.Length > 0));
            return result;
        }

        #endregion

        #region GetFile(获取客户端文件)

        /// <summary>
        /// 获取客户端文件
        /// </summary>
        /// <returns>IFormFile.</returns>
        public static IFormFile GetFile()
        {
            var files = GetFiles();
            return files.Count == 0 ? null : files[0];
        }

        #endregion

        #region GetParam(获取请求参数)

        /// <summary>
        /// 获取请求参数，搜索路径：查询参数-&gt;表单参数-&gt;请求头
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>System.String.</returns>
        public static string GetParam(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;
            if (Request == null)
                return string.Empty;
            var result = string.Empty;
            if (Request.Query != null)
                result = Request.Query[name];
            if (string.IsNullOrWhiteSpace(result) == false)
                return result;
            if (Request.Form != null)
                result = Request.Form[name];
            if (string.IsNullOrWhiteSpace(result) == false)
                return result;
            if (Request.Headers != null)
                result = Request.Headers[name];
            return result;
        }

        #endregion

        #region DownloadAsync(下载)

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <param name="fileName">文件名,包含扩展名</param>
        public static async Task DownloadFileAsync(string filePath, string fileName)
        {
            await DownloadFileAsync(filePath, fileName, Encoding.UTF8);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <param name="fileName">文件名,包含扩展名</param>
        /// <param name="encoding">字符编码</param>
        public static async Task DownloadFileAsync(string filePath, string fileName, Encoding encoding)
        {
            var bytes = File.Read(filePath);
            await DownloadAsync(bytes, fileName, encoding);
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="fileName">文件名,包含扩展名</param>
        public static async Task DownloadAsync(Stream stream, string fileName)
        {
            await DownloadAsync(stream, fileName, Encoding.UTF8);
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="fileName">文件名,包含扩展名</param>
        /// <param name="encoding">字符编码</param>
        public static async Task DownloadAsync(Stream stream, string fileName, Encoding encoding)
        {
            await DownloadAsync(File.ToBytes(stream), fileName, encoding);
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="bytes">字节流</param>
        /// <param name="fileName">文件名,包含扩展名</param>
        public static async Task DownloadAsync(byte[] bytes, string fileName)
        {
            await DownloadAsync(bytes, fileName, Encoding.UTF8);
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="bytes">字节流</param>
        /// <param name="fileName">文件名,包含扩展名</param>
        /// <param name="encoding">字符编码</param>
        public static async Task DownloadAsync(byte[] bytes, string fileName, Encoding encoding)
        {
            if (bytes == null || bytes.Length == 0)
                return;
            fileName = fileName.Replace(" ", "");
            fileName = Url.Encode(fileName, encoding);
            Response.ContentType = "application/octet-stream";
            Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");
            Response.Headers.Add("Content-Length", bytes.Length.ToString());
            await Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }

        #endregion
    }
}