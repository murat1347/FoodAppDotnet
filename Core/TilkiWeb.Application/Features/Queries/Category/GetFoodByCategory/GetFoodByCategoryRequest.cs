using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilkiWeb.Application.Features.Queries.Category.GetFoodByCategory
{
    public class GetFoodByCategoryRequest: IRequest<GetFoodByCategoryResponse>
    {
        public string CategoryId { get; set; }
    }
}
