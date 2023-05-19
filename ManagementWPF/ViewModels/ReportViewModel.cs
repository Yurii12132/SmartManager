using ManagementWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ManagementWPF.ViewModels
{
    class ReportViewModel : BaseViewModel
    {
        private int objectId;
        public ReportViewModel()
        {

        }

        private double payoutObject;
        public double PayoutObject
        {
            get
            {
                return payoutObject;
            }
            set
            {
                payoutObject = value;
                OnPropertyChanged();
            }
        }
        private double outlayEmployee;
        public double OutlayEmployee
        {
            get
            {
                return outlayEmployee;
            }
            set
            {
                outlayEmployee = value;
                OnPropertyChanged();
            }
        }
        private double income;
        public double Income
        {
            get
            {
                return income;
            }
            set
            {
                income = value;
                OnPropertyChanged();
            }
        }
        private int countWorkers;
        public int CountWorkers
        {
            get
            {
                return countWorkers;
            }
            set
            {
                countWorkers = value;
                OnPropertyChanged();
            }
        }


        public ICommand OnLoaded
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    this.objectId = SharedValuesService.Object_SelectObjectId;
                    var qq = await EmployeeService.GetAllByObjectId(this.objectId);

                    CountWorkers = qq.Count;
                });
            }

        }

        public ICommand BackPage
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    StaticContollPages.ShowPage("object_page");
                });
            }
        }

        public ICommand GenerateExcel
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    
                });
            }
        }

    }
}
