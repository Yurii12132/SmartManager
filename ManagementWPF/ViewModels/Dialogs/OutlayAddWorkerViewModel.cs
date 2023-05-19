using GalaSoft.MvvmLight.Command;
using ManagementWPF.Models;
using ManagementWPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ManagementWPF.ViewModels.Dialogs
{
    class OutlayAddWorkerViewModel : BaseViewModel
    {
        private OutlayEmployeeModel _OutlayEmployeeModel = new OutlayEmployeeModel();
        public OutlayEmployeeModel outlayEmployeeModel { 
            get
            {
                return _OutlayEmployeeModel;
            }
            set
            {
                _OutlayEmployeeModel = value;
                OnPropertyChanged();
            }
        }
        public OutlayAddWorkerViewModel()
        {
            SelectedDate = DateTime.Today;
            outlayEmployeeModel.ObjectId = SharedValuesService.Object_SelectObjectId;
        }

        public ICommand OnLoaded
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    await this.GetWorkers();
                });
            }

        }

        private ObservableCollection<EmployeeModel> _workers;
        public ObservableCollection<EmployeeModel> Workers
        {
            get
            {
                return _workers;
            }
            set
            {
                _workers = value;
                OnPropertyChanged();
            }
        }

        private async Task GetWorkers()
        {
            this.Workers = await EmployeeService.GetAllByObjectId(SharedValuesService.Object_SelectObjectId);
        }

        private String _selectedItem;
        public String SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime _selectedTime;
        public DateTime SelectedTime
        {
            get
            {
                return _selectedTime;
            }
            set
            {
                _selectedTime = value;
                OnPropertyChanged();
            }
        }
        private EmployeeModel selectedEmployee;
        public EmployeeModel SelectedEmployee
        {
            get
            {
                return selectedEmployee;
            }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddWorker
        {
            get
            {
                return new DelegateCommand(async (obj) => {
                    Window qq = (obj as UserControl).Parent as Window;

                    outlayEmployeeModel.EmployeeId = SelectedEmployee.id;
                    outlayEmployeeModel.Minutes = (SelectedTime.Hour * 60) + SelectedTime.Minute;
                    outlayEmployeeModel.Date = SelectedDate;
                    var employee = await EmployeeService.Get(SelectedEmployee.id);
                    outlayEmployeeModel.Price = outlayEmployeeModel.Minutes * employee.Salary;

                    await OutlayEmployeeService.Create(outlayEmployeeModel);

                    qq.DialogResult = true;
                });
            }
        }

        public ICommand CloseWindowCommand
        {
            get
            {
                return new DelegateCommand((obj) => {
                    Window qq = (obj as UserControl).Parent as Window;

                    qq.DialogResult = false;
                });
            }
        }

        
    }
}
