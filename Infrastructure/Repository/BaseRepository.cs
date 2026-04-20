using ApplicationCore.Contract.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly MovieDbContext dbContext;

        public BaseRepository(MovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int Delete(int id)
        {
            T entity = GetById(id);
            if(entity != null)
                dbContext.Set<T>().Remove(entity);
            return dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
           return dbContext.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public int Insert(T entity)
        {
            dbContext.Set<T>().Add(entity);
            return dbContext.SaveChanges();
        }

        public int Update(T entity)
        {
            dbContext.Set<T>().Entry(entity).State = EntityState.Modified;
            return dbContext.SaveChanges();
        }
    }
}
