namespace ShoppingList.Domain.ShoppingLists
{
    using System.Collections.Generic;
    using Common.Database;

    public class ShoppingList : BaseEntity
    {
        public string Name { get; set; }
        public List<ShoppingListItem> Items { get; set; }

        public static ShoppingList Create(string shoppingListName)
        {
            return new ShoppingList
            {
                Name = shoppingListName,
                Items = new List<ShoppingListItem>()
            };
        }

        public void AddProduct(Product product)
        {
            var link = new ShoppingListItem(this.Id, product.Id);

            Items.Add(link);
        }

        public void Rename(string newName)
        {
            Name = newName;
        }
    }
}