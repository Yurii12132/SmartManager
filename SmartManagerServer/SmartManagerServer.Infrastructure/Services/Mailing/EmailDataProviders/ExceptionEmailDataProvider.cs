using SmartManagerServer.Core.Models.Configuration;
using SmartManagerServer.Infrastructure.Contracts.Mailing;
using SmartManagerServer.Infrastructure.Models.Mailing;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Infrastructure.Services.Mailing.EmailDataProviders
{
    public class ExceptionEmailDataProvider : IEmailDataProvider
    {
        private readonly Exception exception;
        private readonly EmailRecipientsConfiguration emailRecipientsConfiguration;
        public ExceptionEmailDataProvider(Exception exception, EmailRecipientsConfiguration emailRecipientsConfiguration)
        {
            this.exception = exception;
            this.emailRecipientsConfiguration = emailRecipientsConfiguration;
        }
        public EmailDataModel Provide()
        {
            var emailBody = EmailTemplateProvider.GetExceptionTemplate();
            var messages = GetExceptionMessage(exception);

            StringBuilder messageList = new StringBuilder();
            messageList.Append("<ul>");
            foreach (var message in messages)
            {
                messageList.Append($"<li>{message}</li>");
            }
            messageList.Append("</ul>");
            emailBody = emailBody.Replace("{--exceptionMessages--}", messageList.ToString());
            emailBody = emailBody.Replace("{--stackTrace--}", exception.StackTrace);

            return new EmailDataModel()
            {
                Subject = $"Smart receipt error",
                Body = emailBody,
                ToEmails = new List<string>() { emailRecipientsConfiguration.Developers },
            };
        }

        private List<string> GetExceptionMessage(Exception ex, List<string> messages = null)
        {
            if (messages == null) messages = new List<string>();
            if (ex.Message == null) return messages;
            messages.Add(ex.Message);
            if (ex.InnerException != null) GetExceptionMessage(ex.InnerException, messages);
            return messages;
        }
    }
}
