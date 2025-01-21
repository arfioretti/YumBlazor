using YumBlazor.Data;

namespace YumBlazor.Repository
{
    public interface ICategoryRepository
    {
        public Task<Category> CreateAsync(Category category);
        public Task<Category> UpdateAsync(Category category);
        public Task<bool> DeleteAsync(int id);
        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<Category> GetByIdAsync(int id);
    }
}
