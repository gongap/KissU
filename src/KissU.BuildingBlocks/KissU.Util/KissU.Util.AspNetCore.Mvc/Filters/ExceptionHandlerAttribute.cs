﻿using KissU.Core;
using KissU.Core.Commons;
using KissU.Util.AspNetCore.Mvc.Commons;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KissU.Util.AspNetCore.Mvc.Filters
{
    /// <summary>
    /// 异常处理过滤器
    /// </summary>
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            context.Result = new Result(StateCode.Fail, context.Exception.GetPrompt());
        }
    }
}