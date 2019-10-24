namespace ShoppingList.Domain.ShoppingLists.RenameList
{
    using Common.MediatR;

    public class RenameListCommand: ICommand
    {
        public int ListId { get; set; }
        public string NewName { get; set; }
    }
}
