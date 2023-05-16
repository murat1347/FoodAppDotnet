using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Domain.Entities;

namespace TilkiWeb.Application.IRepositories
{
    public interface ICategoryWriteRepository : IWriteRepository<Category>
    {
    }
}
