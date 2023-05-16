using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Domain.Entities;

namespace TilkiWeb.Application.Features.Queries.Food.GetByIdFood
{
    public class GetByIdFoodQueryResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public FoodImageFiles FoodImageFiles{ get; set; }
    }
}
