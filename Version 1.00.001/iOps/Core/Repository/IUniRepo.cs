using System.Collections.Generic;
using iOps.Core.Model;

namespace iOps.Core.Repository
{
    public interface IUniRepo
    {
        T Insert<T>(T o) where T : Entity, new();

        void Save();

        T Get<T>(int ID) where T : Entity;

        IEnumerable<T> GetAll<T>() where T : Entity;
    }
}