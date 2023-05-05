using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using KissU.ApiGateWay.ServiceDiscovery;
using KissU.CPlatform;
using KissU.CPlatform.Support;
using KissU.Dependency;
using KissU.Workbench.Models;

namespace KissU.Workbench.ViewModel.ServiceManage
{
    public class ServiceDescriptorViewModel : ViewModelBase, ITransientDependency
    {
        private string _address;
        private readonly IServiceDiscoveryProvider _serviceDiscoveryProvider;
        private readonly IFaultTolerantProvider _faultTolerantProvider;
        private IEnumerable<ServiceDescriptor> _serviceDescriptors;
        private IEnumerable<ServiceCommandDescriptor> _commandDescriptors;

        public ServiceDescriptorViewModel(IServiceDiscoveryProvider serviceDiscoveryProvider,IFaultTolerantProvider  faultTolerantProvider)
        {
            _serviceDiscoveryProvider = serviceDiscoveryProvider;
            _faultTolerantProvider = faultTolerantProvider;
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                //_serviceDescriptors = _serviceDiscoveryProvider.GetServiceDescriptorAsync(_address).Result;
                //_commandDescriptors =_faultTolerantProvider.GetCommandDescriptorByAddress(_address).Result;
                //foreach (var serviceDescriptor in _serviceDescriptors)
                //{
                //    var descriptor = new Descriptor
                //    {
                //        ServiceDescriptor = serviceDescriptor,
                //        CommandDescriptor = _commandDescriptors.FirstOrDefault(x=>x.ServiceId == serviceDescriptor.Id) ?? new ServiceCommandDescriptor(),
                //    };

                //    ServiceDescriptors.Add(descriptor);
                //}
            }
        }

        public ObservableCollection<Descriptor> ServiceDescriptors { get; set; } = new ObservableCollection<Descriptor>();
    };
}
