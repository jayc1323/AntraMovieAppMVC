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
    public class AccountService : IAccountService
    {
        private readonly IUserRepository userRepository;

        public AccountService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserResponse Login(LoginRequest request)
        {
            User user = userRepository.GetByEmail(request.Email);
            if (user == null || user.HashedPassword != request.Password) return null;
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

        public int Register(UserRequest request)
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
            return userRepository.Insert(user);
        }
    }
}
