using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Migrations;

namespace YumBlazor.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await _db.AddAsync(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null) 
            {
                _db.Categories.Remove(category);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Categories.ToListAsync(); 
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if(category == null)
            {
                category = new Category();
                return category;
            }
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            var categoryFromDb = await _db.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
            if (categoryFromDb != null)
            {
                categoryFromDb.Name = category.Name;
                _db.Categories.Update(categoryFromDb);
                await _db.SaveChangesAsync();
                return categoryFromDb;
            }
            return category;
        }
    }
}
