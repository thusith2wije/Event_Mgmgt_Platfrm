using System;
using System.Collections.Generic;
using System.Text;
using TIQRI.EMP.ApplicationCore.Entities;

namespace TIQRI.EMP.ApplicationCore.Interfaces
{
    public interface IClientRepository : IRepository<Client>, IAsyncRepository<Client>
    {

    }
}
