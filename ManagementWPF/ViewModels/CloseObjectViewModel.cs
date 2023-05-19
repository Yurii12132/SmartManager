using ManagementWPF.Models;
using ManagementWPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ManagementWPF.ViewModels
{
    class CloseObjectViewModel : BaseViewModel
    {
        public CloseObjectViewModel()
        {

        }
        private ObservableCollection<CloseObjectModel> objects;
        public ObservableCollection<CloseObjectModel> Objects
        {
            get
            {
                return objects;
            }
            set
            {
                objects = value;
                OnPropertyChanged();
            }
        }
        public ICommand OnLoaded
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    var entityObjects = await ObjectService.GetAllClosed();

                    ObservableCollection<CloseObjectModel> temp = new ObservableCollection<CloseObjectModel>();
                    foreach (var o in entityObjects)
                    {
                        CloseObjectModel closeObjectModel = new CloseObjectModel();
                        closeObjectModel.id = o.id;
                        closeObjectModel.Name = o.Name;
                        var outlayEmployee = await OutlayEmployeeService.GetAllByObjectId(o.id);
                        foreach (var item in outlayEmployee)
                        {
                            closeObjectModel.Outlay += item.Price;
                        }
                        var outlayMaterial = await OutlayEmployeeService.GetAllByObjectId(o.id);
                        foreach (var item in outlayMaterial)
                        {
                            closeObjectModel.Outlay += item.Price;
                        }

                        var payout = await PayoutService.GetAllByObjectId(o.id);
                        foreach (var item in payout)
                        {
                            closeObjectModel.Payout += item.Price;
                        }

                        closeObjectModel.Income = closeObjectModel.Payout - closeObjectModel.Outlay;
                        closeObjectModel.DatePeriod = o.CreateDate.ToString("dd.MM.yyyy") + "-" + o.CloseDate.ToString("dd.MM.yyyy");
                        temp.Add(closeObjectModel);
                    }

                    Objects = temp;
                });
            }

        }
    }
}
