using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
using ECommerce.Core.Models.Request.Category;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }



        public async Task<List<CategoryTreeDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();

            var categoryDict = categories.ToDictionary(c => c.Id);

            // Root kategorileri bulacağız. ParentCategoryId null olanları
            var rootCategories = categories
                .Where(c => c.ParentCategoryId == null)
                .Select(c => BuildTree(c, categories))
                .ToList();

            return rootCategories;
        }

        public async Task<CategoryTreeDTO?> GetCategoryTreeByNameAsync(string name)
        {
            var all = await _categoryRepository.GetAllCategoriesAsync();
            var match = all.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return match == null ? null : BuildTree(match, all);
        }

        public async Task<List<CategoryTreeDTO>> SearchCategoryTreesAsync(string keyword)
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();

            var matched = categories
                .Where(c => c.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .Select(c => BuildTree(c, categories))
                .ToList();

            return matched;
        }

        public async Task<List<CategoryTreeDTO>> SearchCategoryTreeWithAncestorsAsync(string keyword)
        {
            var allCategories = await _categoryRepository.GetAllCategoriesAsync();

            var matchedCategories = allCategories
                .Where(c => c.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            var rootCandidates = new HashSet<int>();

            foreach (var match in matchedCategories)
            {
                var current = match;
                while(current.ParentCategoryId != null)
                {
                    current = allCategories.FirstOrDefault(c => c.Id == current.ParentCategoryId);
                    if (current == null) break;
                }
                if(current != null) 
                    rootCandidates.Add(current.Id);
            }

            var resultTrees = allCategories
                .Where(c => rootCandidates.Contains(c.Id))
                .Select(c => BuildTreeWithFilter(c, allCategories, keyword))
                .Where(c => c != null)
                .ToList()!;

            return resultTrees;
        }


        public async Task<CategoryWithProductsDTO?> FindByIdAsync(int id)
        {
            // Ana kategoriyi getir
            var category = await _categoryRepository.FindByIdAsync(id);
            if (category == null)
                return null;

            // Bütün kategorileri getir (alt kategorileri bulmak için)
            var allCategories = await _categoryRepository.GetAllCategoriesAsync();

            // Alt kategoriler
            var children = allCategories
                .Where(c => c.ParentCategoryId == category.Id)
                .Select(c => new CategoryChildDTO
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            // Ürünleri ProductRepository'den çek
            var productsFromRepo = await _productRepository.GetByCategoryIdAsync(category.Id);

            var products = productsFromRepo.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ProductImages != null && p.ProductImages.Any() ? p.ProductImages.FirstOrDefault().ImageUrl : null
            }).ToList();

            return new CategoryWithProductsDTO
            {
                Id = category.Id,
                Name = category.Name,
                Children = children,
                Products = products
            };
        }

        /*public async Task<CategoryRequestModel> FindByIdAsync(int id)
        {
            var result = await _categoryRepository.FindByIdAsync(id);
            if(result == null)
            {
                return new CategoryRequestModel();
            }
            else
            {
                CategoryRequestModel categoryRequestModel = new CategoryRequestModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    CategoryId = result.CategoryId,
                    IsActive = result.IsActive,
                    ParentCategoryId = result.ParentCategoryId,

                };

                return categoryRequestModel;
            }
        }
        */



        private CategoryTreeDTO BuildTree(Category category, List<Category> allCategories)
        {
            var childrenByParent = allCategories
        .Where(c => c.ParentCategoryId == category.Id)
        .ToList();

            var childrenByCategory = allCategories
                .Where(c => c.CategoryId == category.Id && c.ParentCategoryId != category.Id)
                .ToList();

            var allChildren = childrenByParent
                .Concat(childrenByCategory)
                .DistinctBy(c => c.Id)
                .ToList();

            var childTrees = allChildren.Select(c => BuildTree(c, allCategories)).ToList();

            return new CategoryTreeDTO
            {
                Id = category.Id,
                Name = category.Name,
                Children = childTrees.Any() ? childTrees : null
            };
        }

        private CategoryTreeDTO? BuildTreeWithFilter(Category category, List<Category> allCategories, string keyword)
        {
            // Hem ParentCategoryId hem CategoryId ile eşleşen çocukları topla
            var childrenByParent = allCategories
                .Where(c => c.ParentCategoryId == category.Id)
                .ToList();

            var childrenByCategory = allCategories
                .Where(c => c.CategoryId == category.Id && c.ParentCategoryId != category.Id)
                .ToList();

            var allChildren = childrenByParent
                .Concat(childrenByCategory)
                .DistinctBy(c => c.Id)
                .ToList();

            // Çocuklar için recursive filtreleme
            var filteredChildren = allChildren
                .Select(c => BuildTreeWithFilter(c, allCategories, keyword))
                .Where(c => c != null)
                .ToList()!;

            // Kendisi eşleşiyor mu?
            bool isMatch = category.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase);

            // Kendisi veya çocuklarından biri eşleşiyorsa bu node'u dahil et
            if (isMatch || filteredChildren.Any())
            {
                return new CategoryTreeDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    Children = filteredChildren.Any() ? filteredChildren : null
                };
            }

            return null;
        }

        
    }
}
