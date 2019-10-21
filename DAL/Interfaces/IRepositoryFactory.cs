using System.Data.Entity;

namespace DAL.Repositories
{
    public interface IRepositoryFactory<TRepository, TContext>
        where TRepository : class
        where TContext : DbContext
    {
        TRepository Create(TContext context);
    }
}