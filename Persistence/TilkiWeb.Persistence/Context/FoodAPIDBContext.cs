using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Domain.Entities;
using TilkiWeb.Domain.Entities.Identity;

namespace TilkiWeb.Persistence.Context
{
    public class FoodAPIDBContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public FoodAPIDBContext()
        {

        }
        public FoodAPIDBContext(DbContextOptions<FoodAPIDBContext> options) : base(options)
        {

        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
//        public DbSet<FoodImageFiles> ProductImageFiles { get; set; }
     //   public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<FoodImageFiles> FoodImageFiles { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas)
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => item.Entity.UpdatedDate = DateTime.UtcNow,
                     _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
