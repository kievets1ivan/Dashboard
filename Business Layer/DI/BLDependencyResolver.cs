using Business_Layer.Services;
using DAL.DI;
using Ninject;
using Ninject.Web.Common;

namespace Business_Layer.DI
{
    public static class BLDependencyResolver
    {
        public static void Initialize(IKernel kernel)
        {
            kernel.Bind<ITicketService>().To<TicketService>().InRequestScope();

            DalDependencyResolver.Initialize(kernel);
        }
    }
}
