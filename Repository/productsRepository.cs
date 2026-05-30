using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace InventoryAPI.Repository
{
    public class productsRepository : IProductsRepository
    {
        private readonly AppDbContext _context;

        public productsRepository (AppDbContext context)
        {
            _context = context;
        }

        public async Task<Products> AddAsync(Products product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Products?> GetByIdAsync(int id)
        {
          return await _context.Products.AsNoTracking().FirstOrDefaultAsync (p => p.ProductId == id); 
        }

        public async Task<Products> UpdateAsync(Products product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
