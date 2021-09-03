using Ninject;
using SuperHero.Domain.Abstract;
using SuperHero.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SuperHero.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // Añadir los binds aquí.
            _kernel.Bind<IHeroRepository>().To<HeroRepository>();
        }
    }
}