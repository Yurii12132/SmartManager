using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementWPF.Common.Services
{
    public interface IDialogService
    {
        void ShowDialog<ViewModel>(Action<bool> callback);
    }
}
