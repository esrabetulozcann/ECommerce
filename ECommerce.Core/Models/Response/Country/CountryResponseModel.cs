using ECommerce.Core.Models.Response.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Response.Country
{
    public class CountryResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityResponseModel> Cities { get; set; }
    }
}
