namespace ShoppingList.Common.Attributes
{
    using System;

    public abstract class AbstractionAttribute : Attribute
    {
        public Type AbstractionType { get; }

        protected AbstractionAttribute(Type abstractionType)
        {
            AbstractionType = abstractionType;
        }
    }
}