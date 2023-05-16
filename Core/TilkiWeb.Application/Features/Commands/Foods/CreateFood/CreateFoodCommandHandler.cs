using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.Abstractions.Hubs;
using TilkiWeb.Application.Features.Commands.Foods.CreateFood;
using TilkiWeb.Application.IRepositories;
using TilkiWeb.Application.ViewModels;
using TilkiWeb.Domain.Entities;

namespace TilkiWeb.Application.Features.Commands
{
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommandRequest, CreateFoodCommandResponse>
    {
        private readonly IFoodWriteRepository _foodWriteRepository;
        private readonly IFoodHubService _foodHubService;
        public CreateFoodCommandHandler(IFoodWriteRepository FoodWriteRepository, IFoodHubService foodHubService)
        {
            _foodWriteRepository = FoodWriteRepository;
            _foodHubService = foodHubService;
        }

        public async Task<CreateFoodCommandResponse> Handle(CreateFoodCommandRequest request, CancellationToken cancellationToken)
        {
            var res = await _foodWriteRepository.AddAsync(new()
            {
                Title = request.Name,
                Description = request.Description,
                CategoryId = Guid.Parse(request.CategoryId),
                FoodImageFiles = request.FoodImageFiles
            });

            await _foodWriteRepository.SaveChanges();
            await _foodHubService.FoodAddedMessageAsync($"{request.Name} foodAdded!");
            return new();
        }
    }
}

