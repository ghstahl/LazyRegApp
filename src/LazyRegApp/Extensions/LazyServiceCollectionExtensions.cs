using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace LazyRegApp.Extensions
{
    public static class LazyServiceCollectionExtensions
    {
        public static IServiceCollection AddLazyTransient<TService, TMetaData>(this IServiceCollection services,
            Func<IServiceProvider, TService> implementationFactory,
            TMetaData metaData)
            where TService : class
            where TMetaData : class
        {
            services.AddTransient<LazyWithMetaData<TService, TMetaData>>(serviceProvider => new LazyWithMetaData<TService, TMetaData>(
                () => implementationFactory.Invoke(serviceProvider), metaData));
            return services;
        }
        public static IServiceCollection AddLazyTransient<TService>(this IServiceCollection services,
            Func<IServiceProvider, TService> implementationFactory) where TService : class
        {
            services.AddTransient<Lazy<TService>>(serviceProvider => new Lazy<TService>(() => implementationFactory.Invoke(serviceProvider)));
            return services;
        }
        public static IServiceCollection AddLazyTransient<TService, TImplementation, TMetaData>(this IServiceCollection services,
            TMetaData metaData)
          where TService : class
          where TImplementation : class, TService
          where TMetaData : class
        {
            services.AddTransient<TImplementation>();
            services.AddTransient<LazyWithMetaData<TService, TMetaData>>(serviceProvider =>
            {

                return new LazyWithMetaData<TService, TMetaData>(() =>
                {
                    var impl = serviceProvider.GetRequiredService<TImplementation>();
                    return impl;
                }, metaData);
            });
            return services;
        }

        public static IServiceCollection AddLazyTransient<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddTransient<TImplementation>();
            services.AddTransient<Lazy<TService>>(serviceProvider =>
            {

                return new Lazy<TService>(() =>
                {
                    var impl = serviceProvider.GetRequiredService<TImplementation>();
                    return impl;
                });
            });
            return services;
        }
        public static IServiceCollection AddLazySingleton<TService, TMetaData>(this IServiceCollection services,
             Func<IServiceProvider, TService> implementationFactory, TMetaData metaData)
             where TService : class
             where TMetaData : class
        {
            services.AddSingleton<LazyWithMetaData<TService, TMetaData>>(serviceProvider => new LazyWithMetaData<TService, TMetaData>(
                () => implementationFactory.Invoke(serviceProvider), metaData));
            return services;
        }
        public static IServiceCollection AddLazySingleton<TService>(this IServiceCollection services,
            Func<IServiceProvider, TService> implementationFactory) where TService : class
        {
            services.AddSingleton<Lazy<TService>>(serviceProvider => new Lazy<TService>(() => implementationFactory.Invoke(serviceProvider)));
            return services;
        }
        public static IServiceCollection AddLazySingleton<TService, TImplementation, TMetaData>(this IServiceCollection services,
            TMetaData metaData)
            where TService : class
            where TImplementation : class, TService
            where TMetaData : class
        {
            services.AddSingleton<TImplementation>();
            services.AddSingleton<LazyWithMetaData<TService, TMetaData>>(serviceProvider =>
            {

                return new LazyWithMetaData<TService, TMetaData>(() =>
                {
                    var impl = serviceProvider.GetRequiredService<TImplementation>();
                    return impl;
                }, metaData);
            });
            return services;
        }
        public static IServiceCollection AddLazySingleton<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddSingleton<TImplementation>();
            services.AddSingleton<Lazy<TService>>(serviceProvider =>
            {

                return new Lazy<TService>(() =>
                {
                    var impl = serviceProvider.GetRequiredService<TImplementation>();
                    return impl;
                });
            });
            return services;
        }
        public static IServiceCollection AddLazyScoped<TService, TMetaData>(this IServiceCollection services,
            Func<IServiceProvider, TService> implementationFactory, TMetaData metaData)
            where TService : class
            where TMetaData : class
        {
            services.AddScoped<LazyWithMetaData<TService, TMetaData>>(serviceProvider => new LazyWithMetaData<TService, TMetaData>(
                () => implementationFactory.Invoke(serviceProvider), metaData));
            return services;
        }
        public static IServiceCollection AddLazyScoped<TService>(this IServiceCollection services,
            Func<IServiceProvider, TService> implementationFactory) where TService : class
        {
            services.AddScoped<Lazy<TService>>(serviceProvider => new Lazy<TService>(() => implementationFactory.Invoke(serviceProvider)));
            return services;
        }
        public static IServiceCollection AddLazyScoped<TService, TImplementation, TMetaData>(this IServiceCollection services,
            TMetaData metaData)
            where TService : class
            where TImplementation : class, TService
            where TMetaData : class
        {
            services.AddScoped<TImplementation>();
            services.AddScoped<LazyWithMetaData<TService, TMetaData>>(serviceProvider =>
            {

                return new LazyWithMetaData<TService, TMetaData>(() =>
                {
                    var impl = serviceProvider.GetRequiredService<TImplementation>();
                    return impl;
                }, metaData);
            });
            return services;
        }
        public static IServiceCollection AddLazyScoped<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddScoped<TImplementation>();
            services.AddScoped<Lazy<TService>>(serviceProvider =>
            {

                return new Lazy<TService>(() =>
                {
                    var impl = serviceProvider.GetRequiredService<TImplementation>();
                    return impl;
                });
            });
            return services;
        }

    }
}
