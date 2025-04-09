using ECommerce.Core.Models.Response.Colours;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IColourRepository
    {
        Task<List<Colour>> GetAllAsync();
        Task<Colour> GetByIdAsync(int id);
        Task<Colour> GetByNameAsync(string name);

    }
}
