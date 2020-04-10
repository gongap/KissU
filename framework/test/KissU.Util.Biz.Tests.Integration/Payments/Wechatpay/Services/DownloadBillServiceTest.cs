using System.Threading.Tasks;
using KissU.Core;
using KissU.Util.Biz.Payments.Wechatpay.Parameters.Requests;
using KissU.Util.Biz.Payments.Wechatpay.Services;
using KissU.Util.Biz.Tests.Integration.Payments.Wechatpay.Configs;
using Xunit;

namespace KissU.Util.Biz.Tests.Integration.Payments.Wechatpay.Services
{
    /// <summary>
    /// 下载对账单服务测试
    /// </summary>
    public class DownloadBillServiceTest
    {
        /// <summary>
        /// 测试下载对账单
        /// </summary>
        [Fact(Skip = "更改支付配置后测试")]
        public async Task TestDownloadAsync()
        {
            var service = new WechatpayDownloadBillService(new TestConfigProvider());
            var request = new WechatpayDownloadBillRequest
            {
                BillDate = "2020-3-25".ToDate()
            };
            var result = await service.DownloadAsync(request);
            Assert.NotEmpty(result.Bills);
        }
    }
}
