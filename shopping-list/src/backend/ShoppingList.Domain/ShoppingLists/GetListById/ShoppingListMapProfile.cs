namespace ShoppingList.Domain.ShoppingLists.GetListById
{
    using AutoMapper;

    public class ShoppingListMapProfile : Profile
    {
        public ShoppingListMapProfile()
        {
            CreateMap<ShoppingList, GetListByIdResponse>()
                .ForMember(response => response.Items, opt => opt.MapFrom(sl => sl.Items))
                .ForMember(response => response.ShoppingListName, opt => opt.MapFrom(sl => sl.Name));

            CreateMap<ShoppingLists.ShoppingListItem, GetListByIdItem>()
                .ForMember(product => product.ItemId, opt => opt.MapFrom(l => l.Id))
                .ForMember(product => product.AlreadyBought, opt => opt.MapFrom(l => l.AlreadyBought))
                .ForMember(product => product.ProductName, opt => opt.MapFrom(l => l.Product.Name));
        }
    }
}