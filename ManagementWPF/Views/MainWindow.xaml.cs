using ManagementWPF.Services;
using ManagementWPF.ViewModels;
using ManagementWPF.ViewModels.Dialogs;
using ManagementWPF.Views.Dialogs;
using ManagementWPF.Views.Pages;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManagementWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DialogService.RegisterDialog<OutlayAddWorkerDialog, OutlayAddWorkerViewModel>();
            DialogService.RegisterDialog<OutlayAddMaterialDialog, OutlayAddMaterialViewModel>();
            DialogService.RegisterDialog<PayoutAddDialog, AddPayoutObjectViewModel>();
        }

        protected override void OnClosed(EventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Header_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonHidden_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void buttonStateWindow_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void mainWindow_Navigated(object sender, NavigationEventArgs e)
        {
            mainWindow.NavigationService.RemoveBackEntry();
        }

        private void menuListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
