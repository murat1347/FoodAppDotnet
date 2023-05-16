using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Domain.Entities;

namespace TilkiWeb.Application.IRepositories
{
    public interface IFoodReadRepository : IReadRepository<Food>
    {
        Task<List<Food>> GetFindAsync(string text, bool tracking = true, bool includeFoodImageFiles = false);
    }
}
