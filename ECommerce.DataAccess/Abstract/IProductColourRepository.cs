﻿using ECommerce.Core.Models.Response.Colours;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IProductColourRepository
    {
        Task<List<ProductColour>> GetAllAsync();
        Task<ProductColour> GetByIdAsync(int id);

        Task AddAsync(ProductColour productColour);
        Task UpdateAsync(ProductColour productColour);

        Task DeleteAsync(int id);

      
    }
}
