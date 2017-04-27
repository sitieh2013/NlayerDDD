using System.Web.Http;
using Application.Services;
using Domain.Services;
using Ninject;
using Domain.UnitOfWork;
using Data.UnitOfWork;

namespace Application.Dependency.Web
{
    public class IocConfiguration
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel(); 

            kernel.Bind<IUnitOfWork>().To<UnitOfWorkContext>();
            kernel.Bind<IServiceProject>().To<ServiceProject>();

            config.DependencyResolver = new NinjectHttp(kernel);
        }
    }
}
