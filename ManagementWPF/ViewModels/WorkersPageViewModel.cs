using ManagementWPF;
using ManagementWPF.Models;
using ManagementWPF.Services;
using ManagementWPF.Views;
using ManagementWPF.Views.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ManagementWPF.ViewModels
{
    class WorkersPageViewModel : BaseViewModel
    {
        private ObservableCollection<EmployeeModel> _wordekCards;
        public ObservableCollection<EmployeeModel> WorkerCards
        {
            get
            {
                return _wordekCards;
            }
            set
            {
                _wordekCards = value;
                OnPropertyChanged();
            }
        }

        private EmployeeModel _currentWorker;
        public EmployeeModel CurrentWorker
        {
            get
            {
                return _currentWorker;
            }
            set
            {
                _currentWorker = value;
                OnPropertyChanged();
            }
        }

        private string firstName;
        public string FirstName { 
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }
        private double salary;
        public double Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
                OnPropertyChanged();
            }
        }
        private string specialization;
        public string Specialization
        {
            get
            {
                return specialization;
            }
            set
            {
                specialization = value;
                OnPropertyChanged();
            }
        }
        private string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged();
            }
        }
        private string detailInformation;
        public string DetailInformation
        {
            get
            {
                return detailInformation;
            }
            set
            {
                detailInformation = value;
                OnPropertyChanged();
            }
        }
        private string image;
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }
        private string education;
        public string Education {
            get
            {
                return education;
            }
            set
            {
                education = value;
                OnPropertyChanged();
            } }
        private string recidence;
        public string Recidence {
            get
            {
                return recidence;
            }
            set
            {
                recidence = value;
                OnPropertyChanged();
            }
        }
        private string seniotity;
        public string Seniority { 
            get
            {
                return seniotity;
            }
            set
            {
                seniotity = value;
                OnPropertyChanged();
            }
        }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        private enum Pages
        {
            WorkersPanel,
            AddWorker,
            AccountWorker
        }

        private Visibility _workersPanelVisibility;
        public Visibility WorkersPanelVisibility
        {
            get
            {
                return _workersPanelVisibility;
            }
            set
            {
                _workersPanelVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _addWorkerVisibility;
        public Visibility AddWorkerVisibility
        {
            get
            {
                return _addWorkerVisibility;
            }
            set
            {
                _addWorkerVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _accountWorkerVisibility;
        public Visibility AccountWorkerVisibility
        {
            get
            {
                return _accountWorkerVisibility;
            }
            set
            {
                _accountWorkerVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility btnCreateVisibility;
        public Visibility BtnCreateVisibility
        {
            get
            {
                return btnCreateVisibility;
            }
            set
            {
                btnCreateVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility btnSaveVisibility;
        public Visibility BtnSaveVisibility
        {
            get
            {
                return btnSaveVisibility;
            }
            set
            {
                btnSaveVisibility = value;
                OnPropertyChanged();
            }
        }

        private double _opacityPage;
        public double OpacityPage
        {
            get
            {
                return _opacityPage;
            }
            set
            {
                _opacityPage = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<ObjectModel> objects;
        public ObservableCollection<ObjectModel> Objects
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
        private ObjectModel selectObject;
        public ObjectModel SelectObject
        {
            get
            {
                return selectObject;
            }
            set
            {
                selectObject = value;
                OnPropertyChanged();
            }
        }

        public WorkersPageViewModel()
        {
            OpacityPage = 1;
            AddWorkerVisibility = Visibility.Hidden;
            AccountWorkerVisibility = Visibility.Hidden;
            WorkersPanelVisibility = Visibility.Visible;

        }
        public ICommand OnLoaded
        {
            get
            {
                return new DelegateCommand(async (obj) =>
                {
                    CurrentWorker = null;
                    AddWorkerVisibility = Visibility.Hidden;
                    AccountWorkerVisibility = Visibility.Hidden;
                    WorkersPanelVisibility = Visibility.Visible;
                    WorkerCards = await EmployeeService.GetAll();
                    Objects = await ObjectService.GetAllActive();
                });
            }

        }
        public ICommand AddImage
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "Image files (*.jpeg; *.jpg; *.png)|*.jpeg;*.png;*.jpg" };
                    var result = ofd.ShowDialog();
                    if (result == true)
                    {
                        Image = ofd.FileName;
                    }
                });
            }

        }
        public ICommand AddWorker
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    CurrentWorker = new EmployeeModel();
                    FirstName = "";
                    LastName = "";
                    Phone = "";
                    Specialization = "";
                    Salary = 0;
                    DetailInformation = "";
                    Image = "/Images/imageNULLworker.jpg";
                    Education = "";
                    Recidence = "";
                    Seniority = "";
                    DateOfBirth = DateTime.Now;
                    SelectObject = new ObjectModel() { id = 1 };
                    
                    

                    ShowPage(Pages.AddWorker);
                });
            }
        }

        public ICommand Save
        {
            get
            {
                return new DelegateCommand(async (onj) =>
                {
                    CurrentWorker.FirstName = FirstName;
                    CurrentWorker.LastName = LastName;
                    CurrentWorker.Phone = Phone;
                    CurrentWorker.Salary = Salary;
                    CurrentWorker.Specialization = Specialization;
                    CurrentWorker.DetailInformation = DetailInformation;
                    CurrentWorker.Image = Image;
                    CurrentWorker.Education = Education;
                    CurrentWorker.Recidence = Recidence;
                    CurrentWorker.Seniority = Seniority;
                    CurrentWorker.ObjectId = 1;
                    CurrentWorker.DateOfBirth = DateOfBirth;
                    await EmployeeService.Update(CurrentWorker);
                    WorkerCards = await EmployeeService.GetAll();
                    ShowPage(Pages.WorkersPanel);
                });
            }
        }

        public ICommand Delete
        {
            get
            {
                return new DelegateCommand(async (onj) =>
                {
                    await EmployeeService.Delete(CurrentWorker.id);
                    WorkerCards = await EmployeeService.GetAll();
                    ShowPage(Pages.WorkersPanel);
                });
            }
        }

        public ICommand CreateWorker
        {
            get
            {
                return new DelegateCommand(async (onj) =>
                {
                    CurrentWorker.FirstName = FirstName;
                    CurrentWorker.LastName = LastName;
                    CurrentWorker.Phone = Phone;
                    CurrentWorker.Salary = Salary;
                    CurrentWorker.Specialization = Specialization;
                    CurrentWorker.DetailInformation = DetailInformation;
                    CurrentWorker.Image = Image;
                    CurrentWorker.Education = Education;
                    CurrentWorker.Recidence = Recidence;
                    CurrentWorker.Seniority = Seniority;
                    CurrentWorker.ObjectId = 1;
                    CurrentWorker.DateOfBirth = DateOfBirth;
                    await EmployeeService.Create(CurrentWorker);
                    WorkerCards = await EmployeeService.GetAll();
                    ShowPage(Pages.WorkersPanel);
                });
            }
        }
        public ICommand SelectedCardItemChangedCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    if (obj == null) return;
                    SelectObject = new ObjectModel();
                    CurrentWorker = obj as EmployeeModel;
                    FirstName = CurrentWorker.FirstName;
                    LastName = CurrentWorker.LastName;
                    Salary = CurrentWorker.Salary;
                    Specialization = CurrentWorker.Specialization;
                    Phone = CurrentWorker.Phone;
                    DetailInformation = CurrentWorker.DetailInformation;
                    Image = CurrentWorker.Image;
                    Education = CurrentWorker.Education;
                    Recidence = CurrentWorker.Recidence;
                    Seniority = CurrentWorker.Seniority;
                    SelectObject.id = CurrentWorker.ObjectId;
                    if (CurrentWorker != null)
                    {
                        ShowPage(Pages.AccountWorker);
                    }
                });
            }
        }
        private async void ShowPage(Pages page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0; i -= 0.1)
                {
                    OpacityPage = i;
                    Thread.Sleep(20);
                }
                switch (page)
                {
                    case Pages.AddWorker:
                        WorkersPanelVisibility = Visibility.Hidden;
                        AddWorkerVisibility = Visibility.Visible;
                        BtnCreateVisibility = Visibility.Visible;
                        BtnSaveVisibility = Visibility.Hidden;
                        break;
                    case Pages.WorkersPanel:
                        WorkersPanelVisibility = Visibility.Visible;
                        AddWorkerVisibility = Visibility.Hidden;
                        break;
                    case Pages.AccountWorker:
                        WorkersPanelVisibility = Visibility.Hidden;
                        AddWorkerVisibility = Visibility.Visible;
                        BtnCreateVisibility = Visibility.Hidden;
                        BtnSaveVisibility = Visibility.Visible;
                        break;
                }
                for (double i = 0.0; i < 1.1; i += 0.1)
                {
                    OpacityPage = i;
                    Thread.Sleep(30);
                }
            });
        }
        public ICommand BackPage
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    ShowPage(Pages.WorkersPanel);
                });
            }
        }
    }
}
