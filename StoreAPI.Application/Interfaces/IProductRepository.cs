using StoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAPI.Application.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task<Product?> GetProductByIdAsync(int id);
        public Task<Product> CreateNewProduct(Product product);
        public Task<Product> UpdateProduct(int idProduct, Product product);
        public Task<bool> DeleteProduct(int idProduct);
    }
}
