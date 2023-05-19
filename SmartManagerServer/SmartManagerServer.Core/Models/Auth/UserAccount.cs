using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Core.Models.Auth
{
    public class UserAccount
    {
        public string Identity { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string EmployeeId { get; set; }
        public bool Admin { get; set; }
        public bool User { get; set; }
    }
}
