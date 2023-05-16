using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.Features.Queries.Food.GetByIdFood;
using TilkiWeb.Application.IRepositories;

namespace TilkiWeb.Application.Features.Queries
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {

        readonly ICategoryReadRepository _categoryReadRepository;
        public GetByIdCategoryQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {

            //var foodbycategory =   await _categoryReadRepository.GetByIdAsync(request.Id, false);

            List<Domain.Entities.Category> productsList = await _categoryReadRepository.GetAll()
                .Where(f => request.Id == null || f.ParentId == Guid.Parse(request.Id))
                .ToListAsync();
            List<TilkiWeb.Domain.Entities.Category> categories = productsList;
            return new()
            {
                categories = categories.ToList()
                    
            };
        }
    }
}
