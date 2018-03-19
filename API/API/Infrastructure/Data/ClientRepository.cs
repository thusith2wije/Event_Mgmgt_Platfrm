using System;
using System.Collections.Generic;
using System.Text;
using TIQRI.EMP.ApplicationCore.Entities;
using TIQRI.EMP.ApplicationCore.Interfaces;

namespace TIQRI.EMP.Infrastructure.Data
{
    public class ClientRepository : EfRepository<Client>, IClientRepository
    {
        public ClientRepository(EMPContext dbContext) : base(dbContext)
        {
        }
    }
}
