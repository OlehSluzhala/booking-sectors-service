using System;
using System.Collections.Generic;
using System.Linq;
using SoftServe.BookingSectors.WebAPI.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace SoftServe.BookingSectors.WebAPI.Data.GenericRepository
{
    public sealed class GenericRepository<T>: IDisposable, IGenericRepository<T> where T : class
    {
        private readonly BookingSectorContext myDataBase = null;
        private readonly DbSet<T> table = null;

        public GenericRepository()
        {
            this.myDataBase = new BookingSectorContext();
            table = myDataBase.Set<T>();

        }
        public GenericRepository(BookingSectorContext myDataBase)
        {
            this.myDataBase = myDataBase;
            table = myDataBase.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            myDataBase.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {

            T existing = table.Find(id);
            table.Remove(existing);
            
        }
        public void Save()
        {
            myDataBase.SaveChanges();
        }

        public void Dispose()
        {
            myDataBase.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
