﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using KissU.Core.ApiGateWay;
using KissU.Core.ApiGateWay.OAuth;
using KissU.Core.CPlatform;
using KissU.Core.CPlatform.Filters.Implementation;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Utilities;
using KissU.Core.KestrelHttpServer.Filters;
using KissU.Core.KestrelHttpServer.Filters.Implementation;

namespace KissU.Core.Stage.Filters
{
    /// <summary>
    /// ActionFilterAttribute.
    /// Implements the <see cref="KissU.Core.KestrelHttpServer.Filters.IActionFilter" />
    /// </summary>
    /// <seealso cref="KissU.Core.KestrelHttpServer.Filters.IActionFilter" />
    public class ActionFilterAttribute : IActionFilter
    {
        private readonly IAuthorizationServerProvider _authorizationServerProvider;
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionFilterAttribute"/> class.
        /// </summary>
        public ActionFilterAttribute()
        {
            _authorizationServerProvider = ServiceLocator.Current.Resolve<IAuthorizationServerProvider>();
        }

        /// <summary>
        /// Called when [action executed].
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <returns>Task.</returns>
        public Task OnActionExecuted(ActionExecutedContext filterContext)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called when [action executing].
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <returns>Task.</returns>
        public async Task OnActionExecuting(ActionExecutingContext filterContext)
        {
            var gatewayAppConfig = AppConfig.Options.ApiGetWay;
            if (filterContext.Message.RoutePath == gatewayAppConfig.AuthorizationRoutePath)
            {
                var token = await _authorizationServerProvider.GenerateTokenCredential(new Dictionary<string, object>(filterContext.Message.Parameters));
                if (token != null)
                {
                    filterContext.Result = HttpResultMessage<object>.Create(true, token);
                    filterContext.Result.StatusCode = (int)ServiceStatusCode.Success;
                }
                else
                {
                    filterContext.Result = new HttpResultMessage<object> { IsSucceed = false, StatusCode = (int)ServiceStatusCode.AuthorizationFailed, Message = "Invalid authentication credentials" };
                }
            }
            else if (filterContext.Route.ServiceDescriptor.AuthType() == AuthorizationType.AppSecret.ToString())
            {
                if (!ValidateAppSecretAuthentication(filterContext, out HttpResultMessage<object> result))
                {
                    filterContext.Result = result;
                }
            }
        }

        private bool ValidateAppSecretAuthentication(ActionExecutingContext filterContext, out HttpResultMessage<object> result)
        {
            bool isSuccess = true;
            DateTime time;
            result = HttpResultMessage<object>.Create(true,null);
            var author = filterContext.Context.Request.Headers["Authorization"];
            var model = filterContext.Message.Parameters;
            var route = filterContext.Route;
            if (model.ContainsKey("timeStamp") && author.Count > 0)
            {
                if (long.TryParse(model["timeStamp"].ToString(), out long timeStamp))
                {
                    time = DateTimeConverter.UnixTimestampToDateTime(timeStamp);
                    var seconds = (DateTime.Now - time).TotalSeconds;
                    if (seconds <= 3560 && seconds >= 0)
                    {
                        if (GetMD5($"{route.ServiceDescriptor.Token}{time.ToString("yyyy-MM-dd hh:mm:ss") }") != author.ToString())
                        {
                            result = new HttpResultMessage<object> { IsSucceed = false, StatusCode = (int)ServiceStatusCode.AuthorizationFailed, Message = "Invalid authentication credentials" };
                            isSuccess = false;
                        }
                    }
                    else
                    {
                        result = new HttpResultMessage<object> { IsSucceed = false, StatusCode = (int)ServiceStatusCode.AuthorizationFailed, Message = "Invalid authentication credentials" };
                        isSuccess = false;
                    }
                }
                else
                {
                    result = new HttpResultMessage<object> { IsSucceed = false, StatusCode = (int)ServiceStatusCode.AuthorizationFailed, Message = "Invalid authentication credentials" };
                    isSuccess = false;
                }
            }
            else
            {
                result = new HttpResultMessage<object> { IsSucceed = false, StatusCode = (int)ServiceStatusCode.RequestError, Message = "Request error" };
                isSuccess = false;
            }
            return isSuccess;
        }

        /// <summary>
        /// Gets the m d5.
        /// </summary>
        /// <param name="encypStr">The encyp string.</param>
        /// <returns>System.String.</returns>
        public string GetMD5(string encypStr)
        {
            try
            {
                var md5 = MD5.Create();
                var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(encypStr));
                var sb = new StringBuilder();
                foreach (byte b in bs)
                {
                    sb.Append(b.ToString("X2"));
                } 
                return sb.ToString().ToLower();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}
