using Microsoft.EntityFrameworkCore;
using SigniFormAPI.DataAccess.Data;
using SigniFormAPI.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SigniFormAPI.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext db;
        private DbSet<T> DbSet;

        public Repository(ApplicationDbContext db)
        {
            this.db = db;
            this.DbSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>>? filter = null, bool tracked = false)
        {
            IQueryable<T> query;

            if (tracked){
                query = DbSet;
            }
            else
            {
                query = DbSet.AsNoTracking();
            }

            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, bool tracked = false)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }
    }
}
