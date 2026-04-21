using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserResponse> GetUserByEmail(string email)
        {
            User user = await userRepository.GetByEmail(email);
            if (user == null) return null;
            return MapToResponse(user);
        }

        public async Task<UserResponse> GetUserById(int id)
        {
            User user = await userRepository.GetById(id);
            if (user == null) return null;
            return MapToResponse(user);
        }

        public async Task<int> RegisterUser(UserRequest request)
        {
            User user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                HashedPassword = request.Password,
                DateOfBirth = request.DateOfBirth,
                IsLocked = false
            };
            return await userRepository.Insert(user);
        }

        private UserResponse MapToResponse(User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IsLocked = user.IsLocked,
                DateOfBirth = user.DateOfBirth
            };
        }
    }
}
