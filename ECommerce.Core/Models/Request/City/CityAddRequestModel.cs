using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.City
{
    public class CityAddRequestModel
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
