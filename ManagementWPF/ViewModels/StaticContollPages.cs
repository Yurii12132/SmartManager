using ManagementWPF.Views.Pages;
using ManagementWPF.Views.Pages.ObjectPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ManagementWPF.ViewModels
{
    public class StaticContollPages
    {
        private static Page _mainPage = new MainPage();
        private static Page _objectsPage = new ObjectPage();
        private static Page _closeObjectsPage = new CloseObjectsPage();
        private static Page _workersPage = new WorkersPage();
        private static Page _calculationPage = new CalculationPage();
        private static Page _settingsPage = new SettingsPage();
        private static Page _outlayPage = new OutlayPage();
        private static Page _payoutPage = new PayoutPage();
        private static Page _reportPage = new ReportPage();

        private static Page _currentPage = _mainPage;
        public static Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                OnCurrentPageChanged(EventArgs.Empty);
            }
        }

        private static double _frameOpacity = 1;
        public static double FrameOpacity
        {
            get
            {
                return _frameOpacity;
            }
            set
            {
                _frameOpacity = value;
                OnFrameOpacityChanged(EventArgs.Empty);
            }
        }

        public async static void ShowPage(string namePage)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1; i >= 0; i-=0.025)
                {
                    FrameOpacity = i;
                    Thread.Sleep(5);
                }
                switch (namePage)
                {
                    case "main_page":
                        StaticContollPages.CurrentPage = StaticContollPages._mainPage;
                        break;
                    case "object_page":
                        StaticContollPages.CurrentPage = StaticContollPages._objectsPage;
                        break;
                    case "closeObject_page":
                        StaticContollPages.CurrentPage = StaticContollPages._closeObjectsPage;
                        break;
                    case "workers_page":
                        StaticContollPages.CurrentPage = StaticContollPages._workersPage;
                        break;
                    case "calculation_page":
                        StaticContollPages.CurrentPage = StaticContollPages._calculationPage;
                        break;
                    case "settings_page":
                        StaticContollPages.CurrentPage = StaticContollPages._settingsPage;
                        break;
                    case "outlay_page":
                        StaticContollPages.CurrentPage = StaticContollPages._outlayPage;
                        break;
                    case "payout_page":
                        StaticContollPages.CurrentPage = StaticContollPages._payoutPage;
                        break;
                    case "report_page":
                        StaticContollPages.CurrentPage = StaticContollPages._reportPage;
                        break;
                }
                for (double i = 0; i <= 1; i += 0.025)
                {
                    FrameOpacity = i;
                    Thread.Sleep(5);
                }
            });            
        }

        public static event EventHandler CurrentPageChanged;

        protected static void OnCurrentPageChanged(EventArgs e)
        {
            EventHandler handler = CurrentPageChanged;

            if (handler != null)
            {
                handler(null, e);
            }
        }

        public static event EventHandler FrameOpacityChanged;

        protected static void OnFrameOpacityChanged(EventArgs e)
        {
            EventHandler handler = FrameOpacityChanged;

            if (handler != null)
            {
                handler(null, e);
            }
        }

        static StaticContollPages()
        {
            CurrentPageChanged += (sender, e) => { return; };
            FrameOpacityChanged += (sender, e) => { return; };
        }
    }
}
