using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.Country
{
    [NotMapped]
    public class CountryAddRequestModel
    {
        public string Name { get; set; }
    }
}
