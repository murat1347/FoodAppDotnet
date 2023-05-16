using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TilkiWeb.Application.IRepositories;
using TilkiWeb.Domain.Entities;
using TilkiWeb.Persistence.Context;

namespace TilkiWeb.Persistence.Repositories
{

    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly FoodAPIDBContext _context;

        public ReadRepository(FoodAPIDBContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true, bool includeFoodImageFiles = false)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            if (includeFoodImageFiles && typeof(T) == typeof(Food))
            {
                query = (IQueryable<T>)((IQueryable<Food>)query)
            .Include(f => f.FoodImageFiles)
            .ThenInclude(fif => fif.Images);
            }

            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }


        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(method);
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }


    }
}
