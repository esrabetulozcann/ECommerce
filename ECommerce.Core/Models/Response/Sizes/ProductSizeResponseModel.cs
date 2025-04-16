using ECommerce.Core.Models.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Response.Sizes
{
    public class ProductSizeResponseModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        //public string SizeName { get; set; }
        //public int SizeId { get; set; }

        public List<SizeResponseModel> Sizes { get; set; }
        //public List<ProductResponseModel> Products { get; set; }
        //public SizeResponseModel Size { get; set; }
    }
}
