namespace ShoppingList.Api.Configuration
{
    using System.Reflection;
    using Common.Attributes;
    using DataAccess.Common;
    using Domain.Common.Database;

    public static class MyAssembly
    {
        public static Assembly[] Assemblies => new []
        {
            // ShoppingList.Domain
            typeof(BaseEntity).Assembly,

            // ShoppingList.DataAccess
            typeof(ShoppingListDbContext).Assembly,

            // ShoppingList.Common
            typeof(ScopedAttribute).Assembly,

            // ShoppingList.Api
            typeof(MyAssembly).Assembly
        };
    }
}