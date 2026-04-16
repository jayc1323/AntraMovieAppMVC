using ApplicationCore.Entities;
using ApplicationCore.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Repositories
{
    public interface IGenreRepository:IRepository<Genre>
    {
        //add more custom methods
        Page<Genre> GetGenreByPagination(int pageNumber=1, int pageSize=3);
    }
}
