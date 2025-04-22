using ECommerce.Core.Models.Request.ProductSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.Size
{
    public class SizeRequestModel
    {
        public string Name { get; set; }
        public int SizeTypeId { get; set; } 
        public bool IsDelete { get; set; }  

        public List<ProductSizeRequestModel> productSizes { get; set; }
    }
}
