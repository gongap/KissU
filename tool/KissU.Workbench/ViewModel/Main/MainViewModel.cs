using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KissU.Workbench.Data;
using HandyControl.Controls;
using KissU.Dependency;

namespace KissU.Workbench.ViewModel.Main
{
    public class MainViewModel : ViewModelBase, ITransientDependency
    {
        /// <summary>
        ///     内容标题
        /// </summary>
        private string _contentTitle;

        /// <summary>
        ///     子内容
        /// </summary>
        private object _subContent;

        public MainViewModel()
        {
            UpdateMainContent();
        }

        public RelayCommand GlobalShortcutInfoCmd => new(() => Growl.Info("Global Shortcut Info"));

        public RelayCommand GlobalShortcutWarningCmd => new(() => Growl.Warning("Global Shortcut Warning"));


        /// <summary>
        ///     子内容
        /// </summary>
        public object SubContent
        {
            get => _subContent;
            set => Set(ref _subContent, value);
        }

        /// <summary>
        ///     内容标题
        /// </summary>
        public string ContentTitle
        {
            get => _contentTitle;
            set => Set(ref _contentTitle, value);
        }

        private void UpdateMainContent()
        {
            ContentTitle = "服务管理";
            Messenger.Default.Register<object>(this, MessageToken.LoadShowContent, obj =>
            {
                if (SubContent is IDisposable disposable)
                {
                    disposable.Dispose();
                }

                SubContent = obj;
            }, true);
        }
        
        public RelayCommand ShutdownApp => new(() =>
        {
            GlobalData.NotifyIconIsShow = false;
            Application.Current.Shutdown();
        });
    }
}
