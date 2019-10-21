using Ninject;
using System;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class RepositoryFactory<TRepository, TContext> : IRepositoryFactory<TRepository, TContext>
        where TRepository : class
        where TContext : DbContext
    {
        private readonly IKernel _kernel;
        public RepositoryFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public TRepository Create(TContext context)
        {
            var type = _kernel.Get<TRepository>().GetType();
            var repository = Activator.CreateInstance(type, context);

            return (TRepository)repository;
        }
    }
}
