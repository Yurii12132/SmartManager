using ManagementWPF.Views;
using ManagementWPF.Views.Pages;
using ManagementWPF.Views.Pages.ObjectPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ManagementWPF.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private double _menuItemTextOpacity;
        public double MenuItemTextOpacity
        {
            get
            {
                return _menuItemTextOpacity;
            }
            set
            {
                _menuItemTextOpacity = value;
                OnPropertyChanged();
            }
        }

        private bool _menuIsChecked;
        public bool MenuIsChecked
        {
            get
            {
                return _menuIsChecked;
            }
            set
            {
                _menuIsChecked = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            MenuItemTextOpacity = 0;
            MenuIsChecked = false;
        }

        public ICommand MenuChecked
        {
            get
            {
                return new DelegateCommand(async (IsChecked) =>
                {
                    if ((bool)IsChecked)
                    {
                        // Hide //
                        await Task.Factory.StartNew(() =>
                        {
                            for (double i = MenuItemTextOpacity; i > -0.9; i -= 0.1)
                            {
                                MenuItemTextOpacity = i;
                                Thread.Sleep(20);
                            }
                            for (double i = StaticContollPages.FrameOpacity; i < 1.1; i += 0.1)
                            {
                                StaticContollPages.FrameOpacity = i;
                                Thread.Sleep(25);
                            }
                        });
                    }
                    else
                    {
                        // Show //
                        await Task.Factory.StartNew(() =>
                        {
                            for (double i = StaticContollPages.FrameOpacity; i > 0.5; i -= 0.1)
                            {
                                StaticContollPages.FrameOpacity = i;
                                Thread.Sleep(20);
                            }
                            for (double i = MenuItemTextOpacity; i < 1.1; i += 0.1)
                            {
                                MenuItemTextOpacity = i;
                                Thread.Sleep(20);
                            }
                        });
                    }
                });
            }
        }

        public ICommand MenuSelectedItemChangedCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    ListViewItem item = obj as ListViewItem;
                    if (item != null)
                    {
                        StaticContollPages.ShowPage(item.Name);
                        if (MenuIsChecked) MenuIsChecked = false;
                    }
                });
            }
        }
    }
}
