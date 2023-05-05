using System.Windows;
using System.Windows.Input;
using KissU.ApiGateWay.ServiceDiscovery.Implementation;
using KissU.Workbench.ViewModel;
using HandyControl.Controls;
using HandyControl.Tools;

namespace KissU.Workbench.UserControl
{
    public partial class ServiceAddressView
    {
        public ServiceAddressView()
        {
            InitializeComponent();
        }

        private void DataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataGrid.SelectedItem is ServiceAddressModel  serviceAddress)
            {
                var address = serviceAddress.Address.ToString();
                var view = SingleOpenHelper.CreateControl<ServiceDescriptorView>();
                var viewModel = ViewModelLocator.Instance.ServiceDescriptor;
                viewModel.Address = address;
                view.DataContext = viewModel;
                var window = new PopupWindow
                {
                    Title = $"{serviceAddress.Address.Name} [{address}]",
                    PopupElement = view,
                    ResizeMode = ResizeMode.CanResizeWithGrip,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                    AllowsTransparency = true,
                    WindowStyle = WindowStyle.None,
                    MaxWidth = 1000,
                    MaxHeight = 700,
                };

                window.Show();
            }
        }
    }
}
