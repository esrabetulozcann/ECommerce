using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Response.Product
{
    public class ProductImagesResponseModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public String ImageUrl { get; set; }
        public List<ProductResponseModel> Products { get; set; }
    }
}
