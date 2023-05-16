using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TilkiWeb.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string ImageUrl { get; set; }

    }

}
