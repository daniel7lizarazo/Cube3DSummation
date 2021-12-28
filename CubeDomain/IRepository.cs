using CubeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CubeApplication
{
    public interface IRepository<T, TId> 
        where T : IEntity<TId>, new()
        where TId : IComparable, IComparable<TId>
    {
        void InsertOneAsync(T entity);
        void InsertOne(T entity);

        void InsertGroupAsync(IEnumerable<T> entityGroup);
        void InsertGroup(IEnumerable<T> entityGroup);

        Task<bool> UpdateAsync(T entity);
        bool Update(T entity);

        Task<bool> DeleteOneAsync(T entity);
        bool DeleteOne(T entity);

        Task<bool> DeleteByIdAsync(TId id);
        bool DeleteById(TId id);

        Task<T> GetByIdAsync(TId id);
        T GetById(TId id);

        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetByExpressionAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetByExpression(Expression<Func<T, bool>> predicate);

        Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        T FindFirstOrDefault(Expression<Func<T, bool>> predicate);
    }
}
