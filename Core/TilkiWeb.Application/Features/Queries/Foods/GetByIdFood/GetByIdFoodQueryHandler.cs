using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.IRepositories;

namespace TilkiWeb.Application.Features.Queries.Food.GetByIdFood
{
    public class GetByIdFoodQueryHandler : IRequestHandler<GetFindQueryRequest, GetByIdFoodQueryResponse>
    {

        readonly IFoodReadRepository _foodReadRepository;
        public GetByIdFoodQueryHandler(IFoodReadRepository foodReadRepository)
        {
            _foodReadRepository = foodReadRepository;
        }

        public async Task<GetByIdFoodQueryResponse> Handle(GetFindQueryRequest request, CancellationToken cancellationToken)
        {
            TilkiWeb.Domain.Entities.Food food = await _foodReadRepository.GetByIdAsync(request.Id, false, true);
            return new()
            {
                FoodImageFiles = food.FoodImageFiles,
                Title = food.Title,
                Description = food.Description
            };
        }
    }
}
