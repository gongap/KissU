﻿using System.Net.Http;
using KissU.Core.Clients;

namespace KissU.Util.AspNetCore.Clients
{
    /// <summary>
    /// Web客户端
    /// </summary>
    public class WebClient
    {
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns>IHttpRequest.</returns>
        public IHttpRequest Get(string url)
        {
            return new HttpRequest(HttpMethod.Get, url);
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns>IHttpRequest.</returns>
        public IHttpRequest Post(string url)
        {
            return new HttpRequest(HttpMethod.Post, url);
        }

        /// <summary>
        /// Put请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns>IHttpRequest.</returns>
        public IHttpRequest Put(string url)
        {
            return new HttpRequest(HttpMethod.Put, url);
        }

        /// <summary>
        /// Delete请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns>IHttpRequest.</returns>
        public IHttpRequest Delete(string url)
        {
            return new HttpRequest(HttpMethod.Delete, url);
        }
    }

    /// <summary>
    /// Web客户端
    /// </summary>
    /// <typeparam name="TResult">返回的结果类型</typeparam>
    public class WebClient<TResult> where TResult : class
    {
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns>IHttpRequest&lt;TResult&gt;.</returns>
        public IHttpRequest<TResult> Get(string url)
        {
            return new HttpRequest<TResult>(HttpMethod.Get, url);
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns>IHttpRequest&lt;TResult&gt;.</returns>
        public IHttpRequest<TResult> Post(string url)
        {
            return new HttpRequest<TResult>(HttpMethod.Post, url);
        }

        /// <summary>
        /// Put请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns>IHttpRequest&lt;TResult&gt;.</returns>
        public IHttpRequest<TResult> Put(string url)
        {
            return new HttpRequest<TResult>(HttpMethod.Put, url);
        }

        /// <summary>
        /// Delete请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns>IHttpRequest&lt;TResult&gt;.</returns>
        public IHttpRequest<TResult> Delete(string url)
        {
            return new HttpRequest<TResult>(HttpMethod.Delete, url);
        }
    }
}