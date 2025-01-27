namespace YumBlazor.Repository
{
    public interface IShoppingCartRepository
    {
        public async Task<bool> UpdateCartAsync(string userId, int product, int updateBy);
        public async Task<IEnumerable<IShoppingCartRepository>> GetAllAsync(string? userId);
        public async Task<bool> ClearCartAsync(string? userId);
    }
}

