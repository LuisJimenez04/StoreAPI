using StoreAPI.Application.Interfaces;
using StoreAPI.Domain.Entities;
using StoreAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StoreAPI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _appDbContext.Products.ToListAsync();
        }
        public async Task<Product?> GetProductByIdAsync(int id) {
            return await _appDbContext.Products.FindAsync(id);
        }
        public async Task<Product> CreateNewProduct(Product product)
        {
            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();
            return product;

        }
        public async Task<Product> UpdateProduct(int idProduct, Product product)
        {
            var existingProduct = await _appDbContext.Products.FindAsync(idProduct);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
            }
            else
                throw new Exception("Product not found");

            await _appDbContext.SaveChangesAsync();

            return existingProduct;
        }
        public async Task<bool> DeleteProduct(int idProduct)
        {
            var product = await _appDbContext.Products.FindAsync(idProduct);
            if (product == null)
                return false;

            _appDbContext.Products.Remove(product);

            await _appDbContext.SaveChangesAsync();

            return true;
        }
    }
}
