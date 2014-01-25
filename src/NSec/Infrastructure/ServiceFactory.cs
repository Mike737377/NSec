using NSec.Repositories;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec.Infrastructure
{
    public static class ServiceFactory
    {
        public static void Setup()
        {
            ObjectFactory.Initialize(x =>
                {
                    x.Scan(scanner => scanner.WithDefaultConventions());
                    x.For(typeof(IRepository<>)).HybridHttpOrThreadLocalScoped();
                });
        }

        public static void ReleaseAndDisposeAllHttpScopedObjects()
        {
            ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }

        public static T GetInstance<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }
    }
}