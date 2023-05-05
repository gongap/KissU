using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using KissU.ApiGateWay.ServiceDiscovery;
using KissU.ApiGateWay.ServiceDiscovery.Implementation;
using KissU.Dependency;

namespace KissU.Workbench.ViewModel.ServiceManage
{
    public class ServiceAddressViewModel : ViewModelBase, ITransientDependency
    {
        public ServiceAddressViewModel(IServiceDiscoveryProvider serviceDiscoveryProvider)
        {
            ////AsyncHelper.RunSync(async () =>
            ////{
            ////    var services = await serviceDiscoveryProvider.GetServiceAddressAsync();
            ////    Services = new ObservableCollection<ServiceAddressModel>(services);
            ////});
        }

        public ObservableCollection<ServiceAddressModel> Services { get; set; } = new ObservableCollection<ServiceAddressModel>();
    }
}
