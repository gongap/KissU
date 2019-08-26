using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KissU.AuthenticationServer.Attributes
{
    /// <summary>
    /// 安全头
    /// </summary>
    public class SecurityHeadersAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 执行
        /// </summary>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context == null)
                return;
            var result = context.Result;
            if (result is ViewResult == false)
                return;
            var headers = context.HttpContext?.Response?.Headers;
            if (headers == null)
                return;
            if (headers.ContainsKey("X-Content-Type-Options") == false)
                headers.Add("X-Content-Type-Options", "nosniff");
            if (headers.ContainsKey("X-Frame-Options") == false)
                headers.Add("X-Frame-Options", "SAMEORIGIN");
            var csp =
                "default-src 'self'; object-src 'none'; frame-ancestors 'none'; sandbox allow-forms allow-same-origin allow-scripts; base-uri 'self';";
            if (headers.ContainsKey("Content-Security-Policy") == false)
                headers.Add("Content-Security-Policy", csp);
            if (headers.ContainsKey("X-Content-Security-Policy") == false)
                headers.Add("X-Content-Security-Policy", csp);
            if (headers.ContainsKey("Referrer-Policy") == false)
                headers.Add("Referrer-Policy", "no-referrer");
        }
    }
}