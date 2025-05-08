using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.DTO
{
    public class CategoryTreeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<CategoryTreeDTO> Children { get; set; } = new();
    }
}
