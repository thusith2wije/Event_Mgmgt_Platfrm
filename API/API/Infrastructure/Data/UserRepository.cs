using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIQRI.EMP.ApplicationCore.Entities;
using TIQRI.EMP.ApplicationCore.Interfaces;

namespace TIQRI.EMP.Infrastructure.Data
{
    public class UserRepository : EfRepository<User>, IUserRepository 
    {
        public UserRepository(EMPContext dbContext) : base(dbContext)
        {
        }
                
        public User GetByName(string name)
        {
            return _dbContext.Users                   
                   .Where(o => o.UserName == name)
                   .FirstOrDefault();
        }

    }
}



