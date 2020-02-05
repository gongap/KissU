using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KissU.Util.Clients
{
    /// <summary>
    /// Http请求
    /// </summary>
    /// <typeparam name="TRequest">The type of the t request.</typeparam>
    public interface IRequest<out TRequest> where TRequest : IRequest<TRequest>
    {
        /// <summary>
        /// 设置字符编码
        /// </summary>
        /// <param name="encoding">字符编码</param>
        /// <returns>TRequest.</returns>
        TRequest Encoding(Encoding encoding);

        /// <summary>
        /// 设置字符编码
        /// </summary>
        /// <param name="encoding">字符编码,范例：gb2312</param>
        /// <returns>TRequest.</returns>
        TRequest Encoding(string encoding);

        /// <summary>
        /// 设置内容类型
        /// </summary>
        /// <param name="contentType">内容类型</param>
        /// <returns>TRequest.</returns>
        TRequest ContentType(HttpContentType contentType);

        /// <summary>
        /// 设置内容类型
        /// </summary>
        /// <param name="contentType">内容类型</param>
        /// <returns>TRequest.</returns>
        TRequest ContentType(string contentType);

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="expiresDate">有效时间，单位：天</param>
        /// <returns>TRequest.</returns>
        TRequest Cookie(string name, string value, double expiresDate);

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="expiresDate">到期时间</param>
        /// <returns>TRequest.</returns>
        TRequest Cookie(string name, string value, DateTime expiresDate);

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="path">源服务器URL子集</param>
        /// <param name="domain">所属域</param>
        /// <param name="expiresDate">到期时间</param>
        /// <returns>TRequest.</returns>
        TRequest Cookie(string name, string value, string path = "/", string domain = null, DateTime? expiresDate = null);

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="cookie">cookie</param>
        /// <returns>TRequest.</returns>
        TRequest Cookie(Cookie cookie);

        /// <summary>
        /// 设置Bearer令牌
        /// </summary>
        /// <param name="token">令牌</param>
        /// <returns>TRequest.</returns>
        TRequest BearerToken(string token);

        /// <summary>
        /// 设置证书
        /// </summary>
        /// <param name="path">证书路径</param>
        /// <param name="password">证书密码</param>
        /// <returns>TRequest.</returns>
        TRequest Certificate(string path, string password);

        /// <summary>
        /// 超时时间
        /// </summary>
        /// <param name="timeout">超时时间,单位：秒</param>
        /// <returns>TRequest.</returns>
        TRequest Timeout(int timeout);

        /// <summary>
        /// 请求头
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns>TRequest.</returns>
        TRequest Header<T>(string key, T value);

        /// <summary>
        /// 添加参数字典
        /// </summary>
        /// <param name="parameters">参数字典</param>
        /// <returns>TRequest.</returns>
        TRequest Data(IDictionary<string, object> parameters);

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns>TRequest.</returns>
        TRequest Data(string key, object value);

        /// <summary>
        /// 添加Json参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">值</param>
        /// <returns>TRequest.</returns>
        TRequest JsonData<T>(T value);

        /// <summary>
        /// 添加Xml参数
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>TRequest.</returns>
        TRequest XmlData(string value);

        /// <summary>
        /// 请求失败回调函数
        /// </summary>
        /// <param name="action">执行失败的回调函数,参数为响应结果</param>
        /// <returns>TRequest.</returns>
        TRequest OnFail(Action<string> action);

        /// <summary>
        /// 请求失败回调函数
        /// </summary>
        /// <param name="action">执行失败的回调函数,第一个参数为响应结果，第二个参数为状态码</param>
        /// <returns>TRequest.</returns>
        TRequest OnFail(Action<string, HttpStatusCode> action);

        /// <summary>
        /// 忽略Ssl
        /// </summary>
        /// <returns>TRequest.</returns>
        TRequest IgnoreSsl();

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> ResultAsync();
    }
}
