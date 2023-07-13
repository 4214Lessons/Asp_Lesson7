using Lesson7.EfCore.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lesson7.EfCore.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext context;
        private readonly DbSet<T> dbSet;

        public Repository(AppDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = dbSet.FirstOrDefault(x => x.Id == id);
            if(entity is not null)
                dbSet.Remove(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T? Get(Expression<Func<T, bool>> expression)
        {
            return dbSet.FirstOrDefault(expression);
        }

        public IEnumerable<T>? GetAll()
        {
            return dbSet.ToList();
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public T? GetById(int id)
        {
            return dbSet.FirstOrDefault(x => x.Id == id);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
