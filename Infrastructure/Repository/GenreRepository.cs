using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Helper;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public Page<Genre> GetGenreByPagination(int pageNumber = 1, int pageSize = 3)
        {
            Page<Genre> page = new Page<Genre>();
            page.PageNumber= pageNumber;
            page.TotalRecords = GetAll().Count();
            page.Data = GetAll().Skip((pageNumber-1)*pageSize).Take(pageSize);
            return page;
        }
    }
}
