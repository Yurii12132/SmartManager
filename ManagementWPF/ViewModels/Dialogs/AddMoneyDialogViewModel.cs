using ManagementWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ManagementWPF.ViewModels.Dialogs
{
    class AddMoneyDialogViewModel : BaseViewModel
    {
        public AddMoneyDialogViewModel()
        {
            
        }

        private PayoutInputModel _payoutInputModel;
        public PayoutInputModel PayoutInputModel
        {
            get
            {
                return _payoutInputModel;
            }
            set
            {
                _payoutInputModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddWorker
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Window window = (Window)obj;



                    window.Close();
                });
            }
        }

        public ICommand CloseWindowCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Window window = (Window)obj;
                    window.Close();
                });
            }
        }

    }
}
