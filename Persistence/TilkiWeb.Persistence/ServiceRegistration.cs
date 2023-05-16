using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.Abstractions;
using TilkiWeb.Application.Abstractions.Hubs;
using TilkiWeb.Application.IRepositories;
using TilkiWeb.Application.IRepositories.FoodImageFile;
using TilkiWeb.Domain.Entities.Identity;
using TilkiWeb.Persistence.Context;
using TilkiWeb.Persistence.Repositories;
using TilkiWeb.Persistence.Repositories.FoodImageFile;
using TilkiWeb.Persistence.Services;
using TilkiWeb.Persistence.Services.Hubs;

namespace TilkiWeb.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<FoodAPIDBContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<FoodAPIDBContext>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddTransient<IFoodHubService, FoodHubService>();
            services.AddScoped<IFoodReadRepository, FoodReadRepository>();
            services.AddScoped<IFoodWriteRepository, FoodWriteRepository>();
            services.AddScoped<IFoodImageFileReadRepository, FoodImageFileReadRepository>();
            services.AddScoped<IFoodImageFileWriteRepository, FoodImageFileWriteRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();
            services.AddSignalR();
        }

    }
}
