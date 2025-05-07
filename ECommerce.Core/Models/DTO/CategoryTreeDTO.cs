using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.DTO
{
    public class CategoryTreeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public List<CategoryTreeDTO> Children { get; set; } = new();
    }
}
