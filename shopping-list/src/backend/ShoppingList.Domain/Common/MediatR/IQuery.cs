namespace ShoppingList.Domain.Common.MediatR
{
    using global::MediatR;

    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
        
    }
}