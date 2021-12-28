using CubeApplication;
using CubeDomain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CubeInfrastructure
{
    public class MongoRepository<T, TId> : IRepository<T, TId>
        where T : IEntity<TId>, new()
        where TId : IComparable, IComparable<TId>
    {

        private readonly IMongoCollection<T> _mongoCollection;

        public MongoRepository(string host, string dbName)
        {
            var _client = new MongoClient(host);
            _mongoCollection = _client.GetDatabase(dbName).GetCollection<T>(nameof(T));
        }
        public bool DeleteById(TId id)
        {
            var mongoResult = _mongoCollection.DeleteOne(d => d.Id.Equals(id));
            return mongoResult.DeletedCount > 0;
        }

        public async Task<bool> DeleteByIdAsync(TId id)
        {
            var mongoResult = await _mongoCollection.DeleteOneAsync(d => d.Id.Equals(id));
            return mongoResult.DeletedCount > 0;
        }

        public bool DeleteOne(T entity)
        {
            return DeleteById(entity.Id);
        }

        public async Task<bool> DeleteOneAsync(T entity)
        {
            return await DeleteByIdAsync(entity.Id);
        }

        public T FindFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _mongoCollection.Find(predicate).FirstOrDefault();
        }

        public async Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return (await _mongoCollection.FindAsync(predicate)).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _mongoCollection.Find(d=> d!=null).ToEnumerable();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return (await _mongoCollection.FindAsync(d => d != null)).ToEnumerable();
        }

        public IEnumerable<T> GetByExpression(Expression<Func<T, bool>> predicate)
        {
            return _mongoCollection.Find(predicate).ToEnumerable();
        }

        public async Task<IEnumerable<T>> GetByExpressionAsync(Expression<Func<T, bool>> predicate)
        {
            return (await _mongoCollection.FindAsync(predicate)).ToEnumerable();
        }

        public T GetById(TId id)
        {
            return _mongoCollection.Find(d => d.Id.Equals(id)).FirstOrDefault();
        }

        public async Task<T> GetByIdAsync(TId id)
        {
            return (await _mongoCollection.FindAsync(d => d.Id.Equals(id))).FirstOrDefault();
        }

        public void InsertGroup(IEnumerable<T> entityGroup)
        {
            _mongoCollection.InsertMany(entityGroup);
        }

        public async void InsertGroupAsync(IEnumerable<T> entityGroup)
        {
            await _mongoCollection.InsertManyAsync(entityGroup);
        }

        public void InsertOne(T entity)
        {
            _mongoCollection.InsertOne(entity);
        }

        public async void InsertOneAsync(T entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
        }

        public bool Update(T entity)
        {
            if (DeleteOne(entity))
            {
                InsertOne(entity);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            if ( (await _mongoCollection.DeleteOneAsync(d => d.Id.Equals(entity.Id))).DeletedCount >=1)
            if (await DeleteOneAsync(entity))
            {
                InsertOneAsync(entity);
                return true;
            }
            return false;
        }
    }
}
