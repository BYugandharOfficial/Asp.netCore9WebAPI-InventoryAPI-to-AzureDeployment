using InventoryAPI.Controllers;
using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace InventoryAPI.Repository
{
    public class categoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext _context;

        public categoriesRepository(AppDbContext context)
        {
            _context = context;
        }

     

        public async Task<Categories> AddAsync(Categories category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categories = await _context.Categories.FindAsync(id);
            if (categories == null) return false;

            _context.Categories.Remove(categories);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Categories>> GetAllAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();

        }

        public async Task<Categories?> GetByIdAsync(int id)
        {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.CategoryId == id);

        }

        public async Task<Categories> UpdateAsync(Categories category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;

        }
    }
}
