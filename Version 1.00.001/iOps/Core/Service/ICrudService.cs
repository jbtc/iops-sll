using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using iOps.Core.Model;

namespace iOps.Core.Service
{
    public interface ICrudService<T> where T : DelEntity, new()
    {
        Guid Create(T item);
        void Save();
        void Delete(Guid ID);
        T Get(Guid ID);
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> func, bool showDeleted = false);
        void Restore(Guid ID);
    }
}