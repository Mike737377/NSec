using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        void Add(T data);

        IQueryable<T> Query { get; }

        void Remove(T data);
    }
}