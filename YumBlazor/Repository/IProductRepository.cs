﻿using YumBlazor.Data;

namespace YumBlazor.Repository
{
    public interface IProductRepository
    {
        public Task<Product> CreateAsync(Product product);
        public Task<Product> UpdateAsync(Product product);
        public Task<bool> DeleteAsync(int id);
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task<Product> GetByIdAsync(int id);
    }
}
