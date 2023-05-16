using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Domain.Entities;

namespace TilkiWeb.Application.IRepositories.FoodImageFile
{
    public interface IFoodImageFileReadRepository : IReadRepository<TilkiWeb.Domain.Entities.FoodImageFiles>
    {
       
            Task LoadAsync(FoodImageFiles foodImageFiles, Expression<Func<FoodImageFiles, object>> includeProperties);
        
    }
}
