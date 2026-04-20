using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Services
{
    public interface IAccountService
    {
        UserResponse Login(LoginRequest request);
        int Register(UserRequest request);
    }
}
