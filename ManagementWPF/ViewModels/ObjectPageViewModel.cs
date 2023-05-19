using ManagementWPF.Models;
using ManagementWPF.Services;
using ManagementWPF.Views.Dialogs;
using ManagementWPF.Views.Pages.ObjectPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace ManagementWPF.ViewModels
{
    class ObjectPageViewModel : BaseViewModel
    {
        private ObservableCollection<ObjectModel> _objects;
        public ObservableCollection<ObjectModel> Objects
        {
            get
            {
                return _objects;
            }
            set
            {
                _objects = value;
                OnPropertyChanged();
            }
        }

        private ObjectInformationModel _currentObject;
        public ObjectInformationModel CurrentObject { 
            get 
            {
                return _currentObject;
            }
            set 
            {
                _currentObject = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<EmployeeObjectModel> employees;
        public ObservableCollection<EmployeeObjectModel> Employees
        {
            get
            {
                return employees;
            }
            set
            {
                employees = value;
                OnPropertyChanged();
            }
        }

        public ObjectPageViewModel ()
        {
            GetObjects();
        }

        public ICommand SelectedObjectsChangedCommand
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    ObjectModel item = obj as ObjectModel;
                    if (item != null)
                    {
                        CurrentObject = await ObjectService.GetInformation(item.id);
                        ObservableCollection<EmployeeObjectModel> tempEmployees = new ObservableCollection<EmployeeObjectModel>();
                        foreach (var emp in CurrentObject.Employees)
                        {
                            EmployeeObjectModel e = new EmployeeObjectModel();
                            e.Name = emp.FullName;
                            e.CreateDate = emp.CreatedDate;
                            e.Phone = emp.Phone;

                            var outlayEmployee = await OutlayEmployeeService.GetByEmployeeId(emp.id, item.id);
                            e.Hours = outlayEmployee.Time;
                            tempEmployees.Add(e);
                        }
                        Employees = tempEmployees;
                    }
                });
            }
        }

        public ICommand ButtonClick_OutlayPage
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    SharedValuesService.Object_SelectObjectId = CurrentObject.id;
                    StaticContollPages.ShowPage("outlay_page");                 
                });
            }
        }

        public ICommand ButtonClick_PayoutPage
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    SharedValuesService.Object_SelectObjectId = CurrentObject.id;
                    StaticContollPages.ShowPage("payout_page");
                });
            }
        }
        public ICommand Button_ClosedObject
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    await ObjectService.Closed(CurrentObject);
                    this.GetObjects();
                });
            }
        }

        public ICommand ButtonClick_ReportPage
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    SharedValuesService.Object_SelectObjectId = CurrentObject.id;
                    StaticContollPages.ShowPage("report_page");
                });
            }
        }
        public ICommand ButtonClick_AddObject
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    AddObjectDialog dialog = new AddObjectDialog();
                    if (dialog.ShowDialog() == true)
                    {
                        var _objectName = SharedValuesService.objectName_AddObject;
                        await ObjectService.Create(new ObjectModel() { Name = _objectName});
                        this.GetObjects();
                    }
                });
            }
        }
        private async Task GetObjects()
        {
            Objects = await ObjectService.GetAllActive();
            CurrentObject = await ObjectService.GetInformation(Objects.FirstOrDefault().id);
            ObservableCollection<EmployeeObjectModel> tempEmployees = new ObservableCollection<EmployeeObjectModel>();
            foreach (var emp in CurrentObject.Employees)
            {
                EmployeeObjectModel e = new EmployeeObjectModel();
                e.Name = emp.FullName;
                e.CreateDate = emp.CreatedDate;
                e.Phone = emp.Phone;

                var outlayEmployee = await OutlayEmployeeService.GetByEmployeeId(emp.id, CurrentObject.id);
                e.Hours = outlayEmployee.Time;
                tempEmployees.Add(e);
            }
            Employees = tempEmployees;
        }

    }
}
