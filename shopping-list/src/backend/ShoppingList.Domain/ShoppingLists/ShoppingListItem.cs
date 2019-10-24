namespace ShoppingList.Domain.ShoppingLists
{
    using Common.Database;

    public class ShoppingListItem : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }

        public ShoppingListItem(int shoppingListId, int productId)
        {
            ShoppingListId = shoppingListId;
            ProductId = productId;
        }

        public bool AlreadyBought { get; set; }

        public void ChangeStatus(bool alreadyBought)
        {
            AlreadyBought = alreadyBought;
        }
    }
}