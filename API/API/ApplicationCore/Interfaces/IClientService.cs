using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIQRI.EMP.ApplicationCore.Entities;

namespace TIQRI.EMP.ApplicationCore.Interfaces
{
    public interface IClientService
    {
        Task CreateClientAsync(Client client);
    }
}
