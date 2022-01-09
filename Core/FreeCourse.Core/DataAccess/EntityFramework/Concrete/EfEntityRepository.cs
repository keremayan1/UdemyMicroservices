using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FreeCourse.Core.Entities.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace FreeCourse.Core.DataAccess.EntityFramework.Concrete
{
    public class EfEntityRepository<TEntity,TContext>:IAsyncEntityRepository<TEntity>,IEntityRepository<TEntity> where TEntity : class,IEntity
    where TContext :DbContext
    {


        protected TContext _context;

        public EfEntityRepository(TContext context)
        {
            _context = context;
        }


        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? await _context.Set<TEntity>().ToListAsync()
                : await _context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task AddAsync(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
          await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
           await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var updatedState = _context.Entry(entity);
            updatedState.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task MultipleAdd(TEntity[] entity)
        {
            foreach (var entities in entity)
            {
                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Added;
               await _context.SaveChangesAsync();
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().FirstOrDefault(filter);
        }
        public void Add(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChangesAsync();
        }
    }
}
