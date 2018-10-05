using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Library.Repositories.Implementation;
using Library.Repositories.Interfaces;

namespace Library.WebApplication.App_Start
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectResolver()
        {
            _kernel = new StandardKernel();
            _kernel.Unbind<ModelValidatorProvider>();
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

        public void AddBindings()
        {
            _kernel.Bind<IAuthorRepository>().To<AuthorRepository>();
        }
    }
}