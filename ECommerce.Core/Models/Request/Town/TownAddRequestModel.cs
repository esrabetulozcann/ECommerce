using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.Town
{
    public class TownAddRequestModel
    {
        public string Name { get; set; }
        public int CityId { get; set; }
    }
}
