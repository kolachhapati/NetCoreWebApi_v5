using NetCoreWebApi_v5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi_v5.Services
{
    public class AuthManager : IAuthManager
    {
        public Task<string> CreateToken()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
