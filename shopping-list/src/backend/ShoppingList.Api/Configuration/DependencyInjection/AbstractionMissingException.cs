namespace ShoppingList.Api.Configuration.DependencyInjection
{
    using System;

    public class AbstractionMissingException : Exception
    {
        public AbstractionMissingException(string message) : base(message)
        {
        }
    }
}