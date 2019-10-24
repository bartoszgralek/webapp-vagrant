namespace ShoppingList.Domain.ShoppingLists.AddProductByName
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Database;
    using global::ShoppingList.Common.Attributes;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    [ScopedWithAbstraction(typeof(IRequestHandler<AddProductByNameCommand, Unit>))]
    public class AddProductByNameCommandHandler : AsyncRequestHandler<AddProductByNameCommand>
    {
        private readonly IRepository<ShoppingList> _shoppingListRepository;
        private readonly IRepository<Product> _productRepository;

        public AddProductByNameCommandHandler(IRepository<ShoppingList> shoppingListRepository,
            IRepository<Product> productRepository)
        {
            _shoppingListRepository = shoppingListRepository;
            _productRepository = productRepository;
        }

        protected override async Task Handle(AddProductByNameCommand request, CancellationToken cancellationToken)
        {
            var shoppingList = await _shoppingListRepository
                .GetAll()
                .Include(s => s.Items)
                .SingleAsync(sl => sl.Id == request.ShoppingListId, cancellationToken);

            var product = await _productRepository
                .GetAll()
                .SingleOrDefaultAsync(p => p.Name == request.ProductName, cancellationToken);

            if (product == null)
            {
                product = Product.Create(productName: request.ProductName);
                await _productRepository.AddAsync(product);
                await _productRepository.SaveChangesAsync();
            }
            
            shoppingList.AddProduct(product);

            await _shoppingListRepository.SaveChangesAsync();
        }
    }
}