namespace ShoppingList.Domain.ShoppingLists.AddList
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Common.Database;
    using global::ShoppingList.Common.Attributes;
    using MediatR;

    [ScopedWithAbstraction(typeof(IRequestHandler<AddListCommand, Unit>))]
    public class AddListCommandHandler : AsyncRequestHandler<AddListCommand>
    {
        private readonly IRepository<ShoppingList> _shoppingListRepository;

        public AddListCommandHandler(IRepository<ShoppingList> shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        protected override async Task Handle(AddListCommand command, CancellationToken cancellationToken)
        {
            var shoppingList = ShoppingList.Create(
                shoppingListName: command.ListName);

            await _shoppingListRepository.AddAsync(shoppingList);
            await _shoppingListRepository.SaveChangesAsync();
        }
    }
}