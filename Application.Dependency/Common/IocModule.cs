using Application.Security.Services;
using Ninject;

namespace Application.Dependency.Common
{
    public static class IocModule
    {
        public static ISecurityService GetSecurityService()
        {
            return StandardKernel.Get<ISecurityService>();
        }

        static StandardKernel StandardKernel
        {
            get
            {
                return new StandardKernel(IocSingleton.GetInstance);
            }
        }
    }
}
