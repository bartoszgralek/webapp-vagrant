namespace ShoppingList.DataAccess.Common
{
    using Domain.ShoppingLists;
    using Microsoft.EntityFrameworkCore;
    using ShoppingList.Common.Attributes;
    using ShoppingLists.Configuration;

    [Transient]
    public class ShoppingListDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=ShoppingList;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductDbMap());
            modelBuilder.ApplyConfiguration(new ShoppingListDbMap());
            modelBuilder.ApplyConfiguration(new ShoppingListItemDbMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}