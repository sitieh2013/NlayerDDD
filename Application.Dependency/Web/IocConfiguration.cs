using System.Web.Http;
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

            //kernel.Bind<IDocumentService>().To<DocumentService>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWorkContext>();
            config.DependencyResolver = new NinjectHttp(kernel);
        }
    }
}
