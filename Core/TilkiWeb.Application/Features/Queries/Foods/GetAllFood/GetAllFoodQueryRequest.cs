using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.RequestParameters;

namespace TilkiWeb.Application.Features.Queries.Food.GetAllFood
{
    public class GetAllFoodQueryRequest : IRequest<GetAllFoodQueryResponse>
    {
        public Pagination pagination { get; set; }
    }
}
