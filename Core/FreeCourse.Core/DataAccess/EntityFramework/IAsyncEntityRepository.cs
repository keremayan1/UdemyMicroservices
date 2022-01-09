using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FreeCourse.Core.Entities.EntityFramework;

namespace FreeCourse.Core.DataAccess.EntityFramework
{
    public interface IAsyncEntityRepository<T> where T:class,IEntity
    {

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task MultipleAdd(T[] entity);
     
    }
}
