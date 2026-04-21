using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<UserResponse>> GetAllUsers();
        Task<bool> LockUser(int userId);
        Task<bool> UnlockUser(int userId);
        Task<int> AddMovie(MovieRequest request);
    }
}
