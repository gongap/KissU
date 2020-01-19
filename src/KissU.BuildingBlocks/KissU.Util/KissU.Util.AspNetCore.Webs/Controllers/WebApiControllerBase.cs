using KissU.Util.AspNetCore.Webs.Commons;
using KissU.Util.AspNetCore.Webs.Filters;
using KissU.Util.Logs;
using KissU.Util.Properties;
using KissU.Util.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace KissU.Util.AspNetCore.Webs.Controllers
{
    /// <summary>
    /// WebApi控制器
    /// </summary>
    [Route("api/[controller]")]
    [ExceptionHandler]
    [ErrorLog]
    [TraceLog]
    public abstract partial class WebApiControllerBase : Controller
    {
        /// <summary>
        /// 日志
        /// </summary>
        private ILog _log;

        /// <summary>
        /// 日志
        /// </summary>
        public ILog Log => _log ?? (_log = GetLog());

        /// <summary>
        /// 获取日志操作
        /// </summary>
        protected virtual ILog GetLog()
        {
            try
            {
                return Util.Logs.Log.GetLog(this);
            }
            catch
            {
                return Util.Logs.Log.Null;
            }
        }

        /// <summary>
        /// 会话
        /// </summary>
        public virtual ISession Session => AspNetCore.Sessions.Session.Instance;

        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        protected virtual IActionResult Success(dynamic data = null, string message = null)
        {
            if (message == null)
                message = R.Success;
            return new Result(StateCode.Ok, message, data);
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        protected virtual IActionResult Fail(string message)
        {
            return new Result(StateCode.Fail, message);
        }
    }
}