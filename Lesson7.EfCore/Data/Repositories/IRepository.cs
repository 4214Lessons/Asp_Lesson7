using Lesson7.EfCore.Models;
using System.Linq.Expressions;

namespace Lesson7.EfCore.Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T>? GetAll();
        Task<IEnumerable<T>?> GetAllAsync();
        T? GetById(int id);
        T? Get(Expression<Func<T, bool>> expression);

        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
