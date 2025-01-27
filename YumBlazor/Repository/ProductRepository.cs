using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Migrations;

namespace YumBlazor.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvirament;

        public ProductRepository(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvirament = webHostEnvironment;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            await _db.AddAsync(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(c => c.Id == id);
            var imagePath = Path.Combine(_webHostEnvirament.WebRootPath, product.ImageUrl.TrimStart('/'));
            if (File.Exists(imagePath)) 
            {
                File.Delete(imagePath);
            }
            if (product != null) 
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Products.Include("Category").ToListAsync(); 
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _db.Products.Include("Category").FirstOrDefaultAsync(c => c.Id == id);
            if(product == null)
            {
                product = new Product();
                return product;
            }
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var productFromDb = await _db.Products.FirstOrDefaultAsync(c => c.Id == product.Id);
            if (productFromDb != null)
            {
                productFromDb.Name = product.Name;
                productFromDb.ImageUrl = product.ImageUrl;
                productFromDb.Description = product.Description;
                productFromDb.Price = product.Price;
                productFromDb.SpecialTag = product.SpecialTag;
                _db.Products.Update(productFromDb);
                await _db.SaveChangesAsync();
                return productFromDb;
            }
            return product;
        }
    }
}
