using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.ApiGateWay.ServiceDiscovery.Implementation;
using KissU.CPlatform;
using KissU.CPlatform.Filters.Implementation;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.CPlatform.Support;
using KissU.Dependency;

namespace KissU.AspNetCore.Stage.Module
{
    /// <summary>
    /// RegisterService
    /// </summary>
    [ServiceBundle("register")]
    public interface IRegisterService : IServiceKey
    {
        /// <summary>
        /// 获取注册地址信息
        /// </summary>
        /// <returns></returns>
        [Authorization(AuthType = AuthorizationType.JWTBearer)]
        Task<IEnumerable<ServiceAddressModel>> GetRegisterAddress();

        /// <summary>
        /// 获取服务地址信息
        /// </summary>
        /// <param name="address">可选地址</param>
        /// <returns></returns>
        [Authorization(AuthType = AuthorizationType.JWTBearer)]
        Task<IEnumerable<ServiceAddressModel>> GetServiceAddress(string address = null);

        /// <summary>
        /// 获取服务订阅者
        /// </summary>
        /// <param name="address">可选地址</param>
        /// <returns></returns>
        [Authorization(AuthType = AuthorizationType.JWTBearer)]
        Task<IEnumerable<ServiceAddressModel>> GetServiceSubscriber(string address = null);

        /// <summary>
        /// 获取服务描述符
        /// </summary>
        /// <param name="address"></param>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [Authorization(AuthType = AuthorizationType.JWTBearer)]
        Task<IEnumerable<ServiceDescriptor>> GetServiceDescriptor(string address, string serviceId = null);

        /// <summary>
        /// 获取服务命令描述符
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        [Authorization(AuthType = AuthorizationType.JWTBearer)]
        Task<IEnumerable<ServiceCommandDescriptor>> GetCommandDescriptor(string serviceId, string address);

        ///// <summary>
        ///// 更新服务命令描述符
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[Authorization(AuthType = AuthorizationType.JWTBearer)]
        //Task EditFaultTolerant(ServiceCommandDescriptor model);
    }
}