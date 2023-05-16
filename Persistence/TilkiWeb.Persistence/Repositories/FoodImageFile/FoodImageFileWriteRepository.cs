using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.IRepositories.FoodImageFile;
using TilkiWeb.Domain.Entities;
using TilkiWeb.Persistence.Context;
using TilkiWeb.Persistence.Repositories;
namespace TilkiWeb.Persistence.Repositories
{
    public class FoodImageFileWriteRepository : WriteRepository<FoodImageFiles>, IFoodImageFileWriteRepository
    {
        public FoodImageFileWriteRepository(FoodAPIDBContext context) : base(context)
        {
        }
    }
}
