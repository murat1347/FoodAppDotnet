using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.ViewModels;
using TilkiWeb.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;
using Image = TilkiWeb.Domain.Entities.Image;

namespace TilkiWeb.Application.Features.Commands.Foods.CreateFood
{
    public class CreateFoodCommandRequest : IRequest<CreateFoodCommandResponse>
    {
        public string Name { get; set; }
        public FoodImageFiles FoodImageFiles { get; set; }
        public string Description { get; set; }
        public string? CategoryId { get; set; }

    }
}
