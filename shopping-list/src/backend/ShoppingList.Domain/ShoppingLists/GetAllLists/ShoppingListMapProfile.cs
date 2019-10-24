namespace ShoppingList.Domain.ShoppingLists.GetAllLists
{
    using AutoMapper;

    public class ShoppingListMapProfile : Profile
    {
        public ShoppingListMapProfile()
        {
            CreateMap<ShoppingList, GetAllListsResponseItem>()
                .ForMember(item => item.ListId, opt => opt.MapFrom(list => list.Id))
                .ForMember(item => item.ListName, opt => opt.MapFrom(list => list.Name));
        }
    }
}