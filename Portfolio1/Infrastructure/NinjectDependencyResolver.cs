using Ninject;
using Portfolio1.Infrastructure.Abstract;
using Portfolio1.Infrastructure.Concrete;
using Portfolio1.Repositories;
using Portfolio1.Repositories.Reops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio1.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IImageRepository>().To<QuoteImages>().InSingletonScope();
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}