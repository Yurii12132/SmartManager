using ManagementWPF.Common.Services;
using ManagementWPF.Models;
using ManagementWPF.Services;
using ManagementWPF.ViewModels.Dialogs;
using ManagementWPF.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ManagementWPF.ViewModels
{
    class PayoutPageViewModel : BaseViewModel
    {
        private int objectId;
        IDialogService _dialogService = new DialogService();

        private void ExecuteShowAddPayoutDialog()
        {
            _dialogService.ShowDialog<AddPayoutObjectViewModel>(async result =>
            {
                if (result == true)
                {
                    await this.GetPayouts();
                }
            });
        }

        public PayoutPageViewModel()
        {
        }

        private PayoutModel _selectedPayout;
        public PayoutModel SelectedPayout
        {
            get
            {
                return _selectedPayout;
            }
            set
            {
                _selectedPayout = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<PayoutModel> _payoutList;
        public ObservableCollection<PayoutModel> PayoutList
        {
            get
            {
                return _payoutList;
            }
            set
            {
                _payoutList = value;
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
                    await this.GetPayouts();
                });
            }

        }
        private async Task GetPayouts()
        {
            this.PayoutList = await PayoutService.GetAllByObjectId(this.objectId);
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

        public ICommand AddPayout
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    ExecuteShowAddPayoutDialog();
                });
            }
        }

        public ICommand DeletePayoutList
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    DialogResult dialog = ConfirmDialog.Show();
                    if (dialog == DialogResult.Yes)
                    {
                        if (SelectedPayout != null && SelectedPayout.id > 0)
                        {
                            var result = await PayoutService.Delete(SelectedPayout.id);
                            if (result == true)
                            {
                                this.GetPayouts();
                            }
                        }
                    }
                });
            }
        }
    }
}
