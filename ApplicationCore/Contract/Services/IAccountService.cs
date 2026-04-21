using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Services
{
    public interface IAccountService
    {
        Task<UserResponse> Login(LoginRequest request);
        Task<int> Register(UserRequest request);
    }
}
