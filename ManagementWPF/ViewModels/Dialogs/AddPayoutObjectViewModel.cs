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
    class AddPayoutObjectViewModel : BaseViewModel
    {
        public AddPayoutObjectViewModel()
        {
            SelectDate = DateTime.Today;
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

        public ICommand OnLoaded
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    
                });
            }

        }

        public ICommand AddCommand
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    Window qq = (obj as UserControl).Parent as Window;

                    PayoutModel model = new PayoutModel() { Name = Name, Price = Price, Date = SelectDate, FileId = null, ObjectId = SharedValuesService.Object_SelectObjectId };

                    await PayoutService.Create(model);

                    qq.DialogResult = true;
                });
            }

        }

        public ICommand CloseWindowCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Window qq = (obj as UserControl).Parent as Window;

                    qq.DialogResult = false;
                });
            }
        }



    }
}