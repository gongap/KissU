using KissU.Caching.Interceptors;

namespace KissU.Modules.Identity.Service.Contracts.Dtos
{
    /// <summary>
    /// Class FindUserInput.
    /// </summary>
    public class FindUserInput
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [CacheKey(0)]
        public string UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [CacheKey(1)]
        public string UserName { get; set; }
    }
}
