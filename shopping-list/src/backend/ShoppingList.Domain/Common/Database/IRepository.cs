namespace ShoppingList.Domain.Common.Database
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();
        Task AddAsync(TEntity entity);
        Task SaveChangesAsync();
    }
}