using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using iOps.Core.Model;
using iOps.Core.Repository;
using iOps.Core.Service;

namespace iOps.Service
{
    public class CrudService<T> : ICrudService<T> where T : DelEntity, new()
    {
        protected IRepo<T> repo;

        public CrudService(IRepo<T> repo)
        {
            this.repo = repo;
        }

        public IEnumerable<T> GetAll()
        {
            return repo.GetAll();
        }

        public T Get(Guid id)
        {
            return repo.Get(id);
        }

        public virtual Guid Create(T item)
        {
            var newItem = repo.Insert(item);
            repo.Save();
            return newItem.ID;
        }

        public void Save()
        {
            repo.Save();
        }

        public virtual void Delete(Guid id)
        {
            repo.Delete(repo.Get(id));
            repo.Save();
        }

        public void Restore(Guid id)
        {
            repo.Restore(repo.Get(id));
            repo.Save();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false)
        {
            return repo.Where(predicate, showDeleted);
        }
    }
}