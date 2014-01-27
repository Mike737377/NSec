using NSec.Repositories;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NSec.Infrastructure
{
    public static class ServiceFactory
    {
        private static bool initialised = false;
        private static object initLock = new object();

        public static void Setup()
        {
            if (initialised) return;
            lock (initLock)
            {
                if (initialised) return;
                ObjectFactory.Initialize(x =>
                {
                    x.Scan(scanner =>
                    {
                        scanner.TheCallingAssembly();
                        scanner.AddAllTypesOf(typeof(IHandler<>));
                        scanner.ConnectImplementationsToTypesClosing(typeof(IHandler<>));
                        scanner.WithDefaultConventions();
                        scanner.RegisterConcreteTypesAgainstTheFirstInterface();
                    });
                    x.For(typeof(IDataContext)).HybridHttpOrThreadLocalScoped();
                    x.For<IServiceBus>().Singleton().Use<PoorMansServiceBus>();
                    x.For<HttpContextBase>().HttpContextScoped().Use(() => new HttpContextWrapper(HttpContext.Current));
                });

                initialised = true;
            }
        }

        public static void ReleaseAndDisposeAllHttpScopedObjects()
        {
            ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }

        public static T GetInstance<T>()
        {
            if (!initialised) { Setup(); }
            return ObjectFactory.GetInstance<T>();
        }
    }
}