using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.Features.Commands.Food.RemoveFood;
using TilkiWeb.Application.IRepositories;

namespace TilkiWeb.Application.Features.Commands.Food.DeleteFood
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveFoodCommandRequest, RemoveFoodCommandResponse>
    {
        readonly IFoodWriteRepository _productWriteRepository;

        public RemoveProductCommandHandler(IFoodWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<RemoveFoodCommandResponse> Handle(RemoveFoodCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.RemoveAsync(request.Id);
            await _productWriteRepository.SaveChanges();
            return new();
        }
    }
}
