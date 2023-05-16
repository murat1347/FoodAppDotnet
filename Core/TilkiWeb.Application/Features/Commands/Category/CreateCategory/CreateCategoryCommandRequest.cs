using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.ViewModels;

namespace TilkiWeb.Application.Features.Commands.Foods.CreateFood
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string? ParentId { get; set; }
        
    }
}
