﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.Town
{
    public class TownWithDistrictRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object District { get; set; }
    }
}
