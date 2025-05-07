using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.Address
{
    public class AddressUpdateRequestModel
    {
        public string AddressText { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int DistrictId { get; set; }
        public int TownId { get; set; }
        public string PostalCode { get; set; }
    }
}
