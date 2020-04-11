using System;
using System.Threading.Tasks;
using KissU.Modules.BookStore.Samples;
using KissU.Modules.BookStore.Service.Contracts;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.BookStore.Service.Implements
{
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class SampleService : ProxyServiceBase, ISampleService
    {
        private readonly ISampleAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appService">应用服务</param>
        /// <exception cref="ArgumentNullException">appService</exception>
        public SampleService(ISampleAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        /// <summary>
        /// 获取
        /// </summary>
        public async Task<SampleDto> GetAsync()
        {
            return await _appService.GetAsync();
        }
    }
}