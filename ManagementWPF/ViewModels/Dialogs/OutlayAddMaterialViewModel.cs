using ManagementWPF.Models;
using ManagementWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ManagementWPF.ViewModels.Dialogs
{
    class OutlayAddMaterialViewModel : BaseViewModel
    {

        private OutlayMaterialModel outlayMaterialModel = new OutlayMaterialModel();
        public OutlayMaterialModel OutlayMaterialModel
        {
            get
            {
                return outlayMaterialModel;
            }
            set
            {
                outlayMaterialModel = value;
                OnPropertyChanged();
            }
        }
        private DateTime selectDate;
        public DateTime SelectDate
        {
            get
            {
                return selectDate;
            }
            set
            {
                selectDate = value;
                OnPropertyChanged();
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }
        public OutlayAddMaterialViewModel()
        {
            this.selectDate = DateTime.Now;
        }

        public ICommand OnLoaded
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    
                });
            }

        }

        public ICommand AddMaterial
        {
            get
            {
                return new DelegateCommand(async (obj) => {
                    Window qq = (obj as UserControl).Parent as Window;

                    OutlayMaterialModel model = new OutlayMaterialModel();

                    model.Name = Name;
                    model.Date = SelectDate;
                    model.Price = Price;
                    model.ObjectId = SharedValuesService.Object_SelectObjectId;

                    await OutlayMaterialService.Create(model);

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
