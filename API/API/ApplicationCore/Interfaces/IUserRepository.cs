using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIQRI.EMP.ApplicationCore.Entities;

namespace TIQRI.EMP.ApplicationCore.Interfaces
{
    public interface IUserRepository : IRepository<User>, IAsyncRepository<User>
    {
        User GetByName(string name);
        
    }
}
