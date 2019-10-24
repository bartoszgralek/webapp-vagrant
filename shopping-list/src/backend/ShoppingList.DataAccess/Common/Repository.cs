namespace ShoppingList.DataAccess.Common
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Common.Database;
    using ShoppingList.Common.Attributes;

    [ScopedWithAbstraction(typeof(IRepository<>))]
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ShoppingListDbContext _dbContext;

        public Repository(ShoppingListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}