using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilkiWeb.Application.Features.Queries.Category.GetFoodByCategory
{
    public class GetFoodByCategoryResponse
    {
        public List<TilkiWeb.Domain.Entities.Food>? Foods { get; set; }
    }
}
