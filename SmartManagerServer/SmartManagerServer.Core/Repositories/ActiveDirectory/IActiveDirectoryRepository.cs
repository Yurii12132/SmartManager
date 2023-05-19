using SmartManagerServer.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Core.Repositories.ActiveDirectory
{
    public interface IActiveDirectoryRepository
    {
        Task<UserAccount> GetAccountByEmailAsync(string email);
    }
}
