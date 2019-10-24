namespace ShoppingList.Domain.ShoppingLists.GetListById
{
    using Common.MediatR;

    public class GetListByIdQuery : IQuery<GetListByIdResponse>
    {
        public GetListByIdQuery(int shoppingListId)
        {
            ShoppingListId = shoppingListId;
        }

        public int ShoppingListId { get; }
    }
}