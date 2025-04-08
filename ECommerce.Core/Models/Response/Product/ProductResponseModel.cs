using ECommerce.Core.Models.Response.Categories;
using ECommerce.Core.Models.Response.Colours;
using ECommerce.Core.Models.Response.Sizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Response.Product
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Barcode { get; set; }
        public string Brand { get; set; }

        public int CategoryId { get; set; }
       // public List<CategoryResponseModel> Categories { get; set; }
        public CategoryResponseModel Category { get; set; } // Tekil olduğu için bu mantıklı
        public List<ProductColourResponseModel> Colours { get; set; }
        public List<ProductSizeResponseModel> Sizes { get; set; }

    }
}
