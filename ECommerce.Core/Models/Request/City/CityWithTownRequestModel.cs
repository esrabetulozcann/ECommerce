using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.City
{
    public class CityWithTownRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Town { get; set; }
    }
}
