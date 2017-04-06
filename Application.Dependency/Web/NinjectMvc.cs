﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Ninject.Parameters;

namespace Application.Dependency.Web
{
    public class NinjectMvc : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectMvc(IKernel kernel)
        {
            _kernel = kernel;
        }

        #region IDependencyResolver Members

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType, new IParameter[0]);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType, new IParameter[0]);
        }

        #endregion
    }
}
