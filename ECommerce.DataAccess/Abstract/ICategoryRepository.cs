using ECommerce.DataAccess.Models;

namespace ECommerce.DataAccess.Abstract
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> GetByNameAsync(string name);
    }
}
