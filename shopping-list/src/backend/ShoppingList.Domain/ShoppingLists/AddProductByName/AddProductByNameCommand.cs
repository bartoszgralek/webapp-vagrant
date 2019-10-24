namespace ShoppingList.Domain.ShoppingLists.AddProductByName
{
    using Common.MediatR;

    public class AddProductByNameCommand : ICommand
    {
        public int ShoppingListId { get; set; }
        public string ProductName { get; set; }
    }
}