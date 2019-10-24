namespace ShoppingList.Domain.ShoppingLists.GetAllLists
{
    using System.Collections.Generic;

    public class GetAllListsResponse
    {
        public List<GetAllListsResponseItem> ShoppingLists { get; set; }
    }

    public class GetAllListsResponseItem
    {
        public int ListId { get; set; }
        public string ListName { get; set; }
    }
}