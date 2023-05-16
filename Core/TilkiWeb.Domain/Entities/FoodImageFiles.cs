using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilkiWeb.Domain.Entities
{
    public class FoodImageFiles : BaseEntity
    {
        public virtual ICollection<Image> Images { get; set; }
    }
}
