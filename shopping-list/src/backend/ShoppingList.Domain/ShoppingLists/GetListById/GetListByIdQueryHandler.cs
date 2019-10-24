namespace ShoppingList.Domain.ShoppingLists.GetListById
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common.Database;
    using global::ShoppingList.Common.Attributes;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    [ScopedWithAbstraction(typeof(IRequestHandler<GetListByIdQuery, GetListByIdResponse>))]
    public class GetListByIdQueryHandler : IRequestHandler<GetListByIdQuery, GetListByIdResponse>
    {
        private readonly IRepository<ShoppingList> _shoppingListRepository;
        private readonly IMapper _mapper;

        public GetListByIdQueryHandler(IRepository<ShoppingList> shoppingListRepository, IMapper mapper)
        {
            _shoppingListRepository = shoppingListRepository;
            _mapper = mapper;
        }

        public async Task<GetListByIdResponse> Handle(GetListByIdQuery request, CancellationToken cancellationToken)
        {
            var shoppingList = await _shoppingListRepository
                .GetAll()
                .Include(sl => sl.Items)
                    .ThenInclude(p => p.Product)
                .SingleAsync(sl => sl.Id == request.ShoppingListId, cancellationToken);


            return _mapper.Map<GetListByIdResponse>(shoppingList);
        }
    }
}