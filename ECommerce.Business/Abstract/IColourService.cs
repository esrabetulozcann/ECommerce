using ECommerce.Core.Models.Response.Colours;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IColourService
    {
        Task<List<Colour>> GetAllAsync();
        Task<ColourResponseModel> GetByIdAsync(int id);
        Task<ColourResponseModel> GetByNameAsync(string name);
    }
}
