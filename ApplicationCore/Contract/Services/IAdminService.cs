using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Services
{
    public interface IAdminService
    {
        IEnumerable<UserResponse> GetAllUsers();
        bool LockUser(int userId);
        bool UnlockUser(int userId);
        int AddMovie(MovieRequest request);
    }
}
