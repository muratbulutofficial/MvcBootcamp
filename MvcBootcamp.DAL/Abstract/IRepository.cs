using MvcBootcamp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.DAL.Abstract
{
    public interface IRepository<T> 
    {
        List<T> Getlist(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        List<T> Find(Expression<Func<T, bool>> filter);

    }
}
