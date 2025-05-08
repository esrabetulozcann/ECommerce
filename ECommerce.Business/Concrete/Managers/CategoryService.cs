using ECommerce.Business.Abstract;
using ECommerce.Core.Models.DTO;
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

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
