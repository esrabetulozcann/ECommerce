using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.ProductSize
{
    public class ProductSizeAddRequestModel
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
    }
}
