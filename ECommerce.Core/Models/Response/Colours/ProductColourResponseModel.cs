using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Response.Colours
{
    public class ProductColourResponseModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<BaseDTO> Colours { get; set; }
        public bool IsDelete { get; set; }  
    
    }
}
