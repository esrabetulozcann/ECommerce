using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Response.Sizes
{
    public class SizeResponseModel
    {
        public int Id { get; set; }
        public int SizeTypeId { get; set; }
        public String Name { get; set; }
        public SizeTypeResponseModel SizeType { get; set; }
    }
}
