namespace ShoppingList.Domain.ShoppingLists.RenameList
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Database;
    using global::ShoppingList.Common.Attributes;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    [ScopedWithAbstraction(typeof(IRequestHandler<RenameListCommand, Unit>))]
    public class RenameListCommandHandler : AsyncRequestHandler<RenameListCommand>
    {
        private readonly IRepository<ShoppingList> _shoppingListRepository;

        public RenameListCommandHandler(IRepository<ShoppingList> shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        protected override async Task Handle(RenameListCommand request, CancellationToken cancellationToken)
        {
            var shoppingList = await _shoppingListRepository.GetAll()
                .SingleAsync(list => list.Id == request.ListId, cancellationToken);

            shoppingList.Rename(request.NewName);

            await _shoppingListRepository.SaveChangesAsync();
        }
    }
}