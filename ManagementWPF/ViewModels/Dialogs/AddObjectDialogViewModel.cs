using ManagementWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ManagementWPF.ViewModels.Dialogs
{
    class AddObjectDialogViewModel : BaseViewModel
    {
        private string _objectName;
        public string ObjectName
        {
            get
            {
                return _objectName;
            }
            set
            {
                _objectName = value;
                OnPropertyChanged();
            }
        }

        public AddObjectDialogViewModel()
        {
            ObjectName = "";
        }

        public ICommand CloseWindowCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Window window = (Window)obj;
                    window.DialogResult = false;
                    window.Close();
                });
            }
        }

        public ICommand AddObjectWindowCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    if (!string.IsNullOrWhiteSpace(ObjectName))
                    {
                        Window window = (Window)obj;
                        window.DialogResult = true;
                        SharedValuesService.objectName_AddObject = ObjectName;
                        window.Close();
                    }
                });
            }
        }

    }
}
