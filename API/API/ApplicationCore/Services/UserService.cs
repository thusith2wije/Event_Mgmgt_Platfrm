using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIQRI.EMP.ApplicationCore.Entities;
using TIQRI.EMP.ApplicationCore.Interfaces;

namespace TIQRI.EMP.ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string userName, string password)
        {
            var user = _userRepository.GetByName(userName);
            if (user.UserName == userName && user.Password == password)
            {
                return user;
            }
            return null;
        }

        

    }
}
