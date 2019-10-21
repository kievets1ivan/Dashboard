using DAL.Entities;
using DAL.Repositories;
using DAL.UoW;
using Ninject;
using Ninject.Web.Common;

namespace DAL.DI
{
    public static class DalDependencyResolver
    {
        public static void Initialize(IKernel kernel)
        {

            kernel.Bind<System.Data.Entity.DbContext>().To<TicketContext>();

            kernel.Bind(typeof(IRepositoryFactory<,>)).To(typeof(RepositoryFactory<,>)).WhenInjectedInto<IUnitOfWork>();

            kernel.Bind<IGenericRepository<TicketEntity>>().To<GenericRepository<TicketEntity>>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
        }
    }
}
