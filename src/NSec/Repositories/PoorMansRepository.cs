using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Repositories
{
    public class PoorMansRepository<T> : IRepository<T>
    {
        protected readonly List<T> storage = new List<T>();

        public void Add(T data)
        {
            storage.Add(data);
        }

        public IQueryable<T> Query
        {
            get
            {
                return storage.AsQueryable();
            }
        }

        public void Remove(T data)
        {
            storage.Remove(data);
        }

        public void Dispose()
        {
            //we don't need to dispose anything
        }
    }
}