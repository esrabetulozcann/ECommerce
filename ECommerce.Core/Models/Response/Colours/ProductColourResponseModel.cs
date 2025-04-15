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
        public int Id { get; set; }
        public string Name { get; set; }
        public ColourResponseModel Colours { get; set; }
        public ProductResponseModel Products { get; set; }
        public int ProductId { get; set; }
        public int ColourId { get; set; }
    }
}
