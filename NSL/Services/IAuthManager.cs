using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSL.Models;

namespace NSL.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(UserLoginDTO userDTO);

        Task<string> CreateToken();
    }
}
