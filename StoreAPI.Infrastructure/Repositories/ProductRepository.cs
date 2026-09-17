using StoreAPI.Application.Interfaces;
using StoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAPI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _product = new();

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return Task.FromResult<IEnumerable<Product>>(_product);
        }
        public Task<Product?> GetProductByIdAsync(int id) {
            var product = _product.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }
        public Task<Product> CreateNewProduct(Product product)
        {
            int newId = product.Id == 0 ? _product.DefaultIfEmpty(new Product()).Max(p => p.Id) + 1 : product.Id;
            product.Id = newId;
            _product.Add(product);
            return Task.FromResult(product);

        }
        public Task<Product> UpdateProduct(int idProduct, Product product)
        {
            var existingProduct = _product.FirstOrDefault(p => p.Id == idProduct);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
            }
            else
                throw new Exception("Product not found");

            return Task.FromResult(existingProduct);
        }
        public Task<bool> DeleteProduct(int idProduct)
        {
            var product = _product.FirstOrDefault(p => p.Id == idProduct);
            if (product != null)
            {
                _product.Remove(product);
                return Task.FromResult(true);
            }
            else
                return Task.FromResult(false);
        }
    }
}
