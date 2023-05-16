using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.IRepositories;

namespace TilkiWeb.Application.Features.Commands.Food.UpdateFood
{
    public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommandRequest, UpdateFoodCommandResponse>
    {
        private readonly IFoodReadRepository _foodReadRepository;
        private readonly IFoodWriteRepository _foodWriteRepository;
        private readonly ILogger<UpdateFoodCommandHandler> _logger;
        public UpdateFoodCommandHandler(IFoodReadRepository productReadRepository, IFoodWriteRepository productWriteRepository, ILogger<UpdateFoodCommandHandler> logger)
        {
            _foodReadRepository = productReadRepository;
            _foodWriteRepository = productWriteRepository;
            _logger = logger;
        }

        public async Task<UpdateFoodCommandResponse> Handle(UpdateFoodCommandRequest request, CancellationToken cancellationToken)
        {
            TilkiWeb.Domain.Entities.Food food = await _foodReadRepository.GetByIdAsync(request.Id.ToString());
            food.Title = request.Name ;
            _logger.LogInformation("Food Updated!");
            await _foodWriteRepository.SaveChanges();

            return new();
        }
    }
}
