using Data.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.Repositories.Interfaces
{
    public interface IRepository<T> where T:BaseModel
    {
        IEnumerable<T> GetAll(Func<T, bool> func = null);
        void Add(T entity);
        void Remove(T entity);
        void Remove(string id);
        T Find(string id);
        void Update(T entity);
        int CommitChanges();
    }
}
