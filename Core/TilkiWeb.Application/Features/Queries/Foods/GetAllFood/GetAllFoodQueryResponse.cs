using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilkiWeb.Application.Features.Queries.Food.GetAllFood
{
    public class GetAllFoodQueryResponse
    {
        public int TotalCount { get; set; }
        public object Foods { get; set; }
    }
}

