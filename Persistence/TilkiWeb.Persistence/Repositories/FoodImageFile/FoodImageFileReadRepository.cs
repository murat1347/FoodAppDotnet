using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.IRepositories.FoodImageFile;
using TilkiWeb.Domain.Entities;
using TilkiWeb.Persistence.Context;

namespace TilkiWeb.Persistence.Repositories.FoodImageFile
{
    public class FoodImageFileReadRepository : ReadRepository<TilkiWeb.Domain.Entities.FoodImageFiles>, IFoodImageFileReadRepository
    {
        private readonly FoodAPIDBContext _dbContext;
        public FoodImageFileReadRepository(FoodAPIDBContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task LoadAsync(FoodImageFiles foodImageFiles, Expression<Func<FoodImageFiles, object>> includeProperties)
        {
            await _dbContext.Entry(foodImageFiles)
                .Collection(fif => fif.Images)
                .Query()
                .Include(includeProperties.ToString())
                .LoadAsync();
        }
    }
}
