using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilkiWeb.Application.Features.Queries.Foods.FindFood
{
    public class GetFindFoodQueryRequest : IRequest<GetFindQueryResponse>
    {
        public string Text { get; set; }
    }
}
