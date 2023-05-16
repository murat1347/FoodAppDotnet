using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.IRepositories;

namespace TilkiWeb.Application.Features.Queries.Food.GetAllFood
{
    public class GetAllFoodQueryHandler : IRequestHandler<GetAllFoodQueryRequest, GetAllFoodQueryResponse>
    {
        readonly IFoodReadRepository _foodReadRepository;
        readonly ILogger<GetAllFoodQueryHandler> _logger;
        public GetAllFoodQueryHandler(IFoodReadRepository foodReadRepository, ILogger<GetAllFoodQueryHandler> logger)
        {
            _foodReadRepository = foodReadRepository;
            _logger = logger;
        }

        public async Task<GetAllFoodQueryResponse> Handle(GetAllFoodQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get all foods");
            var totalCount = _foodReadRepository.GetAll(false).Count();
            var foods = _foodReadRepository.GetAll(false).Skip(request.pagination.Page * request.pagination.Size).Take(request.pagination.Size).Select(p => new
            {
                p.Id,
                p.Title,
                p.CreatedDate,
                p.UpdatedDate,
                p.FoodImageFiles
            }).ToList();
            return new()
            {
                Foods = foods,
                TotalCount = totalCount
            };
        }
    }
}
