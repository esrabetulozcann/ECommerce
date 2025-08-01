﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Request.Category
{
    public class CategoryRequestModel
    {
        public int Id { get; set; }

        public int? ParentCategoryId { get; set; }

        public int? CategoryId { get; set; }

        public string Name { get; set; } = null!;

        public bool? IsActive { get; set; }
    }
}
