using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.Features.Queries.Food.GetByIdFood;
using TilkiWeb.Application.IRepositories;

namespace TilkiWeb.Application.Features.Queries.Foods.FindFood
{
    public class GetFindFoodQueryHandler : IRequestHandler<GetFindFoodQueryRequest, GetFindQueryResponse>
    {

        readonly IFoodReadRepository _foodReadRepository;
        public GetFindFoodQueryHandler(IFoodReadRepository foodReadRepository)
        {
            _foodReadRepository = foodReadRepository;
        }

        public async Task<GetFindQueryResponse> Handle(GetFindFoodQueryRequest request, CancellationToken cancellationToken)
        {
            List<TilkiWeb.Domain.Entities.Food> food = await _foodReadRepository.GetFindAsync(request.Text,false,true);
            return new()
            {
                Foods = food,
            };
        }
    }
}
