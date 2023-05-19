using ManagementWPF.ViewModels.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManagementWPF.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for OutlayAddMaterialDialog.xaml
    /// </summary>
    public partial class OutlayAddMaterialDialog : UserControl
    {
        public OutlayAddMaterialDialog()
        {
            InitializeComponent();
            DataContext = new OutlayAddMaterialViewModel();
        }
    }
}
