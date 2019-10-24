namespace ShoppingList.Common.Attributes
{
    using System;

    public class TransientWithAbstractionAttribute: AbstractionAttribute
    {
        public TransientWithAbstractionAttribute(Type abstractionType) : base(abstractionType)
        {
        }
    }
}