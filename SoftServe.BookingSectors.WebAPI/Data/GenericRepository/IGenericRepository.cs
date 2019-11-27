using System.Collections.Generic;
using SoftServe.BookingSectors.WebAPI.Data.Models;

namespace SoftServe.BookingSectors.WebAPI.Data.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
