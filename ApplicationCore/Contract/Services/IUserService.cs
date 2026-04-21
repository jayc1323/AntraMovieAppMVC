using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Services
{
    public interface IUserService
    {
        Task<UserResponse> GetUserById(int id);
        Task<UserResponse> GetUserByEmail(string email);
        Task<int> RegisterUser(UserRequest request);
    }
}
