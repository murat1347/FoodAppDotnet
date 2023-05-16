using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.Features.Queries.Food.GetAllFood;

namespace TilkiWeb.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryRequest: IRequest<GetAllCategoryQueryResponse>
    {
    }
}
