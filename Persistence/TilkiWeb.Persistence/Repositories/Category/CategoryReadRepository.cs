using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.IRepositories;
using TilkiWeb.Domain.Entities;
using TilkiWeb.Persistence.Context;

namespace TilkiWeb.Persistence.Repositories
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(FoodAPIDBContext context) : base(context)
        {
        }
    }
}
