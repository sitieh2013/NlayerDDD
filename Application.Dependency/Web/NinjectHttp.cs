using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace Application.Dependency.Web
{
    public class NinjectHttp : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectHttp(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _kernel.GetAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
            // When BeginScope returns 'this', the Dispose method must be a no-op.
        }
    }
}
