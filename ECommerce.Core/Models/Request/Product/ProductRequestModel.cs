using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Response.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.Product
{
    public class ProductRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public string Brand { get; set; }
   




    }
}
