using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Services
{
    public interface IUserService
    {
        UserResponse GetUserById(int id);
        UserResponse GetUserByEmail(string email);
        int RegisterUser(UserRequest request);
    }
}
