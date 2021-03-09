using NetCoreWebApi_v5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi_v5.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO user);
        Task<string> CreateToken();
    }
}
