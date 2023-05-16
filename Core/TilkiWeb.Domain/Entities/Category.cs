using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilkiWeb.Domain.Entities
{
    public class Category: BaseEntity
    {
        public virtual Category? Parent { get; set; }

        public Guid? ParentId { get; set; }

        public string? Defination { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<Food> Foods { get; set; }

        public Category()
        {
            Foods = new List<Food>();
        }

    }
}
