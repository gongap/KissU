using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KissU.Workbench.Data;
using KissU.Workbench.Tools.Helper;
using Volo.Abp.DependencyInjection;

namespace KissU.Workbench.ViewModel.Main
{
    public class NonClientAreaViewModel : ViewModelBase, ITransientDependency
    {
        private string _versionInfo;

        public NonClientAreaViewModel()
        {
            VersionInfo = VersionHelper.GetVersion();
        }

        public RelayCommand<string> OpenViewCmd => new(OpenView);

        private void OpenView(string viewName)
        {
            Messenger.Default.Send<object>(null, MessageToken.ClearLeftSelected);
            Messenger.Default.Send(true, MessageToken.FullSwitch);
            Messenger.Default.Send(AssemblyHelper.CreateInternalInstance($"UserControl.{viewName}"), MessageToken.LoadShowContent);
        }

        public string VersionInfo
        {
            get => _versionInfo;
            set => Set(ref _versionInfo, value);
        }
    }
}
