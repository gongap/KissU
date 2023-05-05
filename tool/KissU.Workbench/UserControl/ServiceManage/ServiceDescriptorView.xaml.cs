using HandyControl.Controls;

namespace KissU.Workbench.UserControl
{
    public partial class ServiceDescriptorView : ISingleOpen
    {
        public ServiceDescriptorView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
        }

        public bool CanDispose => true;
    }
}
