using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyShop.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected ShoppingContext _context;
        public GenericRepository(ShoppingContext shopping) 
        {
            _context = shopping;
        }
        public virtual T Create(T entity)
        {
            return _context.Add<T>(entity).Entity;
        }

        public virtual IEnumerable<T> Find(Func<T, bool> expression)
        {
            return _context.Set<T>()
                .AsQueryable()
                .Where(expression)
                .ToList();
        }

        public virtual T Get(Guid id)
        {
            return _context.Find<T>(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            return _context.Update<T>(entity).Entity;
        }
    }
}
