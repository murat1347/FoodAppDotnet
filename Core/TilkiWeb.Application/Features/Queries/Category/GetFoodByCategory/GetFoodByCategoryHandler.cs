using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.Features.Queries.Food.GetAllFood;
using TilkiWeb.Application.IRepositories;
using TilkiWeb.Application.IRepositories.FoodImageFile;
using TilkiWeb.Domain.Entities;

namespace TilkiWeb.Application.Features.Queries.Category.GetFoodByCategory
{
    internal class GetFoodByCategoryHandler : IRequestHandler<GetFoodByCategoryRequest, GetFoodByCategoryResponse>
    {
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly IFoodReadRepository _foodReadRepository;
        readonly IFoodImageFileReadRepository _foodImageFileReadRepository;

        public GetFoodByCategoryHandler(ICategoryReadRepository categoryReadRepository, IFoodReadRepository foodReadRepository, IFoodImageFileReadRepository foodImageFileReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _foodReadRepository = foodReadRepository;
            _foodImageFileReadRepository = foodImageFileReadRepository;
        }

        public async Task<GetFoodByCategoryResponse> Handle(GetFoodByCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetAll()
                  .Where(c => request.CategoryId == null || c.Id == Guid.Parse(request.CategoryId))
                  .FirstOrDefaultAsync();

            List<TilkiWeb.Domain.Entities.Food> hepsi = _foodReadRepository.GetAll(true)
                .Where(p => p.CategoryId == category.Id)
                .Include(f => f.FoodImageFiles)
                    .ThenInclude(fi => fi.Images)
                .ToList();
            List<Domain.Entities.Food> foods = category?.Foods.ToList();

          

            return new()
            {
                Foods = hepsi

            };
        }
    }
}
