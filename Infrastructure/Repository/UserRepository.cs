using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
            return (await GetAll()).FirstOrDefault(u => u.Email == email);
        }
    }
}
