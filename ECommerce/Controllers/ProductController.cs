﻿using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete.Managers;
using ECommerce.Core.Models.Response.Product;
using ECommerce.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProduct")]
        public async Task<ActionResult<List<ProductResponseModel>>> GetAllAsync()
        {
            return await _productService.GetAllAsync();
        }


        [HttpGet("{id}/Products")]
        public async Task<ActionResult<ProductResponseModel>> GetByIdAsync(int id)
        {
            return await _productService.GetByIdAsync(id);
        }


        [HttpGet("ProductByName")]
        public async Task<ActionResult<ProductResponseModel>> GetByNameAsync([FromQuery] string name)
        {
            return await _productService.GetByNameAsync(name);
        }


        [HttpGet("SearchKeyword")]
        public async Task<ActionResult<List<ProductResponseModel>>> GetByKeyword([FromQuery] string keyword)
        {
            return await _productService.SearchAsync(keyword);
        }


        [HttpPost] // Yeni ürün ekleme alanı
        public async Task<ActionResult<ProductResponseModel>> AddAsync([FromBody] Product product)
        {
            try
            {
                await _productService.AddAsync(product);
                return Ok("Beden başarıyla eklendi");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut] // Yeni beden güncelleme alanı

        public async Task<ActionResult<ProductResponseModel>> UpdateAsync([FromBody] Product product)
        {
            try
            {
                await _productService.UpdateAsync(product);
                return Ok("Beden başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductResponseModel>> DeleteAsync(int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
                return Ok("Beden başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
