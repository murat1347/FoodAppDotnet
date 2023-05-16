using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Persistence.Context;

namespace TilkiWeb.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FoodAPIDBContext>
    {
        public FoodAPIDBContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<FoodAPIDBContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
