using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Core.UoWs
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}
