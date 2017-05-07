using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Security.Services;
using Ninject.Modules;

namespace Application.Dependency.Common
{
    internal class IocSingleton : NinjectModule
    {
        private static IocSingleton _instance;
        private static readonly Object Synchronous = new Object();

        public static IocSingleton GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Synchronous)
                    {
                        if (_instance == null)
                        {
                            _instance = new IocSingleton();
                        }
                    }
                }

                return _instance;
            }
        }

        public override void Load()
        {
            Bind<ISecurityService>().To<ServiceSecurity>();
        }
    }
}
