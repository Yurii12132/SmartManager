using ManagementWPF.Models;
using ManagementWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ManagementWPF.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            CountClosedObjects = 0;
            CountActiveObjects = 0;
        }

        private int countClosedObjects;
        public int CountClosedObjects
        {
            get
            {
                return countClosedObjects;
            }
            set
            {
                countClosedObjects = value;
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

        private int countActiveObjects;
        public int CountActiveObjects
        {
            get
            {
                return countActiveObjects;
            }
            set
            {
                countActiveObjects = value;
                OnPropertyChanged();
            }
        }
        private List<ChartCloseObjectModel> closeObjects;
        public List<ChartCloseObjectModel> CloseObjects
        {
            get
            {
                return closeObjects;
            }
            set
            {
                closeObjects = value;
                OnPropertyChanged();
            }
        }
        public ICommand OnLoaded
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    var closedObjects = await ObjectService.GetAllClosed();
                    var activeObjects = await ObjectService.GetAllActive();
                    CountClosedObjects = closedObjects.Count;
                    CountActiveObjects = activeObjects.Count;

                    List<ChartCloseObjectModel> chars = new List<ChartCloseObjectModel>();
                    foreach (var o in closedObjects)
                    {
                        //get all outlay
                        double outlay = 0;
                        var outlayMaterials = await OutlayMaterialService.GetAllByObjectId(o.id);
                        foreach (var item in outlayMaterials)
                        {
                            outlay += item.Price;
                        }

                        var outlayEmployee = await OutlayEmployeeService.GetAllByObjectId(o.id);
                        foreach (var item in outlayEmployee)
                        {
                            outlay += item.Price;
                        }

                        //get all payout
                        double payout = 0;
                        var payouts = await PayoutService.GetAllByObjectId(o.id);
                        foreach (var item in payouts)
                        {
                            payout += item.Price;
                        }

                        //calculate income
                        ChartCloseObjectModel chartCloseObjectModel = new ChartCloseObjectModel();
                        chartCloseObjectModel.Name = o.Name;
                        chartCloseObjectModel.Income = payout - outlay;
                        chars.Add(chartCloseObjectModel);

                        
                    }
                    CloseObjects = chars;

                    var qq = await EmployeeService.GetAll();

                    CountWorkers = qq.Count;
                });
            }

        }

    }
}
