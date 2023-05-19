using ManagementWPF.Common.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IDialogService = ManagementWPF.Common.Services.IDialogService;

namespace ManagementWPF.Services
{
    class DialogService : IDialogService
    {
        static Dictionary<Type, Type> _mapings = new Dictionary<Type, Type>();
        public static void RegisterDialog<TView, TViewModel>() 
        {
            _mapings.Add(typeof(TViewModel), typeof(TView));
        }
            
        public void ShowDialog<TViewModel>(Action<bool> callback)
        {
            var type = _mapings[typeof(TViewModel)];
            ShowDialogInternal(type, callback, typeof(TViewModel));
        }

        private static void ShowDialogInternal(Type type, Action<bool> callback, Type vmType)
        {
            var dialog = new Prism.Services.Dialogs.DialogWindow();

            EventHandler closeEventHandler = null;
            closeEventHandler = (s, e) =>
            {
                callback((bool)dialog.DialogResult);
                dialog.Closed -= closeEventHandler;
            };
            dialog.Closed += closeEventHandler;

            var content = Activator.CreateInstance(type);

            if (vmType != null)
            {
                var vm = Activator.CreateInstance(vmType);
                (content as FrameworkElement).DataContext = vm;
            }

            dialog.Content = content;

            dialog.Background = System.Windows.Media.Brushes.Transparent;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dialog.WindowStyle = WindowStyle.None;
            dialog.ResizeMode = ResizeMode.NoResize;
            dialog.AllowsTransparency = true;
            dialog.ShowDialog();
        }
    }
}
