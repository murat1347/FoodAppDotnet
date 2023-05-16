using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.Abstractions.Hubs;
using TilkiWeb.Application.Features.Commands.Foods.CreateFood;
using TilkiWeb.Application.IRepositories;

namespace TilkiWeb.Application.Features.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _foodCategoryRepository;
        private readonly IFoodHubService _foodHubService;
        public CreateCategoryCommandHandler(ICategoryWriteRepository foodCategoryRepository, IFoodHubService foodHubService)
        {
            _foodCategoryRepository = foodCategoryRepository;
            _foodHubService = foodHubService;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var res = await _foodCategoryRepository.AddAsync(new()
            {
                Defination = request.Name,
                ImageUrl = request.ImageUrl,
                ParentId = request.ParentId!=null ? Guid.Parse(request.ParentId) : null,
               
          
            });
            await _foodCategoryRepository.SaveChanges();

            await _foodHubService.FoodAddedMessageAsync($"{request.Name} category added!");
            return new();
        }
    }
}

