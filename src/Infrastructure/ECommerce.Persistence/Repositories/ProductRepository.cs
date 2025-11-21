using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories
{
    public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
    {
        public async Task<IEnumerable<Product>> GetLowStockProductsAsync(int threshold) =>
            await Context.Products
                .Where(p => p.Stock < threshold)
                .ToListAsync().ConfigureAwait(false);
    }
}