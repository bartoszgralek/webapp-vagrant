namespace ShoppingList.DataAccess.ShoppingLists.Configuration
{
    using Domain.ShoppingLists;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ShoppingListDbMap : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.HasKey(sl => sl.Id);

            builder.Property(sl => sl.Name).IsRequired();
        }
    }
}