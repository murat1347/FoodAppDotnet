using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.Features.Queries.Food.GetAllFood;
using TilkiWeb.Application.IRepositories;

namespace TilkiWeb.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly ILogger<GetAllFoodQueryHandler> _logger;
        public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, ILogger<GetAllFoodQueryHandler> logger)
        {
            _categoryReadRepository = categoryReadRepository;
            _logger = logger;
        }

        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get all categories");
            
            var totalCount = _categoryReadRepository.GetAll(false).Where(x => x.ParentId == null).Count();

            var categories = _categoryReadRepository.GetAll(false)
                                                    .Where(x=>x.ParentId==null)
                                                    .Select(p => new
                                                    {
                                                        p.Id,
                                                        p.Defination,
                                                        p.ImageUrl,
                                                        p.ParentId,
                                                    }).ToList();

            return new()
            {
                Category = categories,
                TotalCount = totalCount
            };
        }

       
    }
}
