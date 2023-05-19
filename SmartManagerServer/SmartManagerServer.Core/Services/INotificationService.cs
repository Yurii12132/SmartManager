using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Core.Services
{
    public interface INotificationService
    {
        Task NotifyOnException(Exception ex);
    }
}
