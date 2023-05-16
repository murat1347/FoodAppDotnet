using Microsoft.Extensions.DependencyInjection;
using TilkiWeb.Application.Abstractions.Storage;
using TilkiWeb.Application.Abstractions.Token;
using TilkiWeb.Infrastructure.Services;
using TilkiWeb.Infrastructure.Services;
using TilkiWeb.Infrastructure.Services.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Infrastructure.Services.Storage;
using TilkiWeb.Persistence.Services.Storage.Local;
using TilkiWeb.Persistence.Services.Storage;

namespace TilkiWeb.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : class, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection)
        {
           
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                 
            }
        }
    }
