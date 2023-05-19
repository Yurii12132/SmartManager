using ManagementWPF.Common.Services;
using ManagementWPF.Models;
using ManagementWPF.Services;
using ManagementWPF.ViewModels.Dialogs;
using ManagementWPF.Views.Dialogs;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ManagementWPF.ViewModels
{
    class OutlayPageViewModel : BaseViewModel
    {
        IDialogService _dialogService = new DialogService();

        private void ExecuteShowAddWorkerDialog()
        {
            _dialogService.ShowDialog<OutlayAddWorkerViewModel>(async result =>
            {
                if (result == true)
                {
                    await this.GetOutlayEmployees(this.objectId);
                }
            });
        }

        private void ExecuteShowAddMaterialDialog()
        {
            _dialogService.ShowDialog<OutlayAddMaterialViewModel>(async result =>
            {
                if (result == true)
                {
                    await this.GetOutlayMaterials(this.objectId);
                }
            });
        }

        private int objectId;

        private OutlayEmployeeOutputModel _selectedOutlayEmployee;
        public OutlayEmployeeOutputModel SelectedOutlayEmployee
        {
            get
            {
                return _selectedOutlayEmployee;
            }
            set
            {
                _selectedOutlayEmployee = value;
                OnPropertyChanged();
            }
        }
        private OutlayMaterialModel _selectedOutlayMaterial;
        public OutlayMaterialModel SelectedOutlayMaterial
        {
            get
            {
                return _selectedOutlayMaterial;
            }
            set
            {
                _selectedOutlayMaterial = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<OutlayEmployeeOutputModel> _outlayWorkerModels;
        public ObservableCollection<OutlayEmployeeOutputModel> OutlayWorkerModels
        {
            get
            {
                return _outlayWorkerModels;
            }
            set
            {
                _outlayWorkerModels = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<OutlayMaterialModel> _outlayMaterialModels;
        public ObservableCollection<OutlayMaterialModel> OutlayMaterialModels
        {
            get
            {
                return _outlayMaterialModels;
            }
            set
            {
                _outlayMaterialModels = value;
                OnPropertyChanged();
            }
        }

        public ICommand DeleteWorkerOutlayList
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    DialogResult dialog = ConfirmDialog.Show();
                    if (dialog == DialogResult.Yes)
                    {
                        if (SelectedOutlayEmployee != null && SelectedOutlayEmployee.EmployeeId > 0)
                        {
                            await OutlayEmployeeService.Delete(SelectedOutlayEmployee.id);
                            this.GetOutlayEmployees(this.objectId);
                        }
                    }
                });
            }
        }

        public ICommand AddWorkerOutlayList
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    ExecuteShowAddWorkerDialog();
                });
            }
        }

        public ICommand AddMaterialOutlayList
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    ExecuteShowAddMaterialDialog();
                });
            }
        }

        public ICommand DeleteMaterialOutlayList
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    DialogResult dialog = ConfirmDialog.Show();
                    if (dialog == DialogResult.Yes)
                    {
                        if (SelectedOutlayMaterial != null && SelectedOutlayMaterial.id > 0)
                        {
                            await OutlayMaterialService.Delete(SelectedOutlayMaterial.id);
                            this.GetOutlayMaterials(this.objectId);
                        }
                    }
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

        public OutlayPageViewModel()
        {

        }

        public ICommand OnLoaded
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    this.objectId = SharedValuesService.Object_SelectObjectId;
                    await GetOutlayEmployees(this.objectId);
                    await GetOutlayMaterials(this.objectId);
                });
            }

        }
        private async Task GetOutlayEmployees(int objectId)
        {
            this.OutlayWorkerModels = await OutlayEmployeeService.GetAllByObjectId(objectId);
        }
        private async Task GetOutlayMaterials(int objectId)
        {
            this.OutlayMaterialModels = await OutlayMaterialService.GetAllByObjectId(objectId);
        }

    }
}
