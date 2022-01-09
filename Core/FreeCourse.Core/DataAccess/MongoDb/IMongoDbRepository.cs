using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FreeCourse.Core.Entities.MongoDb;
using MongoDB.Bson;

namespace FreeCourse.Core.DataAccess.MongoDb
{
    public interface IMongoDbRepository<T> where T:MongoBaseEntity
    {
        void Add(T entity);
        IQueryable<T> GetList(Expression<Func<T, bool>> predicate = null);
        T GetById(string id);
        void AddMany(IEnumerable<T> entities);
        void Update(string id, T record);
        void Update(T record, Expression<Func<T, bool>> predicate);
        void Delete(string id);
        void Delete(T record);
        Task AddAsync(T entity);
        Task<IQueryable<T>> GetListAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> GetByIdAsync(string id);
        Task AddManyAsync(IEnumerable<T> entities);
        Task UpdateAsync(string id, T record);
        Task UpdateAsync(T record, Expression<Func<T, bool>> predicate);
        Task DeleteAsync(string id);
        Task DeleteAsync(T record);
        bool Any(Expression<Func<T, bool>> predicate = null);

        Task<List<T>> GetListAsync2();
    }
}
