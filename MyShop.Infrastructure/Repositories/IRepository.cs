using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        T Create(T entity);
        T Update(T entity);
        IEnumerable<T> Find(Func<T, bool> expression);
        IEnumerable<T>GetAll();
        T Get(Guid id);
        void Save();
    }
}
