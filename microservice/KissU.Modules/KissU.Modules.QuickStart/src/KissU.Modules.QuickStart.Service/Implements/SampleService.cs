using System;
using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Modules.QuickStart.Samples;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.QuickStart.Service.Implements
{
    [ModuleName("Sample")]
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