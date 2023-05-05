using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using HandyControl.Tools;
using KissU.Workbench.Data;
using KissU.Workbench.Tools.Helper;
using KissU.Workbench.UserControl.Main;
using KissU.Workbench.ViewModel;
using HandyControl.Data;

namespace KissU.Workbench
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            var mainViewModel = ViewModelLocator.Instance.Main;

            DataContext = mainViewModel;
            NonClientAreaContent = new NonClientAreaContent();
            ControlMain.Content = new MainWindowContent();

            GlobalShortcut.Init(new List<KeyBinding>
            {
                new(mainViewModel.GlobalShortcutInfoCmd, Key.I, ModifierKeys.Control | ModifierKeys.Alt),
                new(mainViewModel.GlobalShortcutWarningCmd, Key.E, ModifierKeys.Control | ModifierKeys.Alt)
            });

            Dialog.SetToken(this, MessageToken.MainWindow);
            WindowAttach.SetIgnoreAltF4(this, true);

            Messenger.Default.Send(true, MessageToken.FullSwitch);
            Messenger.Default.Send(AssemblyHelper.CreateInternalInstance($"UserControl.{MessageToken.ServiceAddressView}"), MessageToken.LoadShowContent);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (GlobalData.NotifyIconIsShow)
            {
                //MessageBox.Info("托盘图标已打开，将隐藏窗口而不是关闭程序", "提示");
                NotifyIcon.ShowBalloonTip("提示", "托盘图标已打开，将隐藏窗口而不是关闭程序", NotifyIconInfoType.None, MessageToken.NotifyIconDemo);
                Hide();
                e.Cancel = true;
            }
            else
            {
                base.OnClosing(e);
            }
        }
    }
}
