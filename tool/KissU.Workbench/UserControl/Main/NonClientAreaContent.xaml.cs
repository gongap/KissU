using System.Windows;
using KissU.Workbench.Window;

namespace KissU.Workbench.UserControl.Main
{
    public partial class NonClientAreaContent
    {
        public NonClientAreaContent()
        {
            InitializeComponent();
        }

        private void MenuAbout_OnClick(object sender, RoutedEventArgs e)
        {
            new AboutWindow
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
        }
    }
}
