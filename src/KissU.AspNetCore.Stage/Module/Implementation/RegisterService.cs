using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.ApiGateWay.ServiceDiscovery;
using KissU.ApiGateWay.ServiceDiscovery.Implementation;
using KissU.CPlatform;
using KissU.CPlatform.Ioc;
using KissU.CPlatform.Support;
using KissU.Dependency;

namespace KissU.AspNetCore.Stage.Module.Implementation
{
    /// <summary>
    /// RegisterService.
    /// Implements the <see cref="ServiceBase" />
    /// Implements the <see cref="IRegisterService" />
    /// </summary>
    /// <seealso cref="ServiceBase" />
    /// <seealso cref="IRegisterService" />
    [DisableConventionalRegistration]
    public class RegisterService : ServiceBase, IRegisterService
    {
        private readonly IServiceRegisterProvider _serviceRegisterProvider;
        private readonly IFaultTolerantProvider _faultTolerantProvider;
        private readonly IServiceSubscribeProvider _serviceSubscribeProvider;
        private readonly IServiceDiscoveryProvider _serviceDiscoveryProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterService" /> class.
        /// </summary>
        public RegisterService(IServiceRegisterProvider serviceRegisterProvider, IServiceDiscoveryProvider serviceDiscoveryProvider, IFaultTolerantProvider faultTolerantProvider,IServiceSubscribeProvider serviceSubscribeProvider )
        {
            _serviceRegisterProvider = serviceRegisterProvider;
            _faultTolerantProvider = faultTolerantProvider;
            _serviceSubscribeProvider = serviceSubscribeProvider;
            _serviceDiscoveryProvider = serviceDiscoveryProvider;
        }
        
        /// <inheritdoc />
        public async Task<IEnumerable<ServiceAddressModel>> GetRegisterAddress()
        {
            return  await _serviceRegisterProvider.GetAddressAsync();
        }
        
        /// <inheritdoc />
        public async Task<IEnumerable<ServiceAddressModel>> GetServiceAddress(string address = null)
        {
            return await _serviceDiscoveryProvider.GetServiceAddressAsync(address);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ServiceAddressModel>>  GetServiceSubscriber(string address = null)
        {
            return await _serviceSubscribeProvider.GetAddressAsync(address);
        }
        
        /// <inheritdoc />
        public async Task<IEnumerable<ServiceDescriptor>> GetServiceDescriptor(string address, string serviceId = null)
        {
            return await _serviceDiscoveryProvider.GetServiceDescriptorAsync(address, serviceId);
        }
        
        /// <inheritdoc />
        public async Task<IEnumerable<ServiceCommandDescriptor>> GetCommandDescriptor(string serviceId, string address)
        {
            IEnumerable<ServiceCommandDescriptor> result = null;
            if (!string.IsNullOrEmpty(serviceId))
            {
                result = await _faultTolerantProvider.GetCommandDescriptor(serviceId);
            }
            else if (!string.IsNullOrEmpty(address))
            {
                result = await _faultTolerantProvider.GetCommandDescriptorByAddress(address);
            }

            return result;
        }

        public async Task EditFaultTolerant(ServiceCommandDescriptor model)
        {
            await _faultTolerantProvider.SetCommandDescriptorByAddress(model);
        }
    }
}