namespace ShoppingList.Common.Attributes
{
    using System;

    public class ScopedWithAbstractionAttribute : AbstractionAttribute
    {
        public ScopedWithAbstractionAttribute(Type abstraction) : base(abstraction)
        {
        }
    }
}