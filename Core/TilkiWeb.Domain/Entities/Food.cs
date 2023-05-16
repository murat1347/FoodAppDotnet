using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TilkiWeb.Domain.Entities
{
    public class Food: BaseEntity
    {
        public string Title { get; set; }
        public System.Guid? FoodImageFilesId { get; set; }
   
        public virtual FoodImageFiles FoodImageFiles { get; set; }
        public string? Description { get; set; }

        public Guid CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}
