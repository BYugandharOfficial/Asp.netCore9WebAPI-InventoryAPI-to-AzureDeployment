using InventoryAPI.Models;

namespace InventoryAPI.Repository
{
    public interface ICategoriesRepository 
    {
        Task<IEnumerable<Categories>> GetAllAsync();
        Task<Categories?> GetByIdAsync(int id);
        Task<Categories> AddAsync(Categories category);
        Task<Categories> UpdateAsync(Categories category);
        Task<bool> DeleteAsync(int id);
    }
}
