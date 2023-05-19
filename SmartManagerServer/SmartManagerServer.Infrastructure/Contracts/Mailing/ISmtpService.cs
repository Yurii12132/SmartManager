using SmartManagerServer.Infrastructure.Models.Mailing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Infrastructure.Contracts.Mailing
{
    public interface ISmtpService
    {
        Task SendAsync(EmailDataModel email);
    }
}
