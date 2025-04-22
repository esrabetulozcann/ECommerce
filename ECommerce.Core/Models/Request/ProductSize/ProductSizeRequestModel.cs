using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.ProductSize
{

    [NotMapped]
    public class ProductSizeRequestModel
    {
        public int ProductId { get; set; }  
    }
}
