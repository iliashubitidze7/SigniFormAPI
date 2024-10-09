using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SigniFormAPI.DataAccess.Repository.IRepository
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, bool tracked = false);
        T Get(Expression<Func <T, bool>>? filter = null, bool tracked = false);
        void Add(T entity);
        void Remove(T entity);
    }
}
