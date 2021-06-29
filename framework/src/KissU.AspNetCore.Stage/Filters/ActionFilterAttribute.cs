using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using KissU.ApiGateWay;
using KissU.ApiGateWay.OAuth;
using KissU.AspNetCore.Filters;
using KissU.CPlatform;
using KissU.CPlatform.Filters.Implementation;
using KissU.CPlatform.Messages;
using KissU.Dependency;
using KissU.Helpers;

namespace KissU.AspNetCore.Stage.Filters
{
    /// <summary>
    /// ActionFilterAttribute.
    /// Implements the <see cref="IActionFilter" />
    /// </summary>
    /// <seealso cref="IActionFilter" />
    public class ActionFilterAttribute : IActionFilter
    {
        private readonly IAuthorizationServerProvider _authorizationServerProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionFilterAttribute" /> class.
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
                    filterContext.Result.StatusCode = (int) ServiceStatusCode.Success;
                }
                else
                {
                    filterContext.Result = new HttpResultMessage<object>
                    {
                        IsSucceed = false, StatusCode = (int) ServiceStatusCode.RequestError,
                        Message = "Generates the token credential failed!"
                    };
                }
            }
            else if (filterContext.Route.ServiceDescriptor.AuthType() == AuthorizationType.AppSecret.ToString() || filterContext.Route.ServiceDescriptor.AuthType() == AuthorizationType.JwtSecret.ToString())
            {
                if (!string.IsNullOrWhiteSpace(filterContext.Route.ServiceDescriptor.Token))
                {
                    if (!ValidateAppSecretAuthentication(filterContext, out var result))
                    {
                        filterContext.Result = result;
                    }
                }
            }
        }

        private bool ValidateAppSecretAuthentication(ActionExecutingContext filterContext, out HttpResultMessage<object> result)
        {
            DateTime time;
            result = HttpResultMessage<object>.Create(true, null);
            var appSecretValues = filterContext.Context.Request.Headers["AppSecret"];
            var timestampValues = filterContext.Context.Request.Headers["Timestamp"];
            var route = filterContext.Route;
            if (appSecretValues.Count > 0 && timestampValues.Count > 0)
            {
                if (long.TryParse(timestampValues.ToString(), out var timestamp))
                {
                    time = TimeHelper.UnixTimestampToDateTime(timestamp, DateTime.UtcNow);
                    var seconds = Math.Abs((DateTime.UtcNow - time).TotalSeconds);
                    if (seconds <= 3560 && seconds >= 0)
                    {
                        if (GetMD5($"{route.ServiceDescriptor.Token}{time.ToString("yyyy-MM-dd HH:mm:ss")}") == appSecretValues.ToString())
                        {
                            return true;
                        }
                    }
                }
            }

            result = new HttpResultMessage<object>
            {
                IsSucceed = false,
                StatusCode = (int)ServiceStatusCode.AuthorizationFailed,
                Message = "身份验证凭据无效"
            };

            return false;
        }

        private string GetMD5(string encypStr)
        {
            try
            {
                var md5 = MD5.Create();
                var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(encypStr));
                var sb = new StringBuilder();
                foreach (var b in bs)
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