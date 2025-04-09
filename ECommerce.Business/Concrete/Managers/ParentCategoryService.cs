using ECommerce.Business.Abstract;
using ECommerce.Core.Models.Response.Categories;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Concrete;
using ECommerce.DataAccess.Models;

namespace ECommerce.Business.Concrete.Managers
{
    public class ParentCategoryService : IParentCategoryService
    {
        private IParentCategoryRepository _parentCategoryRepository;
        public ParentCategoryService(IParentCategoryRepository parentCategoryRepository)
        {
            _parentCategoryRepository = parentCategoryRepository;
        }

        public async Task<List<ParentCategory>> GetAllAsync()
        {
            var result =await _parentCategoryRepository.GetAllAsync();
            
            //if(result.FirstOrDefault().Categories == "Categor1")
            //{
            //    //code
            //}
            return await _parentCategoryRepository.GetAllAsync();
        }

        public async Task<ParentCategoryResponseModel> GetByIdAsync(int id)
        {
            return await _parentCategoryRepository.GetByIdAsync(id);
        }
    }
}
