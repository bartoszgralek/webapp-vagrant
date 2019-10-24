namespace ShoppingList.Domain.ShoppingLists
{
    using System.Collections.Generic;
    using Common;
    using Common.Database;

    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public List<ShoppingListItem> ShoppingLists { get; set; }

        public static Product Create(string productName)
        {
            return new Product
            {
                Name = productName
            };
        }
    }
}