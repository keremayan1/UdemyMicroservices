using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FreeCourse.Core.Entities.MongoDb;

using FreeCourse.Core.Entities.MongoDb.Concrete;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FreeCourse.Core.DataAccess.MongoDb.Concrete
{
    public  class MongoDbRepository<TEntity> : IMongoDbRepository<TEntity> where TEntity :IMongoDbEntity
    {
        private readonly IMongoCollection<TEntity> _collection;
        protected MongoDbRepository(IMongoDbConnectionSettings connectionSettings)
        {
            var database = new MongoClient(connectionSettings.ConnectionStrings).GetDatabase(connectionSettings.DatabaseName);
            _collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
      
        public virtual void Add(TEntity entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            _collection.InsertOne(entity,options);
        }

        public virtual IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? _collection.AsQueryable()
                : _collection.AsQueryable().Where(predicate);
        }

        public virtual TEntity GetById(string id)
        {
          return  _collection.Find(x => x.Id == id).FirstOrDefault();
        }

        public virtual void AddMany(IEnumerable<TEntity> entities)
        {
            var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
             _collection.BulkWriteAsync((IEnumerable<WriteModel<TEntity>>)entities, options);
        }

        public virtual void Update(string id, TEntity record)
        {
            _collection.FindOneAndReplace(x => x.Id == id, record);
        }

        public virtual void Update(TEntity record, Expression<Func<TEntity, bool>> predicate)
        {
            _collection.FindOneAndReplace(predicate, record);
        }

        public virtual void Delete(string id)
        {
            _collection.FindOneAndDelete(x => x.Id == id);
        }

        public virtual void Delete(TEntity record)
        {
            _collection.FindOneAndDelete(x => x.Id == record.Id);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
           await _collection.InsertOneAsync(entity, options);
        }

        public virtual async Task<IQueryable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await Task.Run(() => predicate == null
                ? _collection.AsQueryable()
                : _collection.AsQueryable().Where(predicate));
        }

        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task AddManyAsync(IEnumerable<TEntity> entities)
        {
            var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
            await _collection.BulkWriteAsync((IEnumerable<WriteModel<TEntity>>)entities, options);
        }

        public virtual async Task UpdateAsync(string id, TEntity record)
        {
            await _collection.FindOneAndReplaceAsync(x=>x.Id==id,record);
        }

        public virtual async Task UpdateAsync(TEntity record, Expression<Func<TEntity, bool>> predicate)
        {
            await _collection.FindOneAndReplaceAsync(predicate, record);
        }

        public virtual async Task DeleteAsync(string id)
        {
            await _collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public virtual async Task DeleteAsync(TEntity record)
        {
            await _collection.FindOneAndDeleteAsync(x => x.Id == record.Id);
        }

        public  bool Any(Expression<Func<TEntity, bool>> predicate = null)
        {
            var data = predicate == null
                ? _collection.AsQueryable()
                : _collection.AsQueryable().Where(predicate);

            if (data.FirstOrDefault() == null)
                return false;
            else
                return true;
        }

        

        public async Task<List<TEntity>> GetListAsync2()
        {
         return    await _collection.Find(_collection => true).ToListAsync();
        }

   

     
    }
}
