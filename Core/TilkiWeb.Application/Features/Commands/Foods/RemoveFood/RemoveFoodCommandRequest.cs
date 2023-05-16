using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilkiWeb.Application.Features.Commands.Food.RemoveFood
{
    public class RemoveFoodCommandRequest : IRequest<RemoveFoodCommandResponse>
    {
        public string Id { get; set; }
    }
}
