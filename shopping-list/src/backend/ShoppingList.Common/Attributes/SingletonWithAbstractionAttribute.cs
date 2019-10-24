namespace ShoppingList.Common.Attributes
{
    using System;

    public class SingletonWithAbstractionAttribute : AbstractionAttribute
    {
        public SingletonWithAbstractionAttribute(Type abstractionType) : base(abstractionType)
        {
        }
    }
}