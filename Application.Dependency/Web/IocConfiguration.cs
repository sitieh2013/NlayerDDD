using System.Web.Http;
using Application.Services;
using Domain.Services;
using Ninject;
using Domain.UnitOfWork;
using Data.UnitOfWork;

namespace Application.Dependency.Web
{
    public static class IocConfiguration
    {
        public static void Register(HttpConfiguration config)
        {
            var kernel = new StandardKernel(); 

            kernel.Bind<IUnitOfWorkRepository>().To<UnitOfWorkRepositoryContext>();

            kernel.Bind<IServiceProject>().To<ServiceProject>();

            config.DependencyResolver = new NinjectHttp(kernel);
        }
    }
}
