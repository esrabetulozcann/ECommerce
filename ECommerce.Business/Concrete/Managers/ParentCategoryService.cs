using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Response.Categories;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Concrete;
using ECommerce.DataAccess.Models;

namespace ECommerce.Business.Concrete.Managers
{
    public class ParentCategoryService : IParentCategoryService
    {
        private readonly IParentCategoryRepository _parentCategoryRepository;
        public ParentCategoryService(IParentCategoryRepository parentCategoryRepository)
        {
            _parentCategoryRepository = parentCategoryRepository;
        }

        public async Task<List<BaseDTO>> GetAllAsync()
        {
            var result = await _parentCategoryRepository.GetAllAsync();

            List<BaseDTO> responseModels = new List<BaseDTO>();

            responseModels = result.Select(pc => new BaseDTO
            {
                Id = pc.Id,
                Name = pc.Name,
             
            }).ToList();
            return responseModels;

        }

        public async Task<List<ParentCategoryResponseModel>> GetByIdAsync(int id)
        {
            var result = await _parentCategoryRepository.GetByIdAsync(id);
            List<ParentCategoryResponseModel> responseModels = new List<ParentCategoryResponseModel>();

            responseModels = result.Select(pc => new ParentCategoryResponseModel
            {
                Id = pc.Id,
                Name = pc.Name,
                Category = pc.Categories.Select(c => new CategoryResponseModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),

            }).ToList();

            return responseModels;
        }

        public async Task<List<ParentCategoryResponseModel>> GetAllWithCategories()
        {
            var result = await _parentCategoryRepository.GetAllWithCategories();
            List<ParentCategoryResponseModel> responseModels = new List<ParentCategoryResponseModel>();

            responseModels = result.Select(pc => new ParentCategoryResponseModel
            {
                Id = pc.Id,
                Name = pc.Name,
                Category = pc.Categories.Select(c => new CategoryResponseModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList(),

            }).ToList();

            return responseModels;
        }

        



    }
}
