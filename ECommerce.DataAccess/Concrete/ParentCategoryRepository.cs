﻿using ECommerce.Core.Models.Response.Categories;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Concrete
{
    public class ParentCategoryRepository : IParentCategoryRepository
    {
        EcommerceContext _context;
        public ParentCategoryRepository(EcommerceContext context)
        {
            _context = new();
        }

        public async Task<List<ParentCategory>> GetAllAsync()
        {
            return await _context.ParentCategories.ToListAsync(); // Parent category lerin hepsini listeledim.
        }

        public async Task<ParentCategory> GetByIdAsync(int id)
        {
            return await _context.ParentCategories.Where(pc => pc.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ParentCategory>> GetAllWithCategories()
        {
            var parentCategories = await _context.ParentCategories
                .Include(pc => pc.Categories)
                .ToListAsync();

            return parentCategories;
        }

        
    }
}
