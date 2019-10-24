namespace ShoppingList.Api.Configuration.DependencyInjection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using NLog;
    using ShoppingList.Common.Attributes;

    public static class RegisterTypesMiddleware
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static IServiceCollection RegisterTypesByAttributes(this IServiceCollection services)
        {
            return services
                .RegisterTypesHaving<ScopedAttribute>(services.AddScoped)
                .RegisterTypesWithAbstractionsHaving<ScopedWithAbstractionAttribute>(services.AddScoped)
                .RegisterTypesHaving<TransientAttribute>(services.AddTransient)
                .RegisterTypesWithAbstractionsHaving<TransientWithAbstractionAttribute>(services.AddTransient)
                .RegisterTypesHaving<SingletonAttribute>(services.AddSingleton)
                .RegisterTypesWithAbstractionsHaving<SingletonWithAbstractionAttribute>(services.AddSingleton);
        }

        private static IServiceCollection RegisterTypesHaving<TAttribute>(this IServiceCollection services, Func<Type, IServiceCollection> register) where TAttribute : Attribute
        {
            foreach (var assembly in MyAssembly.Assemblies)
            {
                var types = assembly.GetTypesWithAttribute<TAttribute>();
                foreach (var type in types)
                {
                    Logger.Info(() => $"Registering {type.Name} with {typeof(TAttribute).Name}");
                    register(type);
                }
            }

            return services;
        }

        private static IServiceCollection RegisterTypesWithAbstractionsHaving<TAttribute>(this IServiceCollection services, Func<Type, Type, IServiceCollection> register) where TAttribute : AbstractionAttribute
        {
            foreach (var assembly in MyAssembly.Assemblies)
            {
                var types = assembly.GetTypesWithAbstractionAttribute<TAttribute>();
                foreach (var (type, attribute) in types)
                {

                    var abstraction = attribute.AbstractionType;

                    Logger.Info(() => $"Registering {type.Name} and interface {abstraction.Name} with {typeof(TAttribute).Name}");
                    register(abstraction, type);
                }
            }

            return services;
        }

        private static IEnumerable<Type> GetTypesWithAttribute<TAttribute>(this Assembly assembly) where TAttribute : Attribute
        {
            return assembly
                .GetTypes()
                .Where(type => type.GetAttribute<TAttribute>() != null);
        }

        private static IEnumerable<KeyValuePair<Type, AbstractionAttribute>> GetTypesWithAbstractionAttribute<TAttribute>(this Assembly assembly) where TAttribute : AbstractionAttribute
        {
            return assembly
                .GetTypes()
                .Select(type => new KeyValuePair<Type, AbstractionAttribute>(type, type.GetAttribute<TAttribute>()))
                .Where(pair => pair.Value != null);
        }

        private static TAttribute GetAttribute<TAttribute>(this Type type) where TAttribute : Attribute
        {
            return type.GetCustomAttributes<TAttribute>().SingleOrDefault();
        }
    }
}