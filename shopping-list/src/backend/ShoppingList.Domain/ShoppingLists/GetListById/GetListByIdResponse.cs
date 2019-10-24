namespace ShoppingList.Domain.ShoppingLists.GetListById
{
    using System.Collections.Generic;

    public class GetListByIdResponse
    {
        public string ShoppingListName { get; set; }
        public List<GetListByIdItem> Items { get; set; }
    }

    public class GetListByIdItem
    {
        public int ItemId { get; set; }
        public string ProductName { get; set; }
        public bool AlreadyBought { get; set; }
    }
}