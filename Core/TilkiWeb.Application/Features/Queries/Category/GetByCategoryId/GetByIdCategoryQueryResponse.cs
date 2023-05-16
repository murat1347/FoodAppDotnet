using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Domain.Entities;

namespace TilkiWeb.Application.Features.Queries.Food.GetByIdFood
{
    public class GetByIdCategoryQueryResponse
    {
        public List<TilkiWeb.Domain.Entities.Category>? categories { get; set; }
    }
}
