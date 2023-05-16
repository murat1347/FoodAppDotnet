using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilkiWeb.Application.Features.Queries.Food.GetByIdFood
{
    public class GetFindQueryRequest : IRequest<GetByIdFoodQueryResponse>
    {
        public string Id { get; set; }
    }
}
