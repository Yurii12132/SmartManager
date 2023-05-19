using Microsoft.Extensions.Options;
using SmartManagerServer.Core.Models.Auth;
using SmartManagerServer.Core.Repositories.ActiveDirectory;
using SmartManagerServer.Infrastructure.Models.Configuration;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Infrastructure.Repositories.ActiveDirectory
{
    public class ActiveDirectoryRepository : IActiveDirectoryRepository
    {
        private readonly ActiveDirectoryConfiguration configuration;
        private const string MEMBER_OF_PROPERTY = "memberof";
        public ActiveDirectoryRepository(IOptions<ActiveDirectoryConfiguration> activeDiractoryConfiguration)
        {
            this.configuration = activeDiractoryConfiguration.Value;
        }
        public async Task<UserAccount> GetAccountByEmailAsync(string email)
        {
            UserAccount result = null;

            await Task.Run(() =>
            {
                result = GetAdMemberByEmail(email);
            });

            return result;
        }

        private UserAccount GetAdMemberByEmail(string email)
        {
            UserAccount result = null;
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, configuration.Domain, configuration.Container))
            {
                using (UserPrincipal searchUserPrincipal = new UserPrincipal(context))
                {
                    searchUserPrincipal.EmailAddress = email;
                    using (PrincipalSearcher pS = new PrincipalSearcher(searchUserPrincipal))
                    {
                        using (Principal userPrincipal = pS.FindOne())
                        {
                            if (userPrincipal == null) return null;
                            if ((userPrincipal is UserPrincipal) == false) return null;

                            var directoryEntry = (userPrincipal.GetUnderlyingObject() as DirectoryEntry);

                            result = ConvertToUserAccount((UserPrincipal)userPrincipal, directoryEntry);

                            result.Admin = IsMemberOfGroup(userPrincipal, context, configuration.AdminGroup);
                            result.Admin = true;
                            if (result.Admin == true) result.User = true;
                            else result.User = IsMemberOfGroup(userPrincipal, context, configuration.UserGroup);
                        }
                    }
                }
            }
            return result;
        }

        private bool IsMemberOfGroup(Principal user, PrincipalContext context, string groupName)
        {
            using (GroupPrincipal group = GroupPrincipal.FindByIdentity(context, groupName))
            {
                if (user.IsMemberOf(group)) return true;
            }
            return false;
        }
        private UserAccount ConvertToUserAccount(UserPrincipal user, DirectoryEntry directoryEntry)
        {
            var employeeNumber = directoryEntry.Properties["EmployeeNumber"].Value;

            return new UserAccount()
            {
                Identity = user.SamAccountName,
                Firstname = user.GivenName,
                Email = user.EmailAddress,
                Surname = user.Surname,
                DisplayName = user.DisplayName,
                EmployeeId = employeeNumber.ToString().Replace("WD", "")
            };
        }

        private string GetCommonNameFromLdapPath(string path)
        {
            if (path == null || path.Length == 0) return null;
            string[] separators = { "CN=", "," };
            var parts = path.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string result = parts[0];
            result = result.Replace("\\", "");
            return result;

        }
    }
}
