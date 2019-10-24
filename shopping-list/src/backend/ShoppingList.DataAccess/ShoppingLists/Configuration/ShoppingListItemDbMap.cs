namespace ShoppingList.DataAccess.ShoppingLists.Configuration
{
    using Domain.ShoppingLists;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ShoppingListItemDbMap : IEntityTypeConfiguration<ShoppingListItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingListItem> builder)
        {
            builder.HasKey(sli => sli.Id);

            builder
                .HasOne(sli => sli.Product)
                .WithMany(p => p.ShoppingLists)
                .HasForeignKey(sli => sli.ProductId);

            builder
                .HasOne(sli => sli.ShoppingList)
                .WithMany(sl => sl.Items)
                .HasForeignKey(sli => sli.ShoppingListId);
        }
    }
}