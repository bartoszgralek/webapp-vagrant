namespace ShoppingList.Domain.ShoppingLists.SetAsAlreadyBought
{
    using System.Threading;
    using System.Threading.Tasks;
    using AddProductByName;
    using Common.Database;
    using global::ShoppingList.Common.Attributes;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    [ScopedWithAbstraction(typeof(IRequestHandler<SetAsAlreadyBoughtCommand, Unit>))]
    public class SetAsAlreadyBoughtCommandHandler : AsyncRequestHandler<SetAsAlreadyBoughtCommand>
    {
        private readonly IRepository<ShoppingListItem> _shoppingItemsRepository;

        public SetAsAlreadyBoughtCommandHandler(IRepository<ShoppingListItem> shoppingItemsRepository)
        {
            _shoppingItemsRepository = shoppingItemsRepository;
        }

        protected override async Task Handle(SetAsAlreadyBoughtCommand request, CancellationToken cancellationToken)
        {
            var shoppingItem = await _shoppingItemsRepository.GetAll()
                .SingleAsync(sli => sli.Id == request.ShoppingListItemId, cancellationToken);

            shoppingItem.ChangeStatus(request.AlreadyBought);

            await _shoppingItemsRepository.SaveChangesAsync();
        }
    }
}