using InventoryAPI.Models;

namespace InventoryAPI.Repository
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Products>> GetAllAsync();
        Task<Products?> GetByIdAsync(int id);
        Task<Products> AddAsync(Products product);
        Task<Products> UpdateAsync(Products product);
        Task<bool> DeleteAsync(int id);
    }
}
