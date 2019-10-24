namespace ShoppingList.Domain.ShoppingLists.SetAsAlreadyBought
{
    using Common.MediatR;

    public class SetAsAlreadyBoughtCommand : ICommand
    {
        public int ShoppingListItemId { get; set; }
        public bool AlreadyBought { get; set; }
    }
}