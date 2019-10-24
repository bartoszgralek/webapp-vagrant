namespace ShoppingList.Domain.ShoppingLists.AddList
{
    using Common;
    using Common.MediatR;

    public class AddListCommand : ICommand
    {
        public string ListName { get; set; }
    }
}