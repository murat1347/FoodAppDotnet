using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.IRepositories;
using TilkiWeb.Domain.Entities;
using TilkiWeb.Persistence.Context;

namespace TilkiWeb.Persistence.Repositories
{
    public class FoodReadRepository : ReadRepository<Food>, IFoodReadRepository
    {
        private readonly FoodAPIDBContext _context;

        public FoodReadRepository(FoodAPIDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Food>> GetFindAsync(string text, bool tracking = true, bool includeFoodImageFiles = false)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            if (includeFoodImageFiles)
            {
                query = ((IQueryable<Food>)query)
                    .Include(f => f.FoodImageFiles)
                    .ThenInclude(fif => fif.Images);
            }
            return await query.Where(p => p.Description.Contains(text) || p.Title.Contains(text)).ToListAsync(); ;
        }

    }
}
