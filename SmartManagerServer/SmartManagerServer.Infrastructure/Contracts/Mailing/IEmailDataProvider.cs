using SmartManagerServer.Infrastructure.Models.Mailing;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Infrastructure.Contracts.Mailing
{
    public interface IEmailDataProvider
    {
        EmailDataModel Provide();
    }
}
