using SmartManagerServer.Core.Models.Configuration;
using SmartManagerServer.Core.Services;
using SmartManagerServer.Infrastructure.Contracts.Mailing;
using SmartManagerServer.Infrastructure.Services.Mailing.EmailDataProviders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Infrastructure.Services.Mailing
{
    public class EmailNotificationService : INotificationService
    {
        private readonly IEmailSender emailSender;
        private readonly EmailRecipientsConfiguration emailRecipientsConfiguration;
        private readonly FileStorageConfiguration fileStorageConfiguration;
        public async Task NotifyOnException(Exception ex)
        {
            await emailSender.SendAsync(new ExceptionEmailDataProvider(ex, emailRecipientsConfiguration));
        }
    }
}
