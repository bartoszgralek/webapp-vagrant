namespace ShoppingList.Domain.ShoppingLists.GetAllLists
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common.Database;
    using global::ShoppingList.Common.Attributes;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    [ScopedWithAbstraction(typeof(IRequestHandler<GetAllListsQuery, GetAllListsResponse>))]
    public class GetAllListsQueryHandler : IRequestHandler<GetAllListsQuery, GetAllListsResponse>
    {
        private readonly IRepository<ShoppingList> _shoppingListRepository;
        private readonly IMapper _mapper;

        public GetAllListsQueryHandler(IRepository<ShoppingList> shoppingListRepository, IMapper mapper)
        {
            _shoppingListRepository = shoppingListRepository;
            _mapper = mapper;
        }

        public async Task<GetAllListsResponse> Handle(GetAllListsQuery request, CancellationToken cancellationToken)
        {
            var shoppingLists = await _shoppingListRepository.GetAll().ToListAsync(cancellationToken);

            return new GetAllListsResponse
            {
                ShoppingLists = _mapper.Map<List<GetAllListsResponseItem>>(shoppingLists)
            };
        }
    }
}