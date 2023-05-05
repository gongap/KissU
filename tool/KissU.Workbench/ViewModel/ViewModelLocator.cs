using System;
using System.Windows;
using KissU.Workbench.ViewModel.Main;
using KissU.Workbench.ViewModel.ServiceManage;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Workbench.ViewModel
{
    public class ViewModelLocator
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public void Init(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public static ViewModelLocator Instance = new Lazy<ViewModelLocator>(() => Application.Current.TryFindResource("Locator") as ViewModelLocator).Value;

        #region Vm

        public MainViewModel Main => ServiceProvider.GetService<MainViewModel>();

        public NonClientAreaViewModel NoUser =>  ServiceProvider.GetService<NonClientAreaViewModel>();

        public ServiceAddressViewModel ServiceAddress =>  ServiceProvider.GetService<ServiceAddressViewModel>();

        public ServiceDescriptorViewModel ServiceDescriptor =>  ServiceProvider.GetService<ServiceDescriptorViewModel>();

        #endregion
    }
}
